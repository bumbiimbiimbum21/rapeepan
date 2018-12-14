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
    public class TbMonksController : ControllerBase
    {
        private readonly AmuletturtleContext _context;

        public TbMonksController(AmuletturtleContext context)
        {
            _context = context;
        }

        // GET: api/TbMonks
        [HttpGet]
        public IEnumerable<TbMonk> GetTbMonk()
        {
            return _context.TbMonk;
        }

        // GET: api/TbMonks/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTbMonk([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tbMonk = await _context.TbMonk.FindAsync(id);

            if (tbMonk == null)
            {
                return NotFound();
            }

            return Ok(tbMonk);
        }

        // PUT: api/TbMonks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbMonk([FromRoute] int id, [FromBody] TbMonk tbMonk)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbMonk.MonkId)
            {
                return BadRequest();
            }

            _context.Entry(tbMonk).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbMonkExists(id))
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

        // POST: api/TbMonks
        [HttpPost]
        public async Task<IActionResult> PostTbMonk([FromBody] TbMonk tbMonk)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TbMonk.Add(tbMonk);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbMonk", new { id = tbMonk.MonkId }, tbMonk);
        }

        // DELETE: api/TbMonks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbMonk([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tbMonk = await _context.TbMonk.FindAsync(id);
            if (tbMonk == null)
            {
                return NotFound();
            }

            _context.TbMonk.Remove(tbMonk);
            await _context.SaveChangesAsync();

            return Ok(tbMonk);
        }

        private bool TbMonkExists(int id)
        {
            return _context.TbMonk.Any(e => e.MonkId == id);
        }
    }
}