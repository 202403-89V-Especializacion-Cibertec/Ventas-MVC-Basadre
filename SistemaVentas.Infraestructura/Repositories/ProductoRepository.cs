using SistemaVentas.Dominio.Modelos;
using SistemaVentas.Dominio.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVentas.Infraestructura.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        public ValueTask<IEnumerable<Producto>> Consultar(string nombre)
        {
            throw new NotImplementedException();
        }

        public ValueTask<Producto> ConsultarById(int IdProducto)
        {
            throw new NotImplementedException();
        }

        public ValueTask<bool> Eliminar(int IdProducto)
        {
            throw new NotImplementedException();
        }

        public ValueTask<bool> Modificar(Producto entidad)
        {
            throw new NotImplementedException();
        }

        public ValueTask<bool> Registrar(Producto entidad)
        {
            throw new NotImplementedException();
        }
    }
}
