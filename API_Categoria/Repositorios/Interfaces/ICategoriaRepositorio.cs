using API_Categoria.Models;

namespace API_Categoria.Repositorios.Interfaces
{
    public interface ICategoriaRepositorio
    {
        Task<List<CategoriaModels>> ListarCategorias();
        Task<CategoriaModels> BuscarCategoriaPorId(int id);
        Task<CategoriaModels> Incluir(CategoriaModels categoria);
        Task<CategoriaModels> Atualizar(CategoriaModels categoria, int id);
        Task<bool> Excluir(int id);
    }
}
