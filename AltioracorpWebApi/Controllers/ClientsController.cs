using AltioracorpDataAccess;
using AltioracorpDataAccess.DTOs;
using AltioracorpDataAccess.Repositories;
using AltioracorpDataAccess.Services;
using AutoMapper;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using AltioracorpWebApi.Models;
using AltioracorpDataAccess.Models;

namespace AltioracorpWebApi.Controllers
{
    // [RoutePrefix("api/clients")]
    public class ClientsController : ApiController
    {
        private readonly IMapper mapper;
        private readonly ResponseMessage responseMessage;
        private object result;

        private readonly ClientService clientService = new ClientService(new ClientRepository(AltioracorpContext.Create()));

        public ClientsController()
        {
            this.mapper = WebApiApplication.MapperConfiguration.CreateMapper();
            this.responseMessage = new ResponseMessage();
        }

        // [HttpGet]
        // [Route("get-all")]
        public async Task<HttpResponseMessage> Get()
        {
            try
            {
                var clients = await clientService.GetAll();
                var clientsDTO = clients.Select(c => mapper.Map<ClientDTO>(c));

                result = responseMessage.OkMessage("Los Clientes se han obtenido correctamente.", clientsDTO);
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                result = responseMessage.ErrorMessage("Hubo un error al momento de obtener los Clientes, contáctese con el administrador.", ex);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, result);
            }

        }

        public async Task<HttpResponseMessage> Post([FromBody] ClientDTO clientDTO)
        {

            if (!ModelState.IsValid)
            {
                result = responseMessage.BadMessage("Verifique que los datos ingresados sean correctos");
                return Request.CreateResponse(HttpStatusCode.BadRequest, result);
            }

            try
            {
                var client = mapper.Map<Client>(clientDTO);
                client = await clientService.Create(client);

                result = responseMessage.OkMessage("El Cliente se ha registrado correctamente.", client);
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                result = responseMessage.ErrorMessage("Hubo un error al momento de registrar el Cliente, contáctese con el administrador.", ex);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, result);
            }
        }
    }
}
