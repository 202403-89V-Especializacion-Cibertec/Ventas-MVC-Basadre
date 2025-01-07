using Microsoft.EntityFrameworkCore;
using SistemaVentas.Dominio.Modelos;
using SistemaVentas.Dominio.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVentas.Infraestructura.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly VentaDbContext _dbContext;
        public CategoriaRepository(VentaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async  ValueTask<IEnumerable<Categoria>> Consultar()
        {
            return await _dbContext.Categorias.ToListAsync();
        }

        public async ValueTask<Categoria> ConsultarById(int idCategoria)
        {
            return await _dbContext.Categorias.FindAsync(idCategoria);
        }

        public async ValueTask<bool> Eliminar(int idCategoria)
        {
            _dbContext.Categorias.Remove(new Categoria { IdCategoria = idCategoria });
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async ValueTask<bool> Modificar(Categoria entidad)
        {
            _dbContext.Categorias.Update(entidad);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async ValueTask<bool> Registrar(Categoria entidad)
        {
            _dbContext.Categorias.Add(entidad);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
