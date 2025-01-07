using SistemaVentas.Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVentas.Dominio.Repositories
{
    public interface IProductoRepository
    {
        public ValueTask<IEnumerable<Producto>> Consultar(string nombre);
        public ValueTask<Producto> ConsultarById(int IdProducto);
        public ValueTask<bool> Registrar(Producto entidad);
        public ValueTask<bool> Modificar(Producto entidad);
        public ValueTask<bool> Eliminar(int IdProducto);
    }
}
