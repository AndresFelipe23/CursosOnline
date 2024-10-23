using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoCursosAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoCursosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EtapasController : ControllerBase
    {
        private readonly ProyectoCursosContext _context;

        public EtapasController(ProyectoCursosContext context)
        {
            _context = context;
        }

        // GET: api/Etapas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Etapa>>> GetEtapas()
        {
            return await _context.Etapas.ToListAsync();
        }

        // GET: api/Etapas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Etapa>> GetEtapa(int id)
        {
            var etapa = await _context.Etapas.FindAsync(id);

            if (etapa == null)
            {
                return NotFound();
            }

            return etapa;
        }

        // POST: api/Etapas
        [HttpPost]
        public async Task<ActionResult<Etapa>> PostEtapa(Etapa etapa)
        {
            // Verifica que el curso exista
            var curso = await _context.Cursos.FindAsync(etapa.CursoId);
            if (curso == null)
            {
                return BadRequest("El curso especificado no existe.");
            }

            // Si no envías un objeto Curso completo, esta propiedad no será utilizada
            etapa.Curso = curso;  // Puedes omitir esta línea si ya corregiste el modelo

            _context.Etapas.Add(etapa);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEtapa", new { id = etapa.EtapaId }, etapa);
        }

        // GET: api/Etapas/curso/4
        // Método para obtener las etapas de un curso específico
        [HttpGet("curso/{cursoId}")]
        public async Task<ActionResult<IEnumerable<Etapa>>> GetEtapasPorCurso(int cursoId)
        {
            // Verifica si el curso existe
            var curso = await _context.Cursos.FindAsync(cursoId);
            if (curso == null)
            {
                return NotFound(new { message = "Curso no encontrado." });
            }

            // Filtra las etapas por el cursoId
            var etapas = await _context.Etapas
                .Where(e => e.CursoId == cursoId)
                .ToListAsync();

            return etapas;
        }

        [HttpGet("curso/{cursoId}/etapa/{etapaId}")]
        public async Task<ActionResult<Etapa>> GetEtapaPorCursoYSeccion(int cursoId, int etapaId)
        {
            var etapa = await _context.Etapas
                .Where(e => e.CursoId == cursoId && e.EtapaId == etapaId)
                .FirstOrDefaultAsync();

            if (etapa == null)
            {
                return NotFound();
            }

            return Ok(etapa);
        }



        // PUT: api/Etapas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEtapa(int id, Etapa etapa)
        {
            if (id != etapa.EtapaId)
            {
                return BadRequest();
            }

            _context.Entry(etapa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EtapaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Etapas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEtapa(int id)
        {
            var etapa = await _context.Etapas.FindAsync(id);
            if (etapa == null)
            {
                return NotFound();
            }

            _context.Etapas.Remove(etapa);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EtapaExists(int id)
        {
            return _context.Etapas.Any(e => e.EtapaId == id);
        }
    }
}
