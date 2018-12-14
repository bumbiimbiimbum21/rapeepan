using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AmuletPJ01.Models;
using Microsoft.AspNetCore.Cors;

namespace AmuletPJ01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class TbManualsController : ControllerBase
    {
        private readonly AmuletturtleContext _context;

        public TbManualsController(AmuletturtleContext context)
        {
            _context = context;
        }

        // GET: api/TbManuals
        [HttpGet]
        public IEnumerable<TbManual> GetTbManual()
        {
            return _context.TbManual;
        }

        // GET: api/TbManuals/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTbManual([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tbManual = await _context.TbManual.FindAsync(id);

            if (tbManual == null)
            {
                return NotFound();
            }

            return Ok(tbManual);
        }

        // PUT: api/TbManuals/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbManual([FromRoute] int id, [FromBody] TbManual tbManual)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbManual.ManualId)
            {
                return BadRequest();
            }

            _context.Entry(tbManual).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbManualExists(id))
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

        // POST: api/TbManuals
        [HttpPost]
        public async Task<IActionResult> PostTbManual([FromBody] TbManual tbManual)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TbManual.Add(tbManual);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbManual", new { id = tbManual.ManualId }, tbManual);
        }

        // DELETE: api/TbManuals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbManual([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tbManual = await _context.TbManual.FindAsync(id);
            if (tbManual == null)
            {
                return NotFound();
            }

            _context.TbManual.Remove(tbManual);
            await _context.SaveChangesAsync();

            return Ok(tbManual);
        }

        private bool TbManualExists(int id)
        {
            return _context.TbManual.Any(e => e.ManualId == id);
        }
    }
}