using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AltioracorpDataAccess.Models
{
    [Table("OrdersDetail", Schema="dbo")]
    public class OrderDetail
    {
        [Key]
        public int IdOrderDetail { get; set; }

        [ForeignKey("Order")]
        public int IdOrder { get; set; }

        [ForeignKey("Product")]
        public int IdProduct { get; set; }
        public double Amount { get; set; }
        public double Total { get; set; }

        // REFERENCIA FOREIGN KEY A TABLA ORDERS
        public virtual Order Order { get; set; }

        // REFERENCIA FOREIGN KEY A TABLA PRODUCTS
        public virtual Product Product { get; set; }
    }
}
