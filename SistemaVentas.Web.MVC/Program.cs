using Microsoft.EntityFrameworkCore;
using SistemaVentas.Dominio.Repositories;
using SistemaVentas.Infraestructura.Commom;
using SistemaVentas.Infraestructura.Repositories;
internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        // Configurando el DbContext
        var connectionString = builder.Configuration.GetConnectionString("dbVenta-cnx");
        builder.Services.AddDbContext<VentaDbContext>(
                options => options.UseSqlServer(connectionString)
            );

        // Registrar los repositorios
        builder.Services.AddTransient<ICategoriaRepository, CategoriaRepository>();
        builder.Services.AddTransient<IClienteRepository, ClienteRepository>();

        // Registrar el servicio ClienteService
        builder.Services.AddScoped<ClienteService>();

        // Registrar configuraciones adicionales
        builder.Services.AddSingleton<IAppConfiguracion, AppConfiguracion>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}