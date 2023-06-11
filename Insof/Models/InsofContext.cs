using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Insof.Models
{
    public class InsofContext: DbContext
    {
        public InsofContext(DbContextOptions<InsofContext> options)
            :base(options)
        {  
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Producto> Productos { get; set; }
    }
}
