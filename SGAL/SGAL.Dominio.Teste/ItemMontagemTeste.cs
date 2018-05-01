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
    public class ItemMontagemTeste
    {
        [Test]
        public void deve_ser_um_item_montagem_valido()
        {
            var itemMontagem = new ItemMontagem()
            {
                Peca = new Peca()
                {
                    Descricao = "Peça nova",
                    Imagem = Image.FromFile("C:\\img\\pecanova.jpg")
                },
                Quantidade = 1
            };

            const bool validacaoEsperada = true;

            itemMontagem.Valido.Should().Be(validacaoEsperada);
        }

        [Test]
        public void deve_ser_um_item_montagem_invalido_quando_nao_tem_quantidade()
        {
            var itemMontagem = new ItemMontagem()
            {
                Peca = new Peca()
                {
                    Descricao = "Peça nova",
                    Imagem = Image.FromFile("C:\\img\\pecanova.jpg")
                }
            };

            const bool validacaoEsperada = false;

            itemMontagem.Valido.Should().Be(validacaoEsperada);
        }

        [Test]
        public void deve_ser_um_item_montagem_invalido_quando_nao_tem_peca()
        {
            var itemMontagem = new ItemMontagem()
            {
                Quantidade = 1
            };

            const bool validacaoEsperada = false;

            itemMontagem.Valido.Should().Be(validacaoEsperada);
        }

        [Test]
        public void deve_ser_um_item_montagem_invalido_quando_nao_tem_peca_valida()
        {
            var itemMontagem = new ItemMontagem()
            {
                Peca = new Peca()
                {
                    Descricao = "Peça nova"
                },
                Quantidade = 1
            };

            const bool validacaoEsperada = false;

            itemMontagem.Valido.Should().Be(validacaoEsperada);
        }
    }
}
