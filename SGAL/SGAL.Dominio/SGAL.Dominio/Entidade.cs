using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGAL.Dominio
{
    public enum EstadoEntidade
    {
        Ativo,
        Excluido
    }

    public abstract class Entidade
    {
        public bool Nova { get; private set; }
        public bool TemAlteracoes { get; private set; }
        public bool Valido
        {
            get
            {
                return Validar();
            }
        }
        public EstadoEntidade EstadoEntidade { get; set; }

        protected abstract bool Validar();
    }
}
