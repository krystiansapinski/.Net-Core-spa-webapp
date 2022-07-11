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
    public class ZadanieRekrutacyjnesController : ControllerBase
    {
        private readonly DataContext _context;

        public ZadanieRekrutacyjnesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/ZadanieRekrutacyjnes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ZadanieRekrutacyjne>>> GetZadanieRekrutacyjnes()
        {
          if (_context.ZadanieRekrutacyjnes == null)
          {
              return NotFound();
          }
            return await _context.ZadanieRekrutacyjnes.ToListAsync();
        }

        // GET: api/ZadanieRekrutacyjnes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ZadanieRekrutacyjne>> GetZadanieRekrutacyjne(int id)
        {
          if (_context.ZadanieRekrutacyjnes == null)
          {
              return NotFound();
          }
            var zadanieRekrutacyjne = await _context.ZadanieRekrutacyjnes.FindAsync(id);

            if (zadanieRekrutacyjne == null)
            {
                return NotFound();
            }

            return zadanieRekrutacyjne;
        }

        // PUT: api/ZadanieRekrutacyjnes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutZadanieRekrutacyjne(int id, ZadanieRekrutacyjne zadanieRekrutacyjne)
        {
            if (id != zadanieRekrutacyjne.Id)
            {
                return BadRequest();
            }

            _context.Entry(zadanieRekrutacyjne).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZadanieRekrutacyjneExists(id))
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

        // POST: api/ZadanieRekrutacyjnes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ZadanieRekrutacyjne>> PostZadanieRekrutacyjne(ZadanieRekrutacyjne zadanieRekrutacyjne)
        {
          if (_context.ZadanieRekrutacyjnes == null)
          {
              return Problem("Entity set 'DataContext.ZadanieRekrutacyjnes'  is null.");
          }
            _context.ZadanieRekrutacyjnes.Add(zadanieRekrutacyjne);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetZadanieRekrutacyjne", new { id = zadanieRekrutacyjne.Id }, zadanieRekrutacyjne);
        }

        // DELETE: api/ZadanieRekrutacyjnes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteZadanieRekrutacyjne(int id)
        {
            if (_context.ZadanieRekrutacyjnes == null)
            {
                return NotFound();
            }
            var zadanieRekrutacyjne = await _context.ZadanieRekrutacyjnes.FindAsync(id);
            if (zadanieRekrutacyjne == null)
            {
                return NotFound();
            }

            _context.ZadanieRekrutacyjnes.Remove(zadanieRekrutacyjne);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ZadanieRekrutacyjneExists(int id)
        {
            return (_context.ZadanieRekrutacyjnes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
