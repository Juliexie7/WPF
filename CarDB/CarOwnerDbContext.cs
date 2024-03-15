using CarDB.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDB
{
    public class CarOwnerDbContext : DbContext
    {
        public DbSet<Car> cars {  get; set; }
        public DbSet<Owner> owners { get; set; }

    }
}
