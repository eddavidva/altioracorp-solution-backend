using AltioracorpDataAccess.Interfaces.Repositories;
using AltioracorpDataAccess.Interfaces.Services;
using AltioracorpDataAccess.Models;

namespace AltioracorpDataAccess.Services
{
    public class OrderService: GenericService<Order>, IOrderService
    {
        public OrderService(IOrderRepository orderRepository) : base (orderRepository)
        {

        }
    }
}
