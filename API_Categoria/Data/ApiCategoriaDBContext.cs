using API_Categoria.Data.Map;
using API_Categoria.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Categoria.Data
{
    public class ApiCategoriaDBContext : DbContext
    {
        public ApiCategoriaDBContext(DbContextOptions<ApiCategoriaDBContext> options)
            : base(options) 
        { }

        public DbSet<CategoriaModels> Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoriaMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
