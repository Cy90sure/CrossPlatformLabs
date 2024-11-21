using Microsoft.AspNetCore.Mvc;
using lab5.Services;

namespace lab5.Controllers
{
    public class OrganizationController : Controller
    {
        private readonly ApiService _apiService;

        public OrganizationController(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var organizations = await _apiService.GetOrganizationsAsync();

            return View(organizations);
        }
    }
}
