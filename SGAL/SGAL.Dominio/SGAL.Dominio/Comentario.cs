using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGAL.Dominio
{
    public class Comentario : Entidade
    {
        public int ComentarioID { get; private set; }
        public DateTimeOffset DataComentario { get; set; }
        public string TextoComentario { get; set; }

        protected override bool Validar()
        {
            return !string.IsNullOrEmpty(DataComentario.ToString())
                && !string.IsNullOrWhiteSpace(TextoComentario);
        }
    }
}
