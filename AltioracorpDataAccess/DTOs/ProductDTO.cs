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
        public double Price { get; set; }
        [Required(ErrorMessage = "El precio del producto es requerido")]
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
