using System;
using System.Collections.Generic;

namespace API_DB.Models
{
    public partial class Producto
    {
        public int ProdId { get; set; }
        public string ProdNom { get; set; } = null!;
        public string? ProdDesc { get; set; }
        public int CatFk { get; set; }

        //public virtual Categorium CatFkNavigation { get; set; } = null!;
    }
}
