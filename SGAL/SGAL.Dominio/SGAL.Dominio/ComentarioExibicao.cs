using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGAL.Dominio
{
    public class ComentarioExibicao
    {

        public int ComentarioID { get; set; }
        public DateTimeOffset DataComentario { get; set; }
        public string TextoComentario { get; set; }

    }
}
