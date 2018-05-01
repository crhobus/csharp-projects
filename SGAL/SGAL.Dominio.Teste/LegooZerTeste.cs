using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace SGAL.Dominio.Teste
{
    [TestFixture]
    public class LegooZerTeste
    {
        [Test]
        public void deve_retornar_nome_completo()
        {
            LegooZer legoozer = new LegooZer();
            legoozer.Nome = "Mad";
            legoozer.SobreNome = "Max";

            const string nomeCompletoEsperado = "Max, Mad";

            string nomeCompletoAtual = legoozer.NomeCompleto;

            nomeCompletoAtual.Should().Be(nomeCompletoEsperado);
        }

        [Test]
        public void deve_retornar_nome_completo_quando_nome_nao_informado()
        {
            LegooZer legoozer = new LegooZer();

            legoozer.SobreNome = "Max";

            const string nomeCompletoEsperado = "Max";

            string nomeCompletoAtual = legoozer.NomeCompleto;

            nomeCompletoAtual.Should().Be(nomeCompletoEsperado);
        }

        [Test]
        public void deve_retornar_nome_completo_quando_sobrenome_nao_informado()
        {
            LegooZer legoozer = new LegooZer();

            legoozer.Nome = "Mad";

            const string nomeCompletoEsperado = "Mad";

            string nomeCompletoAtual = legoozer.NomeCompleto;

            nomeCompletoAtual.Should().Be(nomeCompletoEsperado);
        }

        [Test]
        public void deve_ser_um_legoozer_valido()
        {
            LegooZer legoozer = new LegooZer();

            legoozer.SobreNome = "Max";
            legoozer.EnderecoEmail = "mad@max.com.br";

            const bool validacaoEsperada = true;

            legoozer.Valido.Should().Be(validacaoEsperada);
        }

        [Test]
        public void deve_ser_um_legoozer_invalido_quando_nao_tem_sobrenome()
        {
            LegooZer legoozer = new LegooZer();

            legoozer.EnderecoEmail = "mad@max.com.br";

            const bool validacaoEsperada = false;

            legoozer.Valido.Should().Be(validacaoEsperada);
        }

        [Test]
        public void deve_ser_um_legoozer_invalido_quando_nao_tem_endereco_email()
        {
            LegooZer legoozer = new LegooZer();

            legoozer.SobreNome = "Max";

            const bool validacaoEsperada = false;

            legoozer.Valido.Should().Be(validacaoEsperada);
        }

        [Test]
        public void email_do_legoozer_deve_ser_valido()
        {
            LegooZer legoozer = new LegooZer();

            legoozer.Invoking(l => l.EnderecoEmail = "mad@max.com.br").ShouldNotThrow<EnderecoDeEmailInvalidoException>();
        }

        [Test]
        public void email_do_legoozer_deve_ser_invalido()
        {
            LegooZer legoozer = new LegooZer();

            legoozer.Invoking(l => l.EnderecoEmail = "isso não é um email").ShouldThrow<EnderecoDeEmailInvalidoException>();
        }

        [Test]
        public void deve_possibilitar_ler_o_endereco()
        {
            LegooZer legoozer = new LegooZer();

            legoozer.Enderecos.Count.Should().Be(0);
        }

        [Test]
        public void deve_representar_legoozer_como_string()
        {
            LegooZer legoozer = new LegooZer();

            legoozer.Nome = "Mad";
            legoozer.SobreNome = "Max";
            legoozer.EnderecoEmail = "mad@max.com.br";

            var representacaoStringEsperada = "Max, Mad (mad@max.com.br)";

            var atual = legoozer.ToString();

            atual.Should().Be(representacaoStringEsperada);
        }

        [Test]
        public void deve_representar_legoozer_como_string_quando_nao_tem_email()
        {
            LegooZer legoozer = new LegooZer();

            legoozer.Nome = "Mad";
            legoozer.SobreNome = "Max";

            var representacaoStringEsperada = "Max, Mad";

            var atual = legoozer.ToString();

            atual.Should().Be(representacaoStringEsperada);
        }

        [Test]
        public void legoozer_deve_possuir_endereco_valido()
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

            const bool validacaoEsperada = true;

            legoozer.Enderecos[0].Valido.Should().Be(validacaoEsperada);
            legoozer.Enderecos[1].Valido.Should().Be(validacaoEsperada);
        }

        [Test]
        public void legoozer_deve_possuir_endereco_invalido()
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
                Cidade = "",
                CodigoPostal = "",
                Estado = "SC",
                Linha01 = "Avenida Brasil, 1001",
                Linha02 = "Centro",
                Pais = "Brasil",
            });
            legoozer.Enderecos.Add(new Endereco()
            {
                Cidade = "Blumenau",
                CodigoPostal = "89035",
                Estado = "SC",
                Linha01 = "Antônio da Veiga, 200",
                Linha02 = "Victor Konder",
                Pais = "Brasil",
            });

            const bool validacaoEsperada = false;

            legoozer.Enderecos[0].Valido.Should().Be(validacaoEsperada);
            legoozer.Enderecos[1].Valido.Should().Be(validacaoEsperada);
        }

    }
}