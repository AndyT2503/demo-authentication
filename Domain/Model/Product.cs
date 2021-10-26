using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Product : BaseModel
    {
         public string Name { get; set; }
    }
    internal class ProductEntityConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasAnnotation("Relational:Schema", MainDbContext.ProductSchema);
            builder.HasIndex(x => x.Name);
        }
    }
}
