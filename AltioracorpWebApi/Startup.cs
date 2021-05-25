using AltioracorpDataAccess;
using Microsoft.Owin;
using Owin;
using System;
using System.Threading.Tasks;

[assembly: OwinStartup(typeof(AltioracorpWebApi.Startup))]

namespace AltioracorpWebApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // CONFIGURA EL CONTEXTO DE LA INSTANCIA PARA UTILIZAR SINGLETON EN EL REQUEST
            app.CreatePerOwinContext(AltioracorpContext.Create);
        }
    }
}
