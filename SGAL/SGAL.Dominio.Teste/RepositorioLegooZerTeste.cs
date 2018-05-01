using NUnit.Framework;
using SGAL.AcessoDados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using SGAL.UI.ConsoleX;

namespace SGAL.Dominio.Teste
{
    [TestFixture]
    public class RepositorioLegooZerTeste
    {
        private SGALContext sgalContext;

        [SetUp]
        public void SetUp()
        {
            sgalContext = new SGALContext("SGAL.Teste");
        }

        [TearDown]
        public void TearDown()
        {
            sgalContext.Database.Delete();
        }

        [Test]
        public void deve_salvar_legoozer()
        {
            var esperado = GravarLegooZer();
            var atual = RecarregarLegooZer(esperado.LegooZerID);

            atual.ShouldBeEquivalentTo(esperado);
        }

        [Test]
        public void deve_retornar_null_quando_legoozer_nao_existente()
        {
            var esperado = GravarLegooZer();
            var atual = RecarregarLegooZer(esperado.LegooZerID + 100);

            atual.Should().BeNull();
        }

        [Test]
        public void deve_recuperar_o_legoozer_correto()
        {
            var legooZer01 = GravarLegooZer();
            var legooZer02 = GravarLegooZer();
            var legooZer03 = GravarLegooZer();

            RecarregarLegooZer(legooZer01.LegooZerID).ShouldBeEquivalentTo(legooZer01);
            RecarregarLegooZer(legooZer02.LegooZerID).ShouldBeEquivalentTo(legooZer02);
            RecarregarLegooZer(legooZer03.LegooZerID).ShouldBeEquivalentTo(legooZer03);
        }

        [Test]
        public void deve_listar_todos_legoozers()
        {
            var legooZer01 = GravarLegooZer();
            var legooZer02 = GravarLegooZer();
            var legooZer03 = GravarLegooZer();

            List<LegooZer> todosLegoozersRecuperados = null;

            using (var repositorio = new RepositorioLegooZer(sgalContext))
            {
                todosLegoozersRecuperados = repositorio.Recuperar();
            }

            todosLegoozersRecuperados.Should().NotBeNull();
            todosLegoozersRecuperados.Count.Should().Be(3);
            todosLegoozersRecuperados.ShouldAllBeEquivalentTo(new[] { legooZer01, legooZer02, legooZer03 });

            legooZer01.Enderecos.Should().NotBeNull();
            legooZer01.Enderecos[0].Should().NotBeNull();
        }

        [Test]
        public void deve_alterar_legoozer()
        {
            var legooZer01 = GravarLegooZer();

            using (var repositorio = new RepositorioLegooZer(sgalContext))
            {
                legooZer01.Nome = "Harry";

                repositorio.Atualizar(legooZer01);
            }

            var atual = RecarregarLegooZer(legooZer01.LegooZerID);

            atual.Nome.Should().Be("Harry");
        }

        [Test]
        public void deve_excluir_legoozer()
        {
            var legooZer01 = GravarLegooZer();

            using (var repositorio = new RepositorioLegooZer(sgalContext))
            {
                repositorio.Excluir(legooZer01);
            }

            var atual = RecarregarLegooZer(legooZer01.LegooZerID);
            atual.Should().BeNull();
        }

        [Test]
        public void deve_recuperar_para_apresentacao()
        {
            var legooZer01 = GravarLegooZer();

            IEnumerable<LegooZerApresentacao> atual = null;

            atual = sgalContext.RecuperarParaApresentacao();

            atual.Should().NotBeNull();
            atual.Count().Should().Be(1);

            atual.First().LegooZerID.Should().Be(legooZer01.LegooZerID);
            atual.First().NomeCompleto.Should().Be(legooZer01.NomeCompleto);
            atual.First().EnderecoEmail.Should().Be(legooZer01.EnderecoEmail);
            atual.First().Cidade.Should().Be(legooZer01.Enderecos[0].Cidade);
        }

        [Test]
        public void deve_carregar_enderecos_de_um_legoozer()
        {
            var legooZer = GravarLegooZer();

            List<Endereco> enderecosLegooZer = RecarregarLegooZer(legooZer.LegooZerID).Enderecos;

            enderecosLegooZer.Count.Should().Be(2);

            enderecosLegooZer[0].TipoEndereco.Should().Be(TipoEndereco.Residencial);
            enderecosLegooZer[0].Cidade.Should().Be("Timbó");
            enderecosLegooZer[0].CodigoPostal.Should().Be("89034");
            enderecosLegooZer[0].Estado.Should().Be("SC");
            enderecosLegooZer[0].Linha01.Should().Be("Avenida Brasil, 1001");
            enderecosLegooZer[0].Linha02.Should().Be("Centro");
            enderecosLegooZer[0].Pais.Should().Be("Brasil");

            enderecosLegooZer[1].TipoEndereco.Should().Be(TipoEndereco.Comercial);
            enderecosLegooZer[1].Cidade.Should().Be("Blumenau");
            enderecosLegooZer[1].CodigoPostal.Should().Be("89035");
            enderecosLegooZer[1].Estado.Should().Be("SC");
            enderecosLegooZer[1].Linha01.Should().Be("Antônio da Veiga, 200");
            enderecosLegooZer[1].Linha02.Should().Be("Victor Konder");
            enderecosLegooZer[1].Pais.Should().Be("Brasil");
        }

        private LegooZer GravarLegooZer()
        {
            var legoozer = new LegooZer()
            {
                Nome = "Mad",
                SobreNome = "Max",
                EnderecoEmail = "mad@max.com"
            };

            legoozer.Enderecos.Add(new Endereco()
            {
                TipoEndereco = TipoEndereco.Residencial,
                Cidade = "Timbó",
                CodigoPostal = "89034",
                Estado = "SC",
                Linha01 = "Avenida Brasil, 1001",
                Linha02 = "Centro",
                Pais = "Brasil",
            });
            legoozer.Enderecos.Add(new Endereco()
            {
                TipoEndereco = TipoEndereco.Comercial,
                Cidade = "Blumenau",
                CodigoPostal = "89035",
                Estado = "SC",
                Linha01 = "Antônio da Veiga, 200",
                Linha02 = "Victor Konder",
                Pais = "Brasil",
            });

            using (var repositorio = new RepositorioLegooZer(sgalContext))
            {
                repositorio.Inserir(legoozer);
                repositorio.Salvar();
            }

            return legoozer;
        }

        private LegooZer RecarregarLegooZer(int legooZerId)
        {
            using (var repositorio = new RepositorioLegooZer(sgalContext))
            {
                return repositorio.Recuperar(legooZerId);
            }
        }
    }
}
