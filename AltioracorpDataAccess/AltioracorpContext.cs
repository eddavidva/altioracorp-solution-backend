using AltioracorpDataAccess.Models;
using System.Data.Entity;

namespace AltioracorpDataAccess
{
    public class AltioracorpContext : DbContext
    {
        // private static AltioracorpContext altioracorpContext = null;
        // CONEXIÓN A LA BD
        public AltioracorpContext() : base("AltioracorpContext")
        {

        }

        // MAPEO DE MODELS (ENTITIES)
        public DbSet<Client> Clients { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }


        // PATRÓN SINGLETON
        public static AltioracorpContext Create() {
            
            return new AltioracorpContext();
        }
    }
}
