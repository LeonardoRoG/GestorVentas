using GestorVentas.Domain;
using Microsoft.EntityFrameworkCore;

namespace GestorVentas.Database;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Proveedor> Proveedores { get; set; }

    public DbSet<Categoria> Categorias { get; set; }

    public DbSet<Producto> Productos { get; set; }

    public DbSet<Vehiculo> Vehiculos { get; set; }

    public DbSet<Empleado> Empleados { get; set; }

    public DbSet<Cliente> Clientes { get; set; }

    public DbSet<Orden> Ordenes { get; set; }

    public DbSet<DetalleOrden> DetalleOrdenes { get; set; }
}
