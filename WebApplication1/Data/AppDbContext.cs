using GestionEmpleados.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionEmpleados.Data
{
    public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public Microsoft.EntityFrameworkCore.DbSet<Empleado> Empleados { get; set; }
    }
}
