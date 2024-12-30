using Microsoft.AspNetCore.Mvc;
using rh.Models;
using Context;
using Microsoft.EntityFrameworkCore;

namespace rh.Controllers;

[ApiController]
    [Route("api/[controller]")]
    public class FuncionarioApiController : ControllerBase
    {
        private readonly FuncionarioContext _context;

        public FuncionarioApiController(FuncionarioContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetFuncionarios()
        {
            return Ok(await _context.Funcionarios.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> CreateFuncionario([FromBody] Funcionario funcionario)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Funcionarios.Add(funcionario);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetFuncionarios), new { id = funcionario.Id }, funcionario);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFuncionario(int id, [FromBody] Funcionario funcionario)
        {
            if (id != funcionario.Id)
                return BadRequest();

            _context.Entry(funcionario).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFuncionario(int id)
        {
            var funcionario = await _context.Funcionarios.FindAsync(id);
            if (funcionario == null)
                return NotFound();

            _context.Funcionarios.Remove(funcionario);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
    

