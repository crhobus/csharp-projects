using SGAL.AcessoDados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGAL.UI.ConsoleX
{
    public static class SGALContextExtensao
    {
        public static IEnumerable<LegooZerApresentacao> RecuperarParaApresentacao(this SGALContext context)
        {
            var legooZersComEndereco = from legoozer in context.LegooZers.Include("Enderecos")
                                       select legoozer;

            return from legoozer in legooZersComEndereco.AsEnumerable()
                   select new LegooZerApresentacao(legoozer.LegooZerID, legoozer.NomeCompleto, legoozer.EnderecoEmail, legoozer.Enderecos[0].Cidade);
        }

        public static IEnumerable<MontagemApresentacao> RecuperarMontagemParaApresentacao(this SGALContext context)
        {
            var montagens = from montagem in context.Montagens.Include("Comentarios")
                            select montagem;

            return from montagem in montagens.AsEnumerable()
                   select new MontagemApresentacao(montagem.MontagemID, montagem.DataCriacao, montagem.DescricaoPassoAPasso);
        }
    }
}
