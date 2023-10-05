using Microsoft.EntityFrameworkCore;
using API_Categoria.Data;
using API_Categoria.Repositorios.Interfaces;
using API_Categoria.Repositorios;

namespace API_Categoria
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddEntityFrameworkSqlite()
                .AddDbContext<ApiCategoriaDBContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DataBase")));

            builder.Services.AddScoped<ICategoriaRepositorio, CategoriaRepositorio>();

//            #region [Cors]
//            builder.Services.AddCors();
//            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

//            #region [Cors]
//            app.UseCors(c =>
//            {
//                c.AllowAnyHeader();
//                c.AllowAnyMethod();
//                c.AllowAnyOrigin();
//            });
//            #endregion

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}