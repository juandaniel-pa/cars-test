using Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Database
{
    public class ParkinDbContext : DbContext
    {
        public ParkinDbContext(DbContextOptions<ParkinDbContext> options) : base(options) { }

        //Las configuraciones y Credenciales de la DB estan el appsettings, en caso de probar en otra pc en local
        //cambiar el parametro de connectionstring con los datos de su servidor y base de datos usado y luego hacer
        //Update-Database en la consola
       public DbSet<Cars> Cars { get; set; }
        public DbSet<Record> Records { get; set; }
    }
}