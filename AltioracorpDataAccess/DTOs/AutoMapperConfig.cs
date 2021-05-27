using AutoMapper;
using AltioracorpDataAccess.Models;

namespace AltioracorpDataAccess.DTOs
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration MapperConfiguration()
        {
            return new MapperConfiguration(config => {

                // MAPEO AUTOMÁTICO DE LOS MODELO Y DE LOS DTOs 
                config.CreateMap<Client, ClientDTO>();
                config.CreateMap<ClientDTO, Client>();

                config.CreateMap<Order, OrderDTO>();
                config.CreateMap<OrderDTO, Order>();

                config.CreateMap<Product, ProductDTO>();
                config.CreateMap<ProductDTO, Product>();

                config.CreateMap<OrderDetail, OrderDetailDTO>();
                config.CreateMap<OrderDetailDTO, OrderDetail>();

            });
        }
    }
}
