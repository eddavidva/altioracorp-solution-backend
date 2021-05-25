using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AltioracorpDataAccess.Models
{
    // REFERENCIA TABLA CLIENTS
    [Table("Clients", Schema = "dbo")]
    public class Client
    {
        // SET PROPIEDADES DE LA TABLA
        [Key]
        public int IdClient { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

        // REALACIÓN DE UNO A VARIOS (CLIENT - ORDERS)
        public virtual ICollection<Order> Orders { get; set; }
    }
}
