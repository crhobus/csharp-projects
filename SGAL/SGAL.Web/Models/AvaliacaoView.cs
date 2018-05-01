using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SGAL.Web.Models
{
    public class AvaliacaoView
    {
        public AvaliacaoView() : this(0)
        { }

        public AvaliacaoView(int avaliacaoID)
        {
            this.AvaliacaoID = avaliacaoID;
        }

        public int AvaliacaoID { get; set; }

        [Required(ErrorMessage = "A Quantidade de Estrelas deve ser informada!")]
        [Display(Name = "Quantidade de Estrelas")]
        [Range(1, 5)]
        public int QuantidadeEstrelas { get; set; }
        public DateTimeOffset DataComentario { get; set; }

    }
}