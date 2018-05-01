using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Web;

namespace SGAL.Web.Models
{
    public class PecaView
    {
        public PecaView() : this(0)
        { }

        public PecaView(int pecaID)
        {
            this.PecaID = pecaID;
        }

        public int PecaID { get; set; }

        [Required(ErrorMessage = "Descrição deve ser informada!")]
        [Display(Name = "Descricao")]
        public string Descricao { get; set; }
        [DataType(DataType.Upload)]
        [Required(ErrorMessage = "Imagem deve ser informada!")]
        public HttpPostedFileBase Imagem { get; set; }
    }
}