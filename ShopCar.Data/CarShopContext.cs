using Microsoft.EntityFrameworkCore;
using ShopCar.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ShopCar.Data
{
    public class CarShopContext : DbContext
    {
        public CarShopContext(DbContextOptions<CarShopContext> options) : base(options)
        {
        }

        public DbSet<ShopCarDomain> Cars { get; set; }
    }
}
