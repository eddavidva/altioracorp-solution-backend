using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AltioracorpDataAccess.Models
{
    // REFERECIA TABLA PRODUCTS
    [Table("Products", Schema="dbo")]
    public class Product
    {
        // SET PROPIEDADES DE LA TABLA
        [Key]
        public int IdProduct { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public int Stock { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

        // RELACIÓN DE UNO - VARIOS
        public virtual ICollection<OrderDetail> OrdersDetails { get; set; }
    }
}
