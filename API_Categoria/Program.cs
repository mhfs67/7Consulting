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

            var str = "Server=api-teste-server.mysql.database.azure.com; Database=db_teste7consulting; Port=3306; UserId=omega; Password=Alpha@28; SSLMode=Required";

            builder.Services.AddEntityFrameworkMySql()
                .AddDbContext<ApiCategoriaDBContext>(options => options.UseMySql(str, ServerVersion.AutoDetect(str)));

            builder.Services.AddScoped<ICategoriaRepositorio, CategoriaRepositorio>();

            builder.Services.AddCors();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
 //           if (app.Environment.IsDevelopment())
 //           {
            app.UseSwagger();
            app.UseSwaggerUI();
            //           }

            app.UseCors(c =>
            {
                c.AllowAnyHeader();
                c.AllowAnyMethod();
                c.AllowAnyOrigin();
            });

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}