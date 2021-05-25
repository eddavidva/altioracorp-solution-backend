using AltioracorpDataAccess.Interfaces.Repositories;
using AltioracorpDataAccess.Models;

namespace AltioracorpDataAccess.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AltioracorpContext db) : base(db)
        {

        }
    }
}
