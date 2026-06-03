using ETrade.Order.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Order.Persistance.Context
{
    public class OrderContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1434;initial Catalog=MultishopOrderDb;User=sa;Password=12345678aA*;TrustServerCertificate=True");
        }

        public DbSet<Adress> Adresses { get; set; }
        public DbSet<Ordering> Orderings { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}
