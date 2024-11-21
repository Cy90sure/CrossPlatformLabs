using Microsoft.AspNetCore.Mvc;
using lab5.Services;

namespace lab5.Controllers
{
    public class CountryController : Controller
    {
        private readonly ApiService _apiService;

        public CountryController(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var countries = await _apiService.GetCountriesAsync();
            return View(countries);
        }
    }
}
