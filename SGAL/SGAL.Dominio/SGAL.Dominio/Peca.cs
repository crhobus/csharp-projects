using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;

namespace SGAL.Dominio
{
    public class Peca : Entidade
    {
        public Peca() : this(0)
        { }

        public Peca(int pecaID)
        {
            this.PecaID = pecaID;
        }

        public int PecaID { get; private set; }
        public string Descricao { get; set; }
        public byte[] ByteArrayImage { get; set; }
        [NotMapped]
        public Image Imagem
        {
            get
            {
                if (ByteArrayImage != null)
                    return ByteArrayToImage(ByteArrayImage);
                else
                    return null;
            }
            set
            {
                if (value != null)
                    ByteArrayImage = ImageToByteArray(value);
                else
                    ByteArrayImage = null;
            }
        }

        private Image ByteArrayToImage(byte[] byteArrayIn)
        {
            Image returnImage = null;
            using (MemoryStream ms = new MemoryStream(byteArrayIn))
            {
                returnImage = Image.FromStream(ms);
            }
            return returnImage;
        }

        private byte[] ImageToByteArray(Image imageIn)
        {
            MemoryStream ms = new MemoryStream();            
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }

        protected override bool Validar()
        {
            return !string.IsNullOrWhiteSpace(Descricao)
                && Imagem != null;
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", this.PecaID, this.Descricao);
        }
    }
}
