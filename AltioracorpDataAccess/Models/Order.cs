using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AltioracorpDataAccess.Models
{
    // REFERENCIA TABLA ORDERS
    [Table("Orders", Schema="dbo")]
    public class Order
    {
        // SET PROPIEDADES DE LA TABLA
        [Key]
        public int IdOrder { get; set; }
        [ForeignKey("Client")]
        public int IdClient { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

        // REFERENCIA FOREIGN KEY A TABLA CLIENTES
        public virtual Client Client { get; set; }

        // RELACIÓN DE UNO - VARIOS
        public virtual ICollection<OrderDetail> OrdersDetails { get; set; }
    }
}
