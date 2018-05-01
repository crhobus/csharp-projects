using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGAL.Dominio
{
    public class LegooZer : Entidade
    {
        public LegooZer() : this(0)
        { }

        public LegooZer(int legoozerID)
        {
            this.LegooZerID = legoozerID;
            Enderecos = new List<Endereco>();
        }

        private string enderecoEmail;

        public int LegooZerID { get; private set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public List<Endereco> Enderecos { get; private set; }
        public string EnderecoEmail
        {
            get
            {
                return enderecoEmail;
            }
            set
            {
                RegexUtilities utilities = new RegexUtilities();
                if (!utilities.IsValidEmail(value))
                    throw new EnderecoDeEmailInvalidoException();

                this.enderecoEmail = value;
            }
        }

        public string NomeCompleto
        {
            get
            {
                string separador = !string.IsNullOrWhiteSpace(Nome)
                    && !string.IsNullOrWhiteSpace(SobreNome)
                    ? ", "
                    : string.Empty;
                return string.Format("{0}{1}{2}", SobreNome, separador, Nome);
            }
        }

        protected override bool Validar()
        {
            return !string.IsNullOrWhiteSpace(EnderecoEmail)
                && !string.IsNullOrWhiteSpace(SobreNome);
        }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(this.EnderecoEmail))

                return string.Format("{0}", this.NomeCompleto);

            return string.Format("{0} ({1})", this.NomeCompleto, this.EnderecoEmail);
        }
    }
}
