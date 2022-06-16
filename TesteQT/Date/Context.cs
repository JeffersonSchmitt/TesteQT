using Microsoft.EntityFrameworkCore;
using TesteQT.Models;

namespace TesteQT.Date
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            :base(options)
        { }

        public DbSet<Document> ?Document { get; set; }
        public DbSet<Process> ?Processe { get; set; } 
    }
}
