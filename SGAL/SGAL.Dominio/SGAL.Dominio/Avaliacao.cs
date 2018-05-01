using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGAL.Dominio
{
    public class Avaliacao : Entidade
    {
        public int AvaliacaoID { get; private set; }
        public DateTimeOffset DataComentario { get; set; }
        public int QuantidadeEstrelas { get; set; }

        protected override bool Validar()
        {
            return !string.IsNullOrEmpty(DataComentario.ToString())
                && !string.IsNullOrWhiteSpace(QuantidadeEstrelas.ToString());
        }
    }
}
