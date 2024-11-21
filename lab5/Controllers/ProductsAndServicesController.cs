using Microsoft.AspNetCore.Mvc;
using lab5.Services;

namespace lab5.Controllers
{
    public class ProductsAndServicesController : Controller
    {
        private readonly ApiService _apiService;

        public ProductsAndServicesController(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var productsAndServices = await _apiService.GetProductsAndServicesAsync();

            return View(productsAndServices);
        }
    }
}
