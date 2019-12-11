using Microsoft.EntityFrameworkCore;
 
namespace ProductsCategories.Models
{
    public class Context : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public Context(DbContextOptions options) : base(options) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProdCat> ProdCats { get; set; }
    }
}