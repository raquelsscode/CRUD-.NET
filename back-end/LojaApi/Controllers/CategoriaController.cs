using Microsoft.AspNetCore.Mvc;
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
            if (ModelState.IsValid)
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
    }
}