using AltioracorpDataAccess.Interfaces.Repositories;
using AltioracorpDataAccess.Interfaces.Services;
using AltioracorpDataAccess.Models;


namespace AltioracorpDataAccess.Services
{
    public class ProductService: GenericService<Product>, IProductService
    {
        public ProductService(IProductRepository productRepository): base(productRepository)
        {

        }
    }
}
