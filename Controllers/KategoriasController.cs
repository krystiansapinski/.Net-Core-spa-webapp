using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZadanieRekrutacyjne;
using ZadanieRekrutacyjne.Data;

namespace ZadanieRekrutacyjne.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KategoriasController : ControllerBase
    {
        private readonly DataContext _context;

        public KategoriasController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Kategorias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kategoria>>> GetKategorias()
        {
          if (_context.Kategorias == null)
          {
              return NotFound();
          }
            return await _context.Kategorias.ToListAsync();
        }

        // GET: api/Kategorias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Kategoria>> GetKategoria(int id)
        {
          if (_context.Kategorias == null)
          {
              return NotFound();
          }
            var kategoria = await _context.Kategorias.FindAsync(id);

            if (kategoria == null)
            {
                return NotFound();
            }

            return kategoria;
        }

        // PUT: api/Kategorias/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKategoria(int id, Kategoria kategoria)
        {
            if (id != kategoria.Id)
            {
                return BadRequest();
            }

            _context.Entry(kategoria).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KategoriaExists(id))
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

        // POST: api/Kategorias
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Kategoria>> PostKategoria(Kategoria kategoria)
        {
          if (_context.Kategorias == null)
          {
              return Problem("Entity set 'DataContext.Kategorias'  is null.");
          }
            _context.Kategorias.Add(kategoria);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKategoria", new { id = kategoria.Id }, kategoria);
        }

        // DELETE: api/Kategorias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKategoria(int id)
        {
            if (_context.Kategorias == null)
            {
                return NotFound();
            }
            var kategoria = await _context.Kategorias.FindAsync(id);
            if (kategoria == null)
            {
                return NotFound();
            }

            _context.Kategorias.Remove(kategoria);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KategoriaExists(int id)
        {
            return (_context.Kategorias?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
