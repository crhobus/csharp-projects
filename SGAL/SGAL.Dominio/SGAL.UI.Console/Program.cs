using SGAL.AcessoDados;
using SGAL.Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGAL.UI.ConsoleX
{
    public class Program
    {
        public static void Main(string[] args)
        {
            switch (Menu())
            {
                case 1:
                    CadastrarLegooZer();
                    break;
                case 2:
                    ListarLegooZers();
                    break;
                case 3:
                    CriarMontagemLego();
                    break;
                case 4:
                    LocalizarMontagem();
                    break;
                case 5:
                    CriarComentario();
                    break;
                case 6:
                    AvaliarMontagem();
                    break;
            }
        }

        public static void LerDoTeclado(string mensagem, out string variavel)
        {
            Console.Write(mensagem);
            variavel = Console.ReadLine();
        }

        private static void CadastrarLegooZer()
        {
            var legoozer = obterLegooZer();

            using (var repositorio = new RepositorioLegooZer(new SGALContext()))
            {
                repositorio.Inserir(legoozer);
                repositorio.Salvar();
            }
        }

        private static LegooZer obterLegooZer()
        {
            string nome, sobreNome, enderecoEmail, cidade, codigoPostal, estado, pais, tipoEndereco, linha01, linha02;

            LerDoTeclado("Nome....................:", out nome);
            LerDoTeclado("Sobrenome...............:", out sobreNome);
            LerDoTeclado("E-mail..................:", out enderecoEmail);
            LerDoTeclado("Cidade..................:", out cidade);
            LerDoTeclado("Codigo Postal...........:", out codigoPostal);
            LerDoTeclado("Estado..................:", out estado);
            LerDoTeclado("País....................:", out pais);
            LerDoTeclado("Tipo do Endereço (1/2)..:", out tipoEndereco);
            LerDoTeclado("Linha endereço 01.......:", out linha01);
            LerDoTeclado("Linha endereço 02.......:", out linha02);

            return GravarLegooZer(nome, sobreNome, enderecoEmail, cidade, codigoPostal, estado, pais, int.Parse(tipoEndereco), linha01, linha02);
        }

        private static void CriarMontagemLego()
        {
            string legooZerID, descricaoPassoAPasso, imagemFinal;

            Console.WriteLine("Dados da montagem");

            LerDoTeclado("ID LegooZer.............:", out legooZerID);
            LerDoTeclado("Descrição passo a passo.:", out descricaoPassoAPasso);
            LerDoTeclado("Imagem lego montado.....:", out imagemFinal);
            List<ItemMontagem> itens = ObterListaItensMontagem();

            var montagem = GravarMontagem(legooZerID, descricaoPassoAPasso, imagemFinal, itens);

            using (var repositorio = new RepositorioMontagem(new SGALContext()))
            {
                repositorio.Inserir(montagem);
                repositorio.Salvar();
            }
        }

        private static List<ItemMontagem> ObterListaItensMontagem()
        {
            List<ItemMontagem> itens = new List<ItemMontagem>();
            string qtdItens, descricao, imagem, quantidade;

            Console.WriteLine("");
            Console.WriteLine("Itens do lego");
            LerDoTeclado("Quantidade de itens do lego..:", out qtdItens);

            int i = 0;
            while (i != int.Parse(qtdItens))
            {
                Console.WriteLine("==============================");
                Console.WriteLine("Peça {0}", (i + 1));
                LerDoTeclado("Descrição...............:", out descricao);
                LerDoTeclado("Imagem da peça..........:", out imagem);
                LerDoTeclado("Quantidade de peças.....:", out quantidade);
                itens.Add(ObterItemMontagem(descricao, imagem, quantidade));
                i++;
            }

            return itens;
        }

        private static ItemMontagem ObterItemMontagem(string descricao, string imagem, string quantidade)
        {
            return new ItemMontagem()
            {
                Peca = new Peca()
                {
                    Descricao = descricao,
                    Imagem = Image.FromFile(imagem)
                },
                Quantidade = int.Parse(quantidade)
            };
        }

        private static void ListarLegooZers()
        {
            Console.Clear();
            Console.WriteLine("==================================================================================");
            Console.WriteLine("|ID            |Nome                |e-mail                     |Cidade                 |");
            using (var context = new SGALContext())
            {
                var legooZers = context.RecuperarParaApresentacao();
                foreach (var legoozer in legooZers)
                {
                    Console.WriteLine("|{0,12}|{1,22}|{2,30}|{3,26}|",
                        legoozer.LegooZerID,
                        legoozer.NomeCompleto,
                        legoozer.EnderecoEmail,
                        legoozer.Cidade);
                }
            }
            Console.WriteLine("==================================================================================");
        }

        private static int Menu()
        {
            Console.Clear();
            int opcao = 0;
            for (; opcao < 1 || opcao > 6;)
            {
                Console.WriteLine("==============================================================");
                Console.WriteLine("|                                                            |");
                Console.WriteLine("|              1 - Cadastrar LegooZer                        |");
                Console.WriteLine("|                                                            |");
                Console.WriteLine("|              2 - Listar LegooZers                          |");
                Console.WriteLine("|                                                            |");
                Console.WriteLine("|              3 - Criar uma montagem de Lego                |");
                Console.WriteLine("|                                                            |");
                Console.WriteLine("|              4 - Localizar Montagem                        |");
                Console.WriteLine("|                                                            |");
                Console.WriteLine("|              5 - Adicionar comentário a montagem           |");
                Console.WriteLine("|                                                            |");
                Console.WriteLine("|              6 - Avaliar Montagem                          |");
                Console.WriteLine("|                                                            |");
                Console.WriteLine("|                                                            |");
                Console.WriteLine("|                                                            |");
                Console.WriteLine("|                                                            |");
                Console.WriteLine("|                                                            |");
                Console.WriteLine("|                                                            |");
                Console.WriteLine("==============================================================");
                Console.Write("Opção: ");
                opcao = int.Parse(Console.ReadLine());
            }
            return opcao;
        }

        private static LegooZer GravarLegooZer(string nome, string sobreNome, string enderecoEmail, string cidade, string codigoPostal, string estado, string pais, int tipoEndereco, string linha01, string linha02)
        {
            var legoozer = new LegooZer()
            {
                Nome = nome,
                SobreNome = sobreNome,
                EnderecoEmail = enderecoEmail
            };

            legoozer.Enderecos.Add(new Endereco()
            {
                Cidade = cidade,
                CodigoPostal = codigoPostal,
                Estado = estado,
                Pais = pais,
                TipoEndereco = TipoEndereco.Residencial,
                Linha01 = linha01,
                Linha02 = linha02,
            });
            return legoozer;
        }

        private static Montagem GravarMontagem(string legooZerID, string descricaoPassoAPasso, string imagemFinal, List<ItemMontagem> itens)
        {
            LegooZer legoozer;
            using (var repositorio = new RepositorioLegooZer(new SGALContext()))
            {
                legoozer = repositorio.Recuperar(int.Parse(legooZerID));
            }

            var montagem = new Montagem()
            {
                LegooZer = legoozer,
                DataCriacao = new DateTimeOffset(),
                DescricaoPassoAPasso = descricaoPassoAPasso,
                ImagemFinal = Image.FromFile(imagemFinal)
            };
            foreach (ItemMontagem item in itens)
            {
                montagem.Itens.Add(item);
            }
            return montagem;
        }

        private static void LocalizarMontagem()
        {
            string descricao;

            LerDoTeclado("Descrição...............:", out descricao);

            Console.Clear();
            Console.WriteLine("================================================================================");
            Console.WriteLine("|Id        |Data        |Passo a Passo                                         |");
            using (var context = new SGALContext())
            {
                var montagems = context.RecuperarMontagemParaApresentacao();
                foreach (var montagem in montagems)
                {
                    if (montagem.DescricaoPassoAPasso.ToUpper().Contains(descricao.ToUpper()))
                    {
                        Console.WriteLine("|{0,10}|{1,12}|{2,24}|",
                            montagem.MontagemID,
                            montagem.DataCriacao.ToString("dd/MM/yyyy"),
                            montagem.DescricaoPassoAPasso);
                    }
                }
            }
            Console.WriteLine("================================================================================");
        }

        private static void CriarComentario()
        {
            string textocomentario, montagemId;

            LerDoTeclado("IdMontagem....................:", out montagemId);

            var montagem = BuscarMontagem(int.Parse(montagemId));

            Console.WriteLine("");

            LerDoTeclado("Comentario.:", out textocomentario);

            using (var repositorio = new RepositorioMontagem(new SGALContext()))
            {
                var comentario = new Comentario()
                {
                    TextoComentario = textocomentario,
                    DataComentario = new DateTimeOffset(),
                };

                montagem.Comentarios.Add(comentario);

                repositorio.Inserir(montagem);
                repositorio.Salvar();
            }
        }

        private static void AvaliarMontagem()
        {
            string estrelas, montagemId;

            LerDoTeclado("IdMontagem....................:", out montagemId);

            var montagem = BuscarMontagem(int.Parse(montagemId));

            Console.WriteLine("");

            LerDoTeclado("Quantidade Estrelas (1-5):", out estrelas);

            using (var repositorio = new RepositorioMontagem(new SGALContext()))
            {
                var avaliacao = new Avaliacao()
                {
                    QuantidadeEstrelas = int.Parse(estrelas),
                    DataComentario = new DateTimeOffset(),
                };

                montagem.Avaliacoes.Add(avaliacao);

                repositorio.Inserir(montagem);
                repositorio.Salvar();
            }

        }

        private static Montagem BuscarMontagem(int montagemId)
        {
            using (var repositorio = new RepositorioMontagem(new SGALContext()))
            {
                return repositorio.Recuperar(montagemId);
            }
        }
    }
}
