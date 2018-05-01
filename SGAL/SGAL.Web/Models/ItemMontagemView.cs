using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SGAL.Web.Models
{
    public class ItemMontagemView
    {
        public ItemMontagemView() : this(0)
        { }

        public ItemMontagemView(int itemMontagemID)
        {
            this.ItemMontagemID = itemMontagemID;
        }

        public int ItemMontagemID { get; private set; }
        public int PecaID { get; set; }
        public int Quantidade { get; set; }
    }
}