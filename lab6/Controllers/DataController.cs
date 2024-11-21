using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using lab6.Data;

namespace lab6.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class DataController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DataController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("ProductsAndServices")]
        public async Task<IActionResult> GetProductsAndServices()
        {
            var productsAndServices = await _context.ProductsAndServices.ToListAsync();
            return Ok(productsAndServices);
        }

        [HttpGet("Locations")]
        public async Task<IActionResult> GetLocations()
        {
            var locations = await _context.Locations.ToListAsync();
            return Ok(locations);
        }

        [HttpGet("Organizations")]
        public async Task<IActionResult> GetOrganizations()
        {
            var organizations = await _context.Organizations.ToListAsync();
            return Ok(organizations);
        }

        [HttpGet("Countries")]
        public async Task<IActionResult> GetCountries()
        {
            var countries = await _context.Countries.ToListAsync();
            return Ok(countries);
        }
    }
}
