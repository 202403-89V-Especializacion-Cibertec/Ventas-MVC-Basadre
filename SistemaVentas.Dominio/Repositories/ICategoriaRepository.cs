using SistemaVentas.Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVentas.Dominio.Repositories
{
    public interface ICategoriaRepository
    {
        public ValueTask<IEnumerable<Categoria>> Consultar();
        public ValueTask<Categoria> ConsultarById(int idCategoria);
        public ValueTask<bool> Registrar(Categoria entidad);
        public ValueTask<bool> Modificar(Categoria entidad);

        public ValueTask<bool> Eliminar(int idCategoria);


    }
}
