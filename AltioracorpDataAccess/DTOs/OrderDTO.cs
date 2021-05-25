using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AltioracorpDataAccess.DTOs
{
    public class OrderDTO
    {
        public int IdOrder { get; set; }

        [Required(ErrorMessage = "El Cliente es requerido")]
        public int IdClient { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

        public ClientDTO Client { get; set; }

        
    }
}
