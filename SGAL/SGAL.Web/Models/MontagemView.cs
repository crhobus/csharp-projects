using SGAL.Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SGAL.Web.Models
{
    public class MontagemView
    {
        public MontagemView() : this(0)
        { }

        public MontagemView(int MontagemID)
        {
            this.MontagemID = MontagemID;
        }

        public int MontagemID { get; private set; }
        [Display(Name = "LegooZer")]
        [Required(ErrorMessage = "LegooZer deve ser informado!")]
        public int LegooZerID { get; set; }
        [Display(Name = "Passo a Passo")]
        [Required(ErrorMessage = "Descrição do Passo a Passo deve ser informada!")]
        public string DescricaoPassoAPasso { get; set; }
        [DataType(DataType.Upload)]
        public HttpPostedFileBase ImagemFinal { get; set; }
    }
}