using System.Web.Http;
using AltioracorpDataAccess.DTOs;
using AutoMapper;

namespace AltioracorpWebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        internal static MapperConfiguration MapperConfiguration { get; set; }
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            // LLAMAR LA CONFIGURACIÓN DEL AUTOMAPPER
            MapperConfiguration = AutoMapperConfig.MapperConfiguration();
        }
    }
}
