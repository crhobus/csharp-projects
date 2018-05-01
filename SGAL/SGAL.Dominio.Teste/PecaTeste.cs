using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGAL.Dominio.Teste
{
    [TestFixture]
    public class PecaTeste
    {
        [Test]
        public void deve_representar_peca_como_string()
        {
            Peca peca = new Peca(1);

            peca.Descricao = "Uma peça qualquer";

            var representacaoStringEsperada = "1 - Uma peça qualquer";

            var atual = peca.ToString();

            atual.Should().Be(representacaoStringEsperada);
        }

        [Test]
        public void deve_ser_uma_peca_valida()
        {
            Peca peca = new Peca();

            peca.Descricao = "Uma peça qualquer";
            peca.Imagem = Image.FromFile("C:\\img\\peca1.jpg");

            const bool validacaoEsperada = true;

            peca.Valido.Should().Be(validacaoEsperada);
        }

        [Test]
        public void deve_ser_uma_peca_invalida_quando_nao_tem_descricao()
        {
            Peca peca = new Peca();

            peca.Descricao = "";
            peca.Imagem = Image.FromFile("C:\\img\\peca1.jpg");

            const bool validacaoEsperada = false;

            peca.Valido.Should().Be(validacaoEsperada);
        }

        [Test]
        public void deve_ser_uma_peca_invalida_quando_nao_tem_imagem()
        {
            Peca peca = new Peca();

            peca.Descricao = "Uma peça qualquer";
            peca.Imagem = null;

            const bool validacaoEsperada = false;

            peca.Valido.Should().Be(validacaoEsperada);
        }
    }
}
