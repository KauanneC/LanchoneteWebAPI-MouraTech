using Lanchonete.Models;
using Lanchonete.Service;
using Microsoft.AspNetCore.Mvc;

namespace Lanchonete.Controllers;

    [ApiController]
    [Route("lanches")] // define o roteamento
    public class LancheController : ControllerBase
    {
        [HttpGet] // pegar todos os lanches
        public ActionResult<List<Lanche>> getAll() => LancheServices.getAll();

        [HttpGet("{id}")] // pegar um lanche específico
        public ActionResult<Lanche> get(int id)
        {
            var lanche = LancheServices.get(id);
            
            if (lanche == null){
                return NotFound();
            }

            return lanche;
        }

        [HttpPost] // add um lanche
        public IActionResult create(Lanche lanche)
        {
            LancheServices.add(lanche);
            return CreatedAtAction(nameof(get), new { id = lanche.id }, lanche);
        }

        [HttpDelete("{id}")] // remover um lanche
        public IActionResult delete(int id)
        {
            var lanche = LancheServices.get(id);
           
            if (lanche is null){
                return NotFound();
            }

            LancheServices.delete(id);
            return NoContent();
        } 

        [HttpPut("{id}")] // modificar um lanche
        public IActionResult update(int id, Lanche lanche)
        {
            if (id != lanche.id){
                return BadRequest();
            }

            var existingLanche = LancheServices.get(id);

            if (existingLanche is null){
                return NotFound();
            }

            LancheServices.update(lanche);
            return NoContent();
        }
    }
