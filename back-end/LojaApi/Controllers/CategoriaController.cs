using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LojaAPI.Models;
using LojaAPI.Data;

namespace LojaAPI.Contorllers
{

    [ApiController]
    [Route("categorias")]
    public class CategoriaController : Controller
    {

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Categoria>> Post([FromServices] DataContext context, [FromBody] Categoria body)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var categoria = new Categoria()
            {
                Nome = body.Nome,
                DataCadastro = body.DataCadastro,
                Departamento = body.Departamento
            };

            context.Categorias.Add(categoria);
            await context.SaveChangesAsync();

            return body;
        }

        [HttpGet]
        public async Task<ActionResult<List<Categoria>>> Listar([FromServices] DataContext context) {
            var categorias = await context.Categorias.ToListAsync();
            return categorias;
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<Categoria>> Delete([FromServices] DataContext context, int id){
            var categoria = await context.Categorias.FirstOrDefaultAsync(categoria => categoria.Id == id);
            if (categoria == null) return NotFound();

            context.Categorias.Remove(categoria);
            await context.SaveChangesAsync();

            return Ok(categoria);
        }
    }
}