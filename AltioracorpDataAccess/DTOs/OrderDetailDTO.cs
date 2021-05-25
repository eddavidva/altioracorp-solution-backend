using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltioracorpDataAccess.DTOs
{
    public class OrderDetailDTO
    {
        public int IdOrderDetail { get; set; }
        public int IdOrder { get; set; }
        public int IdProduct { get; set; }
        public double Amount { get; set; }
        public double Total { get; set; }
        
        public OrderDTO Order { get; set; }
        public ProductDTO Product { get; set; }
    }
}
