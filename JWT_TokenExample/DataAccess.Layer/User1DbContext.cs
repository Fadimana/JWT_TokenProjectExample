using DataAccess.Layer.Entity;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Layer
{
    public class User1DbContext:DbContext
    {
        public DbSet<User1>Users1 { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
    }
}