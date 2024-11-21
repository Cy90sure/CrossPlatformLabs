using Microsoft.AspNetCore.Mvc;
using lab5.Services;

namespace lab5.Controllers
{
    public class LocationController : Controller
    {
        private readonly ApiService _apiService;

        public LocationController(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var locations = await _apiService.GetLocationsAsync();
            return View(locations);
        }
    }
}
