using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace azure_app_pankaj.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        { }

        public AppDBContext() { }
        public  DbSet<Person> persons { get; set; }
    }
}
