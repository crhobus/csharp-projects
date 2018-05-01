using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGAL.Dominio
{
    public class EnderecoDeEmailInvalidoException : Exception
    {
        public EnderecoDeEmailInvalidoException() : base("Endereço de email inválido")
        { }
    }
}
