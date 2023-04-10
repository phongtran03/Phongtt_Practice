using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MaiHuyHoat_Practice.Models;

namespace MaiHuyHoat_Practice.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly DbFirstContext _context;

        public CustomersController(DbFirstContext context)
        {
            _context = context;
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetList([FromQuery] Customer? model)
        {
            var result = _context.Customers.Where(c =>
                   (c.Name.ToLower().Contains(model.Name.ToLower()) || model.Name == "")
                   && (c.Age == model.Age || model.Age == 0)
                   && (c.Gender == model.Gender || model.Gender == "")
                   && (c.Address.ToLower().Contains(model.Address.ToLower()) || model.Address == "")
               ).Select(m =>
               new Customer()
               {
                   Id = m.Id,
                   Name = m.Name,
                   Address = m.Address,
                   Status = m.Status,
                   Age = m.Age,
                   Debit = m.Debit,
                   Description = m.Description,
                   Gender = m.Gender,
                   Username = m.Username
               }
               );
            return Ok(result);
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetDetail(long id)
        {
          if (_context.Customers == null)
          {
              return NotFound();
          }
            var customer = await _context.Customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        // PUT: api/Customers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(long id, Customer customer)
        {
            if (id != customer.Id)
            {
                return BadRequest();
            }

            _context.Entry(customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
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

        // POST: api/Customers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Customer>> Add(Customer customer)
        {
          if (_context.Customers == null)
          {
              return Problem("Entity set 'DbFirstContext.Customers'  is null.");
          }
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomer", new { id = customer.Id }, customer);
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(long id)
        {
            if (_context.Customers == null)
            {
                return NotFound();
            }
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomerExists(long id)
        {
            return (_context.Customers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
