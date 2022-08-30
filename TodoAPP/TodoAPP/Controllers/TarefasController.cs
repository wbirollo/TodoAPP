using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoAPP.Data;
using TodoAPP.Models;

namespace TodoAPP.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        private readonly TodoAPPContext _context;

        public TarefasController(TodoAPPContext context)
        {
            _context = context;
        }


        [HttpGet("TodasTarefas")]
        public async Task<ActionResult<IEnumerable<Tarefa>>> GetTarefa()
        {
            return await _context.Tarefa.ToListAsync();
        }


        [HttpPost("TarefasASeremConcluidas")]
        public async Task<ActionResult<List<Tarefa>>> PostTarefa()
        {
            List<Tarefa> lTarefa = await _context.Tarefa.Where(tarefa => tarefa.Concluido == false)
                .OrderBy(tarefa => tarefa.DataConclusao).ToListAsync();

            return lTarefa;
        }


        [HttpPut("ConcluirTarefa/{id}")]
        public async Task<ActionResult<Tarefa>> PutTarefa(int id)
        {
            var tarefa = await _context.Tarefa.FindAsync(id);

            if (tarefa == null)
            {
                return NotFound();
            }

            _context.Entry(tarefa).State = EntityState.Modified;

            tarefa.Concluido = true;

            await _context.SaveChangesAsync();

            return tarefa;

        }

        [HttpPost("CriarTarefa")]
        public async Task<ActionResult<Tarefa>> PostTarefa(Tarefa tarefa)
        {
            try
            {
                tarefa.Id = 0;
                tarefa.Concluido = false;
                _context.Tarefa.Add(tarefa);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetTarefa", new { id = tarefa.Id }, tarefa);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }            
        }
      

    }
}
