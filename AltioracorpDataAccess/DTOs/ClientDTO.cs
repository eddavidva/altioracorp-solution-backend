using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AltioracorpDataAccess.DTOs
{
    public class ClientDTO
    {
        public int IdClient { get; set; }

        [Required(ErrorMessage = "El nombre del cliente es requerido")]
        public string FirstName { get; set; }
        
        [Required(ErrorMessage = "El apellido del cliente es requerido")]
        public string LastName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

        public string FullName
        {
            get { return string.Format("{0} {1}", FirstName, LastName); }
        }
    }
}
