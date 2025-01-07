using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVentas.Infraestructura.Commom
{
    public class AppConfiguracion : IAppConfiguracion
    {
        private readonly IDictionary<string, string> _parametros;
        public AppConfiguracion() {
            _parametros= new Dictionary<string, string>();
            _parametros.Add("NombreEmpresa", "Empresa XYZ");
            _parametros.Add("DireccionEmpresa", "Direccion 123456");
        }

        public IDictionary<string, string> GetParametros()
        {
            return _parametros;
        }
    }
}
