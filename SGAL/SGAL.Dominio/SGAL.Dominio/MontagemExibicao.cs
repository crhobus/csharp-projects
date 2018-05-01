using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGAL.Dominio
{
    public class MontagemExibicao
    {
        public string Nome { get; set; }

        public string SobreNome { get; set; }

        public DateTimeOffset? DataMontagem { get; set; }

        public List<ItemMontagemExibicao> ItensMontagemExibicao { get; set; }

        public List<ComentarioExibicao> ComentariosMontagemExibicao { get; set; }

        public int MontagemID { get; set; }

        public string DescricaoPassoAPasso { get; set; }
    }
}
