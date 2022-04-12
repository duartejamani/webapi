
using Microsoft.EntityFrameworkCore;
using webapi2.Model;

namespace webapi2.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Cliente> newCliente { get; set; }

    }
}
