﻿using NUnit.Framework;
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
    public class RepositorioMontagemTeste
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
        public void deve_salvar_montagem()
        {
            var esperado = GravarMontagem();
            var atual = RecarregarMontagem(esperado.MontagemID);

            atual.ShouldBeEquivalentTo(esperado);
        }

        [Test]
        public void deve_retornar_null_quando_montagem_nao_existente()
        {
            var esperado = GravarMontagem();
            var atual = RecarregarMontagem(esperado.MontagemID + 100);

            atual.Should().BeNull();
        }

        [Test]
        public void deve_recuperar_a_montagem_correta()
        {
            var montagem01 = GravarMontagem();
            var montagem02 = GravarMontagem();
            var montagem03 = GravarMontagem();

            RecarregarMontagem(montagem01.MontagemID).ShouldBeEquivalentTo(montagem01);
            RecarregarMontagem(montagem02.MontagemID).ShouldBeEquivalentTo(montagem02);
            RecarregarMontagem(montagem03.MontagemID).ShouldBeEquivalentTo(montagem03);
        }

        [Test]
        public void deve_listar_todas_montagens()
        {
            var montagem01 = GravarMontagem();
            var montagem02 = GravarMontagem();
            var montagem03 = GravarMontagem();

            List<Montagem> todasMontagensRecuperadas = null;

            using (var repositorio = new RepositorioMontagem(sgalContext))
            {
                todasMontagensRecuperadas = repositorio.Recuperar();
            }

            todasMontagensRecuperadas.Should().NotBeNull();
            todasMontagensRecuperadas.Count.Should().Be(3);
            todasMontagensRecuperadas.ShouldAllBeEquivalentTo(new[] { montagem01, montagem02, montagem03 });

            montagem01.LegooZer.Enderecos.Should().NotBeNull();
            montagem01.LegooZer.Enderecos[0].Should().NotBeNull();
            montagem01.ImagemFinal.Should().NotBeNull();
            montagem01.Itens.Should().NotBeNull();
            montagem01.Itens[0].Should().NotBeNull();
            montagem01.Itens[0].Peca.Should().NotBeNull();
            montagem01.Itens[0].Peca.Imagem.Should().NotBeNull();

            montagem02.LegooZer.Enderecos.Should().NotBeNull();
            montagem02.LegooZer.Enderecos[0].Should().NotBeNull();
            montagem02.ImagemFinal.Should().NotBeNull();
            montagem02.Itens.Should().NotBeNull();
            montagem02.Itens[0].Should().NotBeNull();
            montagem02.Itens[0].Peca.Should().NotBeNull();
            montagem02.Itens[0].Peca.Imagem.Should().NotBeNull();

            montagem03.LegooZer.Enderecos.Should().NotBeNull();
            montagem03.LegooZer.Enderecos[0].Should().NotBeNull();
            montagem03.ImagemFinal.Should().NotBeNull();
            montagem03.Itens.Should().NotBeNull();
            montagem03.Itens[0].Should().NotBeNull();
            montagem03.Itens[0].Peca.Should().NotBeNull();
            montagem03.Itens[0].Peca.Imagem.Should().NotBeNull();
        }

        [Test]
        public void deve_alterar_montagem()
        {
            var montagem01 = GravarMontagem();

            using (var repositorio = new RepositorioMontagem(sgalContext))
            {
                montagem01.DescricaoPassoAPasso = "Nova descrição passo a passo de como montar o lego";

                repositorio.Atualizar(montagem01);
            }

            var atual = RecarregarMontagem(montagem01.MontagemID);

            atual.DescricaoPassoAPasso.Should().Be("Nova descrição passo a passo de como montar o lego");
        }

        [Test]
        public void deve_excluir_montagem()
        {
            var montagem01 = GravarMontagem();

            using (var repositorio = new RepositorioMontagem(sgalContext))
            {
                repositorio.Excluir(montagem01);
            }

            var atual = RecarregarMontagem(montagem01.MontagemID);
            atual.Should().BeNull();
        }

        [Test]
        public void deve_retornar_montagem_exibicao_existente()
        {
            var repositorio = new RepositorioMontagem(sgalContext);

            var montagem = GravarMontagem();

            var montagemRecuperada = repositorio.Recuperar(montagem.MontagemID);
            var montagemExibicao = repositorio.RecuperarParaExibicao(montagem.MontagemID);

            montagemExibicao.Should().NotBeNull();
            montagemExibicao.MontagemID.Should().Be(montagem.MontagemID);
            montagemExibicao.Nome.Should().Be(montagemRecuperada.LegooZer.Nome);
            montagemExibicao.SobreNome.Should().Be(montagemRecuperada.LegooZer.SobreNome);
            montagemExibicao.DataMontagem.Should().Be(montagemRecuperada.DataCriacao);
            montagemExibicao.ItensMontagemExibicao.Count.Should().Be(montagemRecuperada.Itens.Count);
            montagemExibicao.DescricaoPassoAPasso.Should().Be(montagemRecuperada.DescricaoPassoAPasso);
            
            List<ItemMontagem> itens = montagemRecuperada.Itens;
            List<ItemMontagemExibicao> itensMontagemExibicao = montagemExibicao.ItensMontagemExibicao;
            for (int i = 0; i < itensMontagemExibicao.Count; i++)
            {
                itensMontagemExibicao[i].ItemMontagemID.Should().Be(itens[i].ItemMontagemID);
                itensMontagemExibicao[i].Quantidade.Should().Be(itens[i].Quantidade);
                itensMontagemExibicao[i].NomePeca.Should().Be(itens[i].Peca.Descricao);
            }
            
        }

        private Montagem GravarMontagem()
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

            using (var repositorio = new RepositorioMontagem(sgalContext))
            {
                repositorio.Inserir(montagem);
                repositorio.Salvar();
            }

            return montagem;
        }

        private Montagem RecarregarMontagem(int montagemId)
        {
            using (var repositorio = new RepositorioMontagem(sgalContext))
            {
                return repositorio.Recuperar(montagemId);
            }
        }
    }
}
