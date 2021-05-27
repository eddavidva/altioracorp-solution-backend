using System;
using System.ComponentModel.DataAnnotations;

namespace AltioracorpDataAccess.DTOs
{
    public class ProductDTO
    {
        public int IdProduct { get; set; }
        [Required(ErrorMessage = "El código del producto es requerido")]
        public string Code { get; set; }
        [Required(ErrorMessage = "El nombre del producto es requerido")]
        public string Name { get; set; }
        [Required(ErrorMessage = "El precio del producto es requerido")]
        public double Price { get; set; }
        public int Stock { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
