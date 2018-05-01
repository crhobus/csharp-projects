using NUnit.Framework;
using SGAL.AcessoDados;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace SGAL.Dominio.Teste
{
    [TestFixture]
    public class RepositorioPecaTeste
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
        public void deve_salvar_peca()
        {
            var esperado = GravarPeca();
            var atual = RecarregarPeca(esperado.PecaID);

            atual.ShouldBeEquivalentTo(esperado);
        }

        [Test]
        public void deve_retornar_null_quando_peca_nao_existente()
        {
            var esperado = GravarPeca();
            var atual = RecarregarPeca(esperado.PecaID + 100);

            atual.Should().BeNull();
        }

        [Test]
        public void deve_recuperar_a_peca_correta()
        {
            var peca01 = GravarPeca();
            var peca02 = GravarPeca();
            var peca03 = GravarPeca();

            RecarregarPeca(peca01.PecaID).ShouldBeEquivalentTo(peca01);
            RecarregarPeca(peca02.PecaID).ShouldBeEquivalentTo(peca02);
            RecarregarPeca(peca03.PecaID).ShouldBeEquivalentTo(peca03);
        }

        [Test]
        public void deve_listar_todas_pecas()
        {
            var peca01 = GravarPeca();
            var peca02 = GravarPeca();
            var peca03 = GravarPeca();

            List<Peca> todasPecasRecuperadas = null;

            using (var repositorio = new RepositorioPeca(sgalContext))
            {
                todasPecasRecuperadas = repositorio.Recuperar();
            }

            todasPecasRecuperadas.Should().NotBeNull();
            todasPecasRecuperadas.Count.Should().Be(3);
            todasPecasRecuperadas.ShouldAllBeEquivalentTo(new[] { peca01, peca02, peca03 });

            peca01.Imagem.Should().NotBeNull();
            peca02.Imagem.Should().NotBeNull();
            peca03.Imagem.Should().NotBeNull();
        }

        [Test]
        public void deve_alterar_peca()
        {
            var peca01 = GravarPeca();

            using (var repositorio = new RepositorioPeca(sgalContext))
            {
                peca01.Descricao = "Alteração descrição";

                repositorio.Atualizar(peca01);
            }

            var atual = RecarregarPeca(peca01.PecaID);

            atual.Descricao.Should().Be("Alteração descrição");
        }

        [Test]
        public void deve_excluir_peca()
        {
            var peca01 = GravarPeca();

            using (var repositorio = new RepositorioPeca(sgalContext))
            {
                repositorio.Excluir(peca01);
            }

            var atual = RecarregarPeca(peca01.PecaID);
            atual.Should().BeNull();
        }

        private Peca GravarPeca()
        {
            var peca = new Peca()
            {
                Descricao = "Peça um",
                Imagem = Image.FromFile("C:\\img\\peca1.jpg")
            };

            using (var repositorio = new RepositorioPeca(sgalContext))
            {
                repositorio.Inserir(peca);
                repositorio.Salvar();
            }

            return peca;
        }

        private Peca RecarregarPeca(int pecaId)
        {
            using (var repositorio = new RepositorioPeca(sgalContext))
            {
                return repositorio.Recuperar(pecaId);
            }
        }
    }
}
