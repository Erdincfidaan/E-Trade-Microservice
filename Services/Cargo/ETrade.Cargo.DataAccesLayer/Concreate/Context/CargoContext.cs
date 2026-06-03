using ETrade.Cargo.EntitiyLayer.Concreate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Cargo.DataAccesLayer.Concreate.Context
{
    public class CargoContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1435;Initial Catalog=ETradeCargoDb;User ID=sa;Password=12345678aA*;TrustServerCertificate=True;");
        }
        public DbSet<CargoCompany> CargoCompanies { get; set; }
        public DbSet<CargoCustomer> CargoCustomers { get; set; }
        public DbSet<CargoDetail> CargoDetails { get; set; }
        public DbSet<CargoOperation> CargoOperations { get; set; }

    }
}
