using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using StoreApp.API.Model;

namespace StoreApp.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
    }
}