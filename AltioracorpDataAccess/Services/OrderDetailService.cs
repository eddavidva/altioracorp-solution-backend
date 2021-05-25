using AltioracorpDataAccess.Interfaces.Repositories;
using AltioracorpDataAccess.Interfaces.Services;
using AltioracorpDataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AltioracorpDataAccess.Services
{
    public class OrderDetailService : GenericService<OrderDetail>, IOrderDetailService
    {
        private IOrderDetailRepository orderDetailRepository;
        public OrderDetailService(IOrderDetailRepository orderDetailRepository): base(orderDetailRepository)
        {
            this.orderDetailRepository = orderDetailRepository;
        }

        public Task<IEnumerable<OrderDetail>> GetByOrder(int idOrder)
        {
            return orderDetailRepository.GetByOrder(idOrder);
            // throw new System.NotImplementedException();
        }

        public async Task DeleteByOrder(int idOrder)
        {
            await orderDetailRepository.DeleteByOrder(idOrder);
        }
    }
}
