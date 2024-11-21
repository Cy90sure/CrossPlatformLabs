using Microsoft.AspNetCore.Mvc;
using lab5.Services;

namespace lab5.Controllers
{
    public class MovementLocationController : Controller
    {
        private readonly ApiService _apiService;

        public MovementLocationController(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var movementLocations = await _apiService.GetMovementLocationsAsync();
            return View(movementLocations);
        }
    }
}
