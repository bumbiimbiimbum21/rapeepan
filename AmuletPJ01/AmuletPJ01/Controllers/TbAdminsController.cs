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
    public class TbAdminsController : ControllerBase
    {
        private readonly AmuletturtleContext _context;

        public TbAdminsController(AmuletturtleContext context)
        {
            _context = context;
        }

        // GET: api/TbAdmins
        [HttpGet]
        public IEnumerable<TbAdmin> GetTbAdmin()
        {
            return _context.TbAdmin;
        }

        // GET: api/TbAdmins/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTbAdmin([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tbAdmin = await _context.TbAdmin.FindAsync(id);

            if (tbAdmin == null)
            {
                return NotFound();
            }

            return Ok(tbAdmin);
        }

        // PUT: api/TbAdmins/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbAdmin([FromRoute] int id, [FromBody] TbAdmin tbAdmin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbAdmin.AdminId)
            {
                return BadRequest();
            }

            _context.Entry(tbAdmin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbAdminExists(id))
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

        // POST: api/TbAdmins
        [HttpPost]
        public async Task<IActionResult> PostTbAdmin([FromBody] TbAdmin tbAdmin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TbAdmin.Add(tbAdmin);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbAdmin", new { id = tbAdmin.AdminId }, tbAdmin);
        }

        // DELETE: api/TbAdmins/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbAdmin([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tbAdmin = await _context.TbAdmin.FindAsync(id);
            if (tbAdmin == null)
            {
                return NotFound();
            }

            _context.TbAdmin.Remove(tbAdmin);
            await _context.SaveChangesAsync();

            return Ok(tbAdmin);
        }

        private bool TbAdminExists(int id)
        {
            return _context.TbAdmin.Any(e => e.AdminId == id);
        }
    }
}