using Microsoft.EntityFrameworkCore;
using SistemaVentas.Dominio.Modelos;
using SistemaVentas.Dominio.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaVentas.Infraestructura.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly VentaDbContext _dbContext;

        public ClienteRepository(VentaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async ValueTask<IEnumerable<Cliente>> Consultar(string nombre)
        {
            var query = from a in _dbContext.Clientes
                        where nombre == null ||
                          string.Concat(a.Nombre, " ", a.Apellidos).Contains(nombre)
                        select a;

            return await query.ToListAsync();
        }

        public async Task<Cliente> ObtenerPorId(int id)
        {
            return await _dbContext.Clientes.FindAsync(id);
        }

        public async Task Crear(Cliente cliente)
        {
            await _dbContext.Clientes.AddAsync(cliente);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Actualizar(Cliente cliente)
        {
            _dbContext.Clientes.Update(cliente);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Eliminar(int id)
        {
            var cliente = await ObtenerPorId(id);
            if (cliente != null)
            {
                _dbContext.Clientes.Remove(cliente);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}

