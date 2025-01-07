using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using SistemaVentas.Infraestructura.Commom;

namespace SistemaVentas.Web.MVC.Controllers
{
    [Route("configuracion")]
    public class AppConfiguracionController : Controller
    {
        private readonly IAppConfiguracion _appConfiguracion;
        public AppConfiguracionController(IAppConfiguracion appConfiguracion)
        {
            _appConfiguracion = appConfiguracion;
        }

        [HttpGet("obtener")] ///http://<host>/configuracion/obtener
        public IActionResult GetConfiguracion()
        {
            return Json(_appConfiguracion.GetParametros());
        }



    }
}
