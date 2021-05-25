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
    public class OrdersDetailController : ApiController
    {
        private IMapper mapper;
        private ResponseMessage responseMessage;
        private object result;

        private readonly OrderDetailService orderDetailService = new OrderDetailService(new OrderDetailRepository(AltioracorpContext.Create()));

        public OrdersDetailController()
        {
            this.mapper = WebApiApplication.MapperConfiguration.CreateMapper();
            this.responseMessage = new ResponseMessage();
        }

        public async Task<HttpResponseMessage> Get()
        {
            try
            {
                var ordersDetail = await orderDetailService.GetAll();
                var ordersDetailDTO = ordersDetail.Select(c => mapper.Map<OrderDetailDTO>(c));

                result = responseMessage.OkMessage("El Detalle  se ha obtenido correctamente.", ordersDetailDTO);
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                result = responseMessage.ErrorMessage("Hubo un error al momento de obtener el Detalle, contáctese con el administrador.", ex);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, result);
            }

        }

        [HttpGet]
        [ActionName("Order")]
        public async Task<HttpResponseMessage> GetByOder(int id)
        {
            try
            {
                var ordersDetail = await orderDetailService.GetByOrder(id);
                var ordersDetailDTO = ordersDetail.Select(c => mapper.Map<OrderDetailDTO>(c));

                result = responseMessage.OkMessage("El Detalle de la Orden se ha obtenido correctamente.", ordersDetailDTO);
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                result = responseMessage.ErrorMessage("Hubo un error al momento de obtener el Detalle de la Orden, contáctese con el administrador.", ex);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, result);
            }

        }
        public async Task<HttpResponseMessage> Get(int id)
        {
            try
            {
                var orderDetail = await orderDetailService.GetById(id);
                if (orderDetail == null)
                {
                    result = responseMessage.BadMessage("El Detalle que desea actualizar no existe");
                    return Request.CreateResponse(HttpStatusCode.BadRequest, result);
                }

                var orderDetailDTO = mapper.Map<OrderDetailDTO>(orderDetail);

                result = responseMessage.OkMessage("EL Detalle se ha obtenido correctamente.", orderDetailDTO);
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                result = responseMessage.ErrorMessage("Hubo un error al momento de obtener el Detalle, contáctese con el administrador.", ex);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, result);
            }

        }

        public async Task<HttpResponseMessage> Post([FromBody] OrderDetailDTO orderDetailDTO)
        {

            if (!ModelState.IsValid)
            {
                result = responseMessage.BadMessage("Verifique que los datos ingresados sean correctos");
                return Request.CreateResponse(HttpStatusCode.BadRequest, result);
            }

            try
            {

                var orderDetail = mapper.Map<OrderDetail>(orderDetailDTO);
                orderDetail = await orderDetailService.Create(orderDetail);

                result = responseMessage.OkMessage("El Detalle se ha registrado correctamente.", orderDetail);
                return Request.CreateResponse(HttpStatusCode.OK, result);

            }
            catch (Exception ex)
            {
                result = responseMessage.ErrorMessage("Hubo un error al momento de registrar el Detalle, contáctese con el administrador.", ex);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, result);
            }
        }

        public async Task<HttpResponseMessage> Put(int id, [FromBody] OrderDetailDTO orderDetailDTO)
        {
            if (!ModelState.IsValid)
            {
                result = responseMessage.BadMessage("Verifique que los datos ingresados sean correctos");
                return Request.CreateResponse(HttpStatusCode.BadRequest, result);
            }
            try
            {
                var orderDetailDB = await orderDetailService.GetById(id);
                if (orderDetailDB == null)
                {
                    result = responseMessage.BadMessage("El Detalle que desea actualizar no existe");
                    return Request.CreateResponse(HttpStatusCode.BadRequest, result);
                }

                var orderDetail = mapper.Map<OrderDetail>(orderDetailDTO);
                orderDetail = await orderDetailService.Update(orderDetail);

                result = responseMessage.OkMessage("El Detalle se ha actualizado correctamente.", orderDetail);
                return Request.CreateResponse(HttpStatusCode.OK, result);

            }
            catch (Exception ex)
            {
                result = responseMessage.ErrorMessage("Hubo un error al momento de actualizar el Detalle, contáctese con el administrador.", ex);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, result);
            }
        }

        [HttpDelete]
        [ActionName("Order")]
        public async Task<HttpResponseMessage> DeleteByOder(int id)
        {
            /*result = responseMessage.OkMessage("El Detalle de la Orden se ha eliminado correctamente.", null);
            return Request.CreateResponse(HttpStatusCode.OK, result);*/

            try
            {
                await orderDetailService.DeleteByOrder(id);
                result = responseMessage.OkMessage("El Detalle de la Orden se ha eliminado correctamente.", null);
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                result = responseMessage.ErrorMessage("Hubo un error al momento de eliminar los Detalle de la Orden, contáctese con el administrador.", ex);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, result);
            }
        }


        public async Task<HttpResponseMessage> Delete(int id)
        {
            try
            {
                var orderDetail = await orderDetailService.GetById(id);
                if (orderDetail == null)
                {
                    result = responseMessage.BadMessage("El Detalle que desea eliminar no existe");
                    return Request.CreateResponse(HttpStatusCode.BadRequest, result);
                }

                await orderDetailService.Delete(id);
                result = responseMessage.OkMessage("El Detalle se ha eliminado correctamente.", orderDetail);
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                result = responseMessage.ErrorMessage("Hubo un error al momento de eliminar el Detalle, contáctese con el administrador.", ex);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, result);
            }
        }

    }
}
