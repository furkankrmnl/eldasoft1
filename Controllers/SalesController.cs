using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YourNamespace.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace YourNamespace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SalesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sale>>> GetSales()
        {
            return await _context.Sales.Include(s => s.Customer).Include(s => s.Book).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Sale>> GetSale(int id)
        {
            var sale = await _context.Sales.Include(s => s.Customer).Include(s => s.Book).FirstOrDefaultAsync(s => s.SaleID == id);

            if (sale == null)
            {
                return NotFound();
            }

            return sale;
        }

        [HttpPost]
        public async Task<ActionResult<Sale>> PostSale(SaleDTO saleDto)
        {
            var sale = new Sale
            {
                CustomerID = saleDto.CustomerID,
                BookID = saleDto.BookID,
                Quantity = saleDto.Quantity,
                TotalPrice = saleDto.TotalPrice,
                SaleDate = saleDto.SaleDate
            };

            _context.Sales.Add(sale);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSale", new { id = sale.SaleID }, sale);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutSale(int id, Sale sale)
        {
            if (id != sale.SaleID)
            {
                return BadRequest();
            }

            _context.Entry(sale).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SaleExists(id))
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSale(int id)
        {
            var sale = await _context.Sales.FindAsync(id);
            if (sale == null)
            {
                return NotFound();
            }

            _context.Sales.Remove(sale);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SaleExists(int id)
        {
            return _context.Sales.Any(e => e.SaleID == id);
        }
    }
}
