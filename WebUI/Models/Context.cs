using Microsoft.EntityFrameworkCore;

namespace WebUI.Models
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server =DESKTOP-PK98KLS; Database = SignalRProject; Trusted_Connection = True;TrustServerCertificate=True;");
        }

        public DbSet<Category> Categories { get; set; }
    }
}
