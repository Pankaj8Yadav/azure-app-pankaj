using Microsoft.EntityFrameworkCore;
using System;

namespace azure_app_pankaj.Modal
{
    public class appDBContext : DbContext
    {
        public appDBContext(DbContextOptions<appDBContext> options)
          : base(options)
        {
        }
        public DbSet<Person> Person { get; set; }
    }
}
