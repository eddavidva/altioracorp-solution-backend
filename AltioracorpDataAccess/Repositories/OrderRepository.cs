using AltioracorpDataAccess.Interfaces.Repositories;
using AltioracorpDataAccess.Models;

namespace AltioracorpDataAccess.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(AltioracorpContext db) : base (db)
        {

        }
    }
}
