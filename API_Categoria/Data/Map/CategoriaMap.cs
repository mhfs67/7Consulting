using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using API_Categoria.Models;

namespace API_Categoria.Data.Map
{
    public class CategoriaMap : IEntityTypeConfiguration<CategoriaModels>
    {
        public void Configure(EntityTypeBuilder<CategoriaModels> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(100);
        }
    }
}
