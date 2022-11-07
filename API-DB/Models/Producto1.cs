using System;
using System.Collections.Generic;

namespace API_DB.Models
{
    public class Producto1
    {
        public int ProdId { get; set; }
        public string ProdNom { get; set; } = null!;
        public string? ProdDesc { get; set; }
        public int CatFk { get; set; }

        public string Cat_nom { get; set; }

        //public virtual Categorium CatFkNavigation { get; set; } = null!;
    }
}
