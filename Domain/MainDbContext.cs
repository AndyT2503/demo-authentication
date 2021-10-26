using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class MainDbContext : DbContext
    {
        public const string TablePrefix = "";
        public const string ProductSchema = "product";


        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(MainDbContext).Assembly);
        }
    }
}
