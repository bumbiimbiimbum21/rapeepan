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
    public class TbAmuletsController : ControllerBase
    {
        private readonly AmuletturtleContext _context;

        public TbAmuletsController(AmuletturtleContext context)
        {
            _context = context;
        }

        // GET: api/TbAmulets
        [HttpGet]
        public IEnumerable<TbAmulet> GetTbAmulet()
        {
            return _context.TbAmulet;
        }

        // GET: api/TbAmulets/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTbAmulet([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tbAmulet = await _context.TbAmulet.FindAsync(id);

            if (tbAmulet == null)
            {
                return NotFound();
            }

            return Ok(tbAmulet);
        }

        // PUT: api/TbAmulets/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbAmulet([FromRoute] int id, [FromBody] TbAmulet tbAmulet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbAmulet.AmuletId)
            {
                return BadRequest();
            }

            _context.Entry(tbAmulet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbAmuletExists(id))
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

        // POST: api/TbAmulets
        [HttpPost]
        public async Task<IActionResult> PostTbAmulet([FromBody] TbAmulet tbAmulet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TbAmulet.Add(tbAmulet);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbAmulet", new { id = tbAmulet.AmuletId }, tbAmulet);
        }

        // DELETE: api/TbAmulets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbAmulet([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tbAmulet = await _context.TbAmulet.FindAsync(id);
            if (tbAmulet == null)
            {
                return NotFound();
            }

            _context.TbAmulet.Remove(tbAmulet);
            await _context.SaveChangesAsync();

            return Ok(tbAmulet);
        }

        private bool TbAmuletExists(int id)
        {
            return _context.TbAmulet.Any(e => e.AmuletId == id);
        }
    }
}