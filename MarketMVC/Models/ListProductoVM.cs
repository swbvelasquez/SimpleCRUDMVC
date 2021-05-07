using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarketMVC.Models
{
    public class ListProductoVM
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal? Precio { get; set; }
        public int? Stock { get; set; }
        public DateTime? FechaExpiracion { get; set; }

        public ListProductoVM() { }
    }
}