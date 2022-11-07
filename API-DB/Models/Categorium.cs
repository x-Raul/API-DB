using System;
using System.Collections.Generic;

namespace API_DB.Models
{
    public partial class Categorium
    {
        public Categorium()
        {
            Productos = new HashSet<Producto>();
        }

        public int CatId { get; set; }
        public string CatNom { get; set; } = null!;
        public string? CatDesc { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
