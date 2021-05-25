using AltioracorpDataAccess;
using AltioracorpDataAccess.DTOs;
using AltioracorpDataAccess.Models;
using AltioracorpDataAccess.Repositories;
using AltioracorpDataAccess.Services;
using AltioracorpWebApi.Models;
using AutoMapper;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace AltioracorpWebApi.Controllers
{
    public class ProductsController : ApiController
    {
        private IMapper mapper;
        private ResponseMessage responseMessage;
        private object result;

        private readonly ProductService productService = new ProductService(new ProductRepository(AltioracorpContext.Create()));

        public ProductsController()
        {
            this.mapper = WebApiApplication.MapperConfiguration.CreateMapper();
            this.responseMessage = new ResponseMessage();
        }

        public async Task<HttpResponseMessage> Get()
        {
            try
            {
                var products = await productService.GetAll();
                var productsDTO = products.Select(c => mapper.Map<ProductDTO>(c));

                result = responseMessage.OkMessage("Los Productos se han obtenido correctamente.", productsDTO);
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                result = responseMessage.ErrorMessage("Hubo un error al momento de obtener los Productos, contáctese con el administrador.", ex);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, result);
            }
        }

        public async Task<HttpResponseMessage> Post([FromBody] ProductDTO productDTO)
        {

            if (!ModelState.IsValid)
            {
                result = responseMessage.BadMessage("Verifique que los datos ingresados sean correctos");
                return Request.CreateResponse(HttpStatusCode.BadRequest, result);
            }

            try
            {

                var product = mapper.Map<Product>(productDTO);
                product = await productService.Create(product);

                result = responseMessage.OkMessage("El Productos se ha registrado correctamente.", product);
                return Request.CreateResponse(HttpStatusCode.OK, result);

            }
            catch (Exception ex)
            {
                result = responseMessage.ErrorMessage("Hubo un error al momento de registrar el Producto, contáctese con el administrador.", ex);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, result);
            }
        }
    }
}
