using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication4.Data;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhonesController : ControllerBase
    {
        private readonly WebApplication4Context _context;

        public PhonesController(WebApplication4Context context)
        {
            _context = context;
        }

        // GET: api/Phones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Phone>>> GetPhone()
        {
            return await _context.Phone.ToListAsync();
        }

        // GET: api/Phones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Phone>> GetPhone(int id)
        {
            var phone = await _context.Phone.FindAsync(id);

            if (phone == null)
            {
                return NotFound();
            }

            return phone;
        }
        /// <summary>
        /// update a phone
        /// </summary>
        // PUT: api/Phones/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("put")]
        public async Task<IActionResult> PutPhone(Phone phone)
        {
            if (phone.Id != phone.Id)
            {
                return BadRequest();
            }

            _context.Entry(phone).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhoneExists(phone.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(phone);
        }
        /// <summary>
        /// create a phone
        /// </summary>
        // POST: api/Phones
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Phone>> PostPhone(Phone phone)
        {
            _context.Phone.Add(phone);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPhone", new { id = phone.Id }, phone);
        }

        // DELETE: api/Phones/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Phone>> DeletePhone(int id)
        {
            var phone = await _context.Phone.FindAsync(id);
            if (phone == null)
            {
                return NotFound();
            }

            _context.Phone.Remove(phone);
            await _context.SaveChangesAsync();

            return phone;
        }

        private bool PhoneExists(int id)
        {
            return _context.Phone.Any(e => e.Id == id);
        }
    }
}
