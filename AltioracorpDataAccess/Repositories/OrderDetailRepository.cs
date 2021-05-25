using AltioracorpDataAccess.Interfaces.Repositories;
using AltioracorpDataAccess.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace AltioracorpDataAccess.Repositories
{
    public class OrderDetailRepository : GenericRepository<OrderDetail>, IOrderDetailRepository
    {
        private readonly AltioracorpContext db;
        public OrderDetailRepository(AltioracorpContext db) : base(db)
        {
            this.db = db;
        }

       

        public async Task<IEnumerable<OrderDetail>> GetByOrder(int idOrder)
        {
            string sql = "SELECT * FROM OrdersDetail WHERE IdOrder = " + idOrder + ";";

            return await db.Database.SqlQuery<OrderDetail>(sql).ToListAsync();
            // return await db.SqlQuery<OrderDetail>(sql).ToListAsync();
            // return await db.Set<OrderDetail>().ToListAsync();
        }

        public async Task DeleteByOrder(int idOrder)
        {
            db.OrderDetails.RemoveRange(db.OrderDetails.Where(x => x.IdOrder == idOrder));
            await db.SaveChangesAsync();
        }

    }
}
