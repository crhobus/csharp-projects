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
    public class MontagemTeste
    {
        [Test]
        public void deve_representar_montagem_como_string()
        {
            Montagem montagem = new Montagem();

            montagem.DataCriacao = new DateTimeOffset(2015, 10, 03, 14, 45, 00, TimeSpan.Zero);

            var representacaoStringEsperada = "Montagem 2015-10-03 14:45:00";

            var atual = montagem.ToString();

            atual.Should().Be(representacaoStringEsperada);
        }

        [Test]
        public void deve_ser_uma_montagem_valida()
        {
            var legoozer = new LegooZer()
            {
                EnderecoEmail = "mad@max.com.br",
                Nome = "Mad",
                SobreNome = "Max"
            };
            legoozer.Enderecos.Add(new Endereco()
            {
                TipoEndereco = TipoEndereco.Residencial,
                Linha01 = "Rua da Loucura",
                Linha02 = "Bairro da Lucidez",
                Cidade = "Blumenau",
                Estado = "SC",
                Pais = "Brasil",
                CodigoPostal = "89035"
            });

            var montagem = new Montagem()
            {
                LegooZer = legoozer,
                DataCriacao = new DateTimeOffset(),
                DescricaoPassoAPasso = "Descrição de como montar o Lego",
                ImagemFinal = Image.FromFile("C:\\img\\legomontado.jpg")
            };
            montagem.Itens.Add(new ItemMontagem()
            {
                Peca = new Peca()
                {
                    Descricao = "Peça nova",
                    Imagem = Image.FromFile("C:\\img\\pecanova.jpg")
                },
                Quantidade = 1
            });

            const bool validacaoEsperada = true;

            montagem.Valido.Should().Be(validacaoEsperada);
        }

        [Test]
        public void deve_ser_uma_montagem_invalida_quanto_nao_tem_legoozer()
        {
            var montagem = new Montagem()
            {
                DataCriacao = new DateTimeOffset(),
                DescricaoPassoAPasso = "Descrição de como montar o Lego",
                ImagemFinal = Image.FromFile("C:\\img\\legomontado.jpg")
            };
            montagem.Itens.Add(new ItemMontagem()
            {
                Peca = new Peca()
                {
                    Descricao = "Peça nova",
                    Imagem = Image.FromFile("C:\\img\\pecanova.jpg")
                },
                Quantidade = 1
            });

            const bool validacaoEsperada = false;

            montagem.Valido.Should().Be(validacaoEsperada);
        }

        [Test]
        public void deve_ser_uma_montagem_invalida_quanto_nao_tem_descricao_passo_a_passo()
        {
            var legoozer = new LegooZer()
            {
                EnderecoEmail = "mad@max.com.br",
                Nome = "Mad",
                SobreNome = "Max"
            };
            legoozer.Enderecos.Add(new Endereco()
            {
                TipoEndereco = TipoEndereco.Residencial,
                Linha01 = "Rua da Loucura",
                Linha02 = "Bairro da Lucidez",
                Cidade = "Blumenau",
                Estado = "SC",
                Pais = "Brasil",
                CodigoPostal = "89035"
            });

            var montagem = new Montagem()
            {
                LegooZer = legoozer,
                DataCriacao = new DateTimeOffset(),
                ImagemFinal = Image.FromFile("C:\\img\\legomontado.jpg")
            };
            montagem.Itens.Add(new ItemMontagem()
            {
                Peca = new Peca()
                {
                    Descricao = "Peça nova",
                    Imagem = Image.FromFile("C:\\img\\pecanova.jpg")
                },
                Quantidade = 1
            });

            const bool validacaoEsperada = false;

            montagem.Valido.Should().Be(validacaoEsperada);
        }

        [Test]
        public void deve_ser_uma_montagem_invalida_quanto_nao_tem_imagem_final()
        {
            var legoozer = new LegooZer()
            {
                EnderecoEmail = "mad@max.com.br",
                Nome = "Mad",
                SobreNome = "Max"
            };
            legoozer.Enderecos.Add(new Endereco()
            {
                TipoEndereco = TipoEndereco.Residencial,
                Linha01 = "Rua da Loucura",
                Linha02 = "Bairro da Lucidez",
                Cidade = "Blumenau",
                Estado = "SC",
                Pais = "Brasil",
                CodigoPostal = "89035"
            });

            var montagem = new Montagem()
            {
                LegooZer = legoozer,
                DataCriacao = new DateTimeOffset(),
                DescricaoPassoAPasso = "Descrição de como montar o Lego",
            };
            montagem.Itens.Add(new ItemMontagem()
            {
                Peca = new Peca()
                {
                    Descricao = "Peça nova",
                    Imagem = Image.FromFile("C:\\img\\pecanova.jpg")
                },
                Quantidade = 1
            });

            const bool validacaoEsperada = false;

            montagem.Valido.Should().Be(validacaoEsperada);
        }

        [Test]
        public void deve_ser_uma_montagem_invalida_quanto_nao_tem_item_montagem()
        {
            var legoozer = new LegooZer()
            {
                EnderecoEmail = "mad@max.com.br",
                Nome = "Mad",
                SobreNome = "Max"
            };
            legoozer.Enderecos.Add(new Endereco()
            {
                TipoEndereco = TipoEndereco.Residencial,
                Linha01 = "Rua da Loucura",
                Linha02 = "Bairro da Lucidez",
                Cidade = "Blumenau",
                Estado = "SC",
                Pais = "Brasil",
                CodigoPostal = "89035"
            });

            var montagem = new Montagem()
            {
                LegooZer = legoozer,
                DataCriacao = new DateTimeOffset(),
                DescricaoPassoAPasso = "Descrição de como montar o Lego",
                ImagemFinal = Image.FromFile("C:\\img\\legomontado.jpg")
            };

            const bool validacaoEsperada = false;

            montagem.Valido.Should().Be(validacaoEsperada);
        }

        [Test]
        public void deve_ser_uma_montagem_invalida_quanto_nao_tem_legoozer_valido()
        {
            var legoozer = new LegooZer()
            {
                EnderecoEmail = "mad@max.com.br",
                Nome = "Mad",
                SobreNome = ""
            };
            legoozer.Enderecos.Add(new Endereco()
            {
                TipoEndereco = TipoEndereco.Residencial,
                Linha01 = "Rua da Loucura",
                Linha02 = "Bairro da Lucidez",
                Cidade = "Blumenau",
                Estado = "SC",
                Pais = "Brasil",
                CodigoPostal = "89035"
            });

            var montagem = new Montagem()
            {
                LegooZer = legoozer,
                DataCriacao = new DateTimeOffset(),
                DescricaoPassoAPasso = "Descrição de como montar o Lego",
                ImagemFinal = Image.FromFile("C:\\img\\legomontado.jpg")
            };
            montagem.Itens.Add(new ItemMontagem()
            {
                Peca = new Peca()
                {
                    Descricao = "Peça nova",
                    Imagem = Image.FromFile("C:\\img\\pecanova.jpg")
                },
                Quantidade = 1
            });

            const bool validacaoEsperada = false;

            montagem.Valido.Should().Be(validacaoEsperada);
        }

        [Test]
        public void deve_ser_uma_montagem_invalida_quanto_nao_tem_item_montagem_valido()
        {
            var legoozer = new LegooZer()
            {
                EnderecoEmail = "mad@max.com.br",
                Nome = "Mad",
                SobreNome = "Max"
            };
            legoozer.Enderecos.Add(new Endereco()
            {
                TipoEndereco = TipoEndereco.Residencial,
                Linha01 = "Rua da Loucura",
                Linha02 = "Bairro da Lucidez",
                Cidade = "Blumenau",
                Estado = "SC",
                Pais = "Brasil",
                CodigoPostal = "89035"
            });

            var montagem = new Montagem()
            {
                LegooZer = legoozer,
                DataCriacao = new DateTimeOffset(),
                DescricaoPassoAPasso = "Descrição de como montar o Lego",
                ImagemFinal = Image.FromFile("C:\\img\\legomontado.jpg")
            };
            montagem.Itens.Add(new ItemMontagem()
            {
                Peca = new Peca()
                {
                    Descricao = "Peça nova",
                    Imagem = Image.FromFile("C:\\img\\pecanova.jpg")
                },
            });

            const bool validacaoEsperada = false;

            montagem.Valido.Should().Be(validacaoEsperada);
        }

        [Test]
        public void deve_ser_uma_montagem_invalida_quanto_nao_tem_peca_item_montagem_valido()
        {
            var legoozer = new LegooZer()
            {
                EnderecoEmail = "mad@max.com.br",
                Nome = "Mad",
                SobreNome = "Max"
            };
            legoozer.Enderecos.Add(new Endereco()
            {
                TipoEndereco = TipoEndereco.Residencial,
                Linha01 = "Rua da Loucura",
                Linha02 = "Bairro da Lucidez",
                Cidade = "Blumenau",
                Estado = "SC",
                Pais = "Brasil",
                CodigoPostal = "89035"
            });

            var montagem = new Montagem()
            {
                LegooZer = legoozer,
                DataCriacao = new DateTimeOffset(),
                DescricaoPassoAPasso = "Descrição de como montar o Lego",
                ImagemFinal = Image.FromFile("C:\\img\\legomontado.jpg")
            };
            montagem.Itens.Add(new ItemMontagem()
            {
                Peca = new Peca()
                {
                    Descricao = "Peça nova"
                },
                Quantidade = 1
            });

            const bool validacaoEsperada = false;

            montagem.Valido.Should().Be(validacaoEsperada);
        }
    }
}
