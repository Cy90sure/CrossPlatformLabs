using lab6.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lab6.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovementLocationsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MovementLocationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetMovementLocations()
        {
            var movementLocations = await _context.MovementLocations
                .Include(ml => ml.Shipment)
                .Include(ml => ml.FromLocation)
                .Include(ml => ml.ToLocation)
                .Select(ml => new
                {
                    ml.ShipmentLocationId,
                    ml.ShipmentId,
                    ShipmentDetails = ml.Shipment.ShipmentDetails,
                    FromLocation = new
                    {
                        ml.FromLocation.LocationId,
                        ml.FromLocation.LocationAddress,
                        ml.FromLocation.OtherDetails
                    },
                    ToLocation = new
                    {
                        ml.ToLocation.LocationId,
                        ml.ToLocation.LocationAddress,
                        ml.ToLocation.OtherDetails
                    },
                    ml.DateStarted,
                    ml.DateCompleted,
                    ml.OtherDetails
                })
                .ToListAsync();

            return Ok(movementLocations);
        }
    }
}
