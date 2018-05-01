using System;

namespace SGAL.Dominio
{
    public class Endereco : Entidade
    {
        public Endereco() : this(0)
        { }

        public Endereco(int enderecoID)
        {
            this.EnderecoID = enderecoID;
        }

        public int EnderecoID { get; set; }
        public TipoEndereco TipoEndereco { get; set; }
        public string Linha01 { get; set; }
        public string Linha02 { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string CodigoPostal { get; set; }
        public string Pais { get; set; }

        protected override bool Validar()
        {
            return (int)TipoEndereco != 0
                && !string.IsNullOrWhiteSpace(Linha01)
                && !string.IsNullOrWhiteSpace(Linha02)
                && !string.IsNullOrWhiteSpace(Cidade)
                && !string.IsNullOrWhiteSpace(Estado)
                && !string.IsNullOrWhiteSpace(CodigoPostal)
                && !string.IsNullOrWhiteSpace(Pais);
        }

        public override string ToString()
        {
            return string.Format("{0} {1} - {2} - {3} CEP: {4} - {5}", Linha01, Linha02, Cidade, Estado, CodigoPostal, Pais);
        }
    }
}