using API_Categoria.Data;
using API_Categoria.Models;
using API_Categoria.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API_Categoria.Repositorios
{
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        private readonly ApiCategoriaDBContext _dbContext;

        public CategoriaRepositorio(ApiCategoriaDBContext apiCategoriaDBContext) 
        {
            _dbContext = apiCategoriaDBContext;
        }
        public async Task<List<CategoriaModels>> ListarCategorias()
        {
            return await _dbContext.Categorias.ToListAsync();
        }

        public async Task<CategoriaModels> BuscarCategoriaPorId(int id)
        {
            CategoriaModels categoriaPorId = await _dbContext.Categorias.FirstOrDefaultAsync(x => x.Id == id);

            if (categoriaPorId == null)
            {
                throw new Exception($"Categoria (ID={id}) não encontrada!");
            }

            return categoriaPorId;
        }

        public async Task<CategoriaModels> Incluir(CategoriaModels categoria)
        {
            await _dbContext.Categorias.AddAsync(categoria);
            await _dbContext.SaveChangesAsync();

            return categoria;
        }

        public async Task<CategoriaModels> Atualizar(CategoriaModels categoria, int id)
        {
            CategoriaModels categoriaPorId = await BuscarCategoriaPorId(id);

            if(categoriaPorId == null)
            {
                throw new Exception($"Categoria (ID={id}) não encontrada!");
            }

            categoriaPorId.Nome = categoria.Nome;

            _dbContext.Categorias.Update(categoriaPorId);
            await _dbContext.SaveChangesAsync();

            return categoriaPorId;
        }

        public async Task<bool> Excluir(int id)
        {
            CategoriaModels categoriaPorId = await BuscarCategoriaPorId(id);

            if (categoriaPorId == null)
            {
                throw new Exception($"Categoria (ID={id}) não encontrada!");
            }

            _dbContext.Categorias.Remove(categoriaPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
