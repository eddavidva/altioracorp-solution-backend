using AltioracorpDataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AltioracorpDataAccess.Interfaces.Services
{
    public interface IOrderDetailService : IGenericService<OrderDetail>
    {
        Task<IEnumerable<OrderDetail>> GetByOrder(int idOrder);
        Task DeleteByOrder(int idOrder);
    }
}
