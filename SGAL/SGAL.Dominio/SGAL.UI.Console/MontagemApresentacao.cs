using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGAL.UI.ConsoleX
{
    public class MontagemApresentacao
    {
        public MontagemApresentacao(int montagemID, DateTimeOffset dataCriacao, string descricaoPassoAPasso)
        {
            this.MontagemID = montagemID;
            this.DataCriacao = dataCriacao;
            this.DescricaoPassoAPasso = descricaoPassoAPasso;
        }

        public int MontagemID { get; private set; }
        public DateTimeOffset DataCriacao { get; private set; }
        public string DescricaoPassoAPasso { get; private set; }
    }
}