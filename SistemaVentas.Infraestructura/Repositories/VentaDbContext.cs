using Microsoft.EntityFrameworkCore;
using SistemaVentas.Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVentas.Infraestructura.Repositories
{
    public class VentaDbContext:DbContext
    {

        public VentaDbContext(DbContextOptions options):base(options) { 
        
        
        } 

        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<Producto> Productos { get; set; }

        public DbSet<Cliente> Clientes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>(
                p=>
                {
                    p.ToTable("Categoria");
                    p.HasKey(campo => campo.IdCategoria);
                }

                );

            modelBuilder.Entity<Producto>(
               p =>
               {
                   p.ToTable("Producto");
                   p.HasKey(campo => campo.IdProducto);
               }

               );

            modelBuilder.Entity<Cliente>(
              p =>
              {
                  p.ToTable("Cliente");
                  p.HasKey(campo => campo.IdCliente);
              }

              );

            base.OnModelCreating(modelBuilder);
        }

    }
}
