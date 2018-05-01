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
    public class RepositorioItemMontagemTeste
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
        public void deve_salvar_item_montagem()
        {
            var esperado = GravarItemMontagem();
            var atual = RecarregarItemMontagem(esperado.ItemMontagemID);

            atual.ShouldBeEquivalentTo(esperado);
        }

        [Test]
        public void deve_retornar_null_quando_item_montagem_nao_existente()
        {
            var esperado = GravarItemMontagem();
            var atual = RecarregarItemMontagem(esperado.ItemMontagemID + 100);

            atual.Should().BeNull();
        }

        [Test]
        public void deve_recuperar_o_item_montagem_correto()
        {
            var itemMontagem01 = GravarItemMontagem();
            var itemMontagem02 = GravarItemMontagem();
            var itemMontagem03 = GravarItemMontagem();

            RecarregarItemMontagem(itemMontagem01.ItemMontagemID).ShouldBeEquivalentTo(itemMontagem01);
            RecarregarItemMontagem(itemMontagem02.ItemMontagemID).ShouldBeEquivalentTo(itemMontagem02);
            RecarregarItemMontagem(itemMontagem03.ItemMontagemID).ShouldBeEquivalentTo(itemMontagem03);
        }

        [Test]
        public void deve_listar_todos_itens_montagem()
        {
            var itemMontagem01 = GravarItemMontagem();
            var itemMontagem02 = GravarItemMontagem();
            var itemMontagem03 = GravarItemMontagem();

            List<ItemMontagem> todosItensMontagemRecuperados = null;

            using (var repositorio = new RepositorioItemMontagem(sgalContext))
            {
                todosItensMontagemRecuperados = repositorio.Recuperar();
            }

            todosItensMontagemRecuperados.Should().NotBeNull();
            todosItensMontagemRecuperados.Count.Should().Be(3);
            todosItensMontagemRecuperados.ShouldAllBeEquivalentTo(new[] { itemMontagem01, itemMontagem02, itemMontagem03 });

            itemMontagem01.Peca.Should().NotBeNull();
            itemMontagem01.Peca.Imagem.Should().NotBeNull();
            itemMontagem02.Peca.Should().NotBeNull();
            itemMontagem02.Peca.Imagem.Should().NotBeNull();
            itemMontagem03.Peca.Should().NotBeNull();
            itemMontagem03.Peca.Imagem.Should().NotBeNull();
        }

        [Test]
        public void deve_alterar_item_montagem()
        {
            var itemMontagem01 = GravarItemMontagem();

            using (var repositorio = new RepositorioItemMontagem(sgalContext))
            {
                itemMontagem01.Quantidade = 5;

                repositorio.Atualizar(itemMontagem01);
            }

            var atual = RecarregarItemMontagem(itemMontagem01.ItemMontagemID);

            atual.Quantidade.Should().Be(5);
        }

        [Test]
        public void deve_excluir_item_montagem()
        {
            var itemMontagem01 = GravarItemMontagem();

            using (var repositorio = new RepositorioItemMontagem(sgalContext))
            {
                repositorio.Excluir(itemMontagem01);
            }

            var atual = RecarregarItemMontagem(itemMontagem01.ItemMontagemID);
            atual.Should().BeNull();
        }

        private ItemMontagem GravarItemMontagem()
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

            using (var repositorio = new RepositorioItemMontagem(sgalContext))
            {
                repositorio.Inserir(itemMontagem);
                repositorio.Salvar();
            }

            return itemMontagem;
        }

        private ItemMontagem RecarregarItemMontagem(int itemMontagemID)
        {
            using (var repositorio = new RepositorioItemMontagem(sgalContext))
            {
                return repositorio.Recuperar(itemMontagemID);
            }
        }
    }
}
