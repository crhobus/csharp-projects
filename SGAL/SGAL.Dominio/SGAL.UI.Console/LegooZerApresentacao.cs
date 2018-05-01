using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGAL.UI.ConsoleX
{
    public class LegooZerApresentacao
    {
        public LegooZerApresentacao(int LegooZerID, string nomeCompleto, string enderecoEmail, string cidade)
        {
            this.LegooZerID = LegooZerID;
            this.NomeCompleto = nomeCompleto;
            this.EnderecoEmail = enderecoEmail;
            this.Cidade = cidade;
        }

        public int LegooZerID { get; private set; }
        public string NomeCompleto { get; private set; }
        public string EnderecoEmail { get; private set; }
        public string Cidade { get; private set; }
    }
}
