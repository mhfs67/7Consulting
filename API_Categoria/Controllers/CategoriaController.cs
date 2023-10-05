using API_Categoria.Models;
using API_Categoria.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Categoria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaRepositorio _categoriaRepositorio;

        public CategoriaController(ICategoriaRepositorio categoriaRepositorio)
        {
            _categoriaRepositorio = categoriaRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoriaModels>>> ListarCategorias()
        {
            List<CategoriaModels> categorias = await _categoriaRepositorio.ListarCategorias();
            return Ok(categorias);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoriaModels>> BuscarCategoriaPorId(int id)
        {
            CategoriaModels categoria = await _categoriaRepositorio.BuscarCategoriaPorId(id);
            return Ok(categoria);
        }

        [HttpPost]
        public async Task<ActionResult<CategoriaModels>> Incluir([FromBody] CategoriaModels categoriaModels)
        {
            CategoriaModels categoria = await _categoriaRepositorio.Incluir(categoriaModels);
            return Ok(categoria);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CategoriaModels>> Atualizar([FromBody] CategoriaModels categoriaModels, int id)
        {
            categoriaModels.Id = id;
            CategoriaModels categoria = await _categoriaRepositorio.Atualizar(categoriaModels, id);
            return Ok(categoria);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CategoriaModels>> Excluir(int id)
        {
            bool excluido = await _categoriaRepositorio.Excluir(id);
            return Ok(excluido);
        }
    }
}
