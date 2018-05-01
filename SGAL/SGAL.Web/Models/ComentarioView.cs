using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SGAL.Web.Models
{
    public class ComentarioView
    {
        public ComentarioView() : this(0)
        { }

        public ComentarioView(int comentarioID)
        {
            this.ComentarioID = comentarioID;
        }

        public int ComentarioID { get; set; }
        public string TextoComentario { get; set; }
        public DateTimeOffset DataComentario { get; set; }

    }
}