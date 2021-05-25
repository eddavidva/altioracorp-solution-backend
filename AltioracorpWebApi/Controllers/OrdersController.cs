using AltioracorpDataAccess;
using AltioracorpDataAccess.DTOs;
using AltioracorpDataAccess.Models;
using AltioracorpDataAccess.Repositories;
using AltioracorpDataAccess.Services;
using AltioracorpWebApi.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace AltioracorpWebApi.Controllers
{
    public class OrdersController : ApiController
    {
        private IMapper mapper;
        private ResponseMessage responseMessage;
        private object result;

        private readonly OrderService orderService = new OrderService(new OrderRepository(AltioracorpContext.Create()));

        public OrdersController()
        {
            this.mapper = WebApiApplication.MapperConfiguration.CreateMapper();
            this.responseMessage = new ResponseMessage();
        }

        public async Task<HttpResponseMessage> Get()
        {
            try
            {
                var orders = await orderService.GetAll();
                var ordersDTO = orders.Select(c => mapper.Map<OrderDTO>(c));

                result = responseMessage.OkMessage("Las Órdenes se han obtenido correctamente.", ordersDTO);
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                result = responseMessage.ErrorMessage("Hubo un error al momento de obtener las Órdenes, contáctese con el administrador.", ex);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, result);
            }
        }

        public async Task<HttpResponseMessage> Post([FromBody] OrderDTO orderDTO)
        {

            if (!ModelState.IsValid)
            {
                result = responseMessage.BadMessage("Verifique que los datos ingresados sean correctos");
                return Request.CreateResponse(HttpStatusCode.BadRequest, result);
            }

            try
            {
                var order = mapper.Map<Order>(orderDTO);
                order = await orderService.Create(order);

                result = responseMessage.OkMessage("La Orden se ha registrado correctamente.", order);
                return Request.CreateResponse(HttpStatusCode.OK, result);

            }
            catch (Exception ex)
            {
                result = responseMessage.ErrorMessage("Hubo un error al momento de registrar la Orden, contáctese con el administrador.", ex);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, result);
            }
        }

        public async Task<HttpResponseMessage> Put(int id, [FromBody] OrderDTO orderDTO)
        {
            if (!ModelState.IsValid)
            {
                result = responseMessage.BadMessage("Verifique que los datos ingresados sean correctos");
                return Request.CreateResponse(HttpStatusCode.BadRequest, result);
            }
            try
            {
                var orderDB = await orderService.GetById(id);
                if (orderDB == null)
                {
                    result = responseMessage.BadMessage("La Orden que desea actualizar no existe");
                    return Request.CreateResponse(HttpStatusCode.BadRequest, result);
                }

                var order = mapper.Map<Order>(orderDTO);
                order = await orderService.Update(order);

                result = responseMessage.OkMessage("La Orden se ha actualizado correctamente.", order);
                return Request.CreateResponse(HttpStatusCode.OK, result);

            }
            catch (Exception ex)
            {
                result = responseMessage.ErrorMessage("Hubo un error al momento de actualizar la Orden, contáctese con el administrador.", ex);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, result);
            }
        }

        public async Task<HttpResponseMessage> Delete(int id)
        {
            try
            {
                var order = await orderService.GetById(id);
                if (order == null)
                {
                    result = responseMessage.BadMessage("La Orden que desea eliminar no existe");
                    return Request.CreateResponse(HttpStatusCode.BadRequest, result);
                }

                await orderService.Delete(id);
                result = responseMessage.OkMessage("La Orden se ha eliminado correctamente.", order);
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                result = responseMessage.ErrorMessage("Hubo un error al momento de eliminar la Orden, contáctese con el administrador.", ex);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, result);
            }
        }
    }
}
