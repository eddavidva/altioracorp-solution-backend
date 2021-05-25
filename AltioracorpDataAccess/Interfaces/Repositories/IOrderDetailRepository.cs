using AltioracorpDataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AltioracorpDataAccess.Interfaces.Repositories
{
    public interface IOrderDetailRepository : IGenericRepository<OrderDetail>
    {
        Task<IEnumerable<OrderDetail>> GetByOrder(int idOrder);

        Task DeleteByOrder(int idOrder);
    }
}

