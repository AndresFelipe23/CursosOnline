using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoCursosAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace ProyectoCursosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeccionesController : ControllerBase
    {
        private readonly ProyectoCursosContext _context;

        public LeccionesController(ProyectoCursosContext context)
        {
            _context = context;
        }

        // GET: api/Lecciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Leccione>>> GetLecciones()
        {
            return await _context.Lecciones.ToListAsync();
        }

        // GET: api/Lecciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Leccione>> GetLeccion(int id)
        {
            var leccion = await _context.Lecciones.FindAsync(id);

            if (leccion == null)
            {
                return NotFound();
            }

            return leccion;
        }

        // POST: api/Lecciones
        [HttpPost]
        public async Task<ActionResult<Leccione>> PostLeccion(Leccione leccion)
        {
            _context.Lecciones.Add(leccion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLeccion", new { id = leccion.LeccionId }, leccion);
        }

        // PUT: api/Lecciones/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLeccion(int id, Leccione leccion)
        {
            if (id != leccion.LeccionId)
            {
                return BadRequest();
            }

            _context.Entry(leccion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LeccionExists(id))
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

        // DELETE: api/Lecciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLeccion(int id)
        {
            var leccion = await _context.Lecciones.FindAsync(id);
            if (leccion == null)
            {
                return NotFound();
            }

            _context.Lecciones.Remove(leccion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LeccionExists(int id)
        {
            return _context.Lecciones.Any(e => e.LeccionId == id);
        }

        // GET: api/Lecciones/etapa/5
        [HttpGet("etapa/{etapaId}")]
        public async Task<ActionResult<IEnumerable<Leccione>>> GetLeccionesPorEtapa(int etapaId)
        {
            var lecciones = await _context.Lecciones.Where(l => l.EtapaId == etapaId).ToListAsync();

            if (lecciones == null || lecciones.Count == 0)
            {
                return NotFound();
            }

            return Ok(lecciones);
        }

    }
}
