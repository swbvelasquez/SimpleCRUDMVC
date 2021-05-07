using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MarketMVC.Models
{
    public class NuevoProductoVM
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name="Nombre")]
        public string Nombre { get; set; }
        public decimal? Precio { get; set; }
        public int? Stock { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Caducidad")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? FechaExpiracion { get; set; }

        public NuevoProductoVM() { }
    }
}