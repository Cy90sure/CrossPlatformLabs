using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using lab6.Data;
using Newtonsoft.Json;
using lab6.Services;
using RestSharp;

namespace lab6.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class DataController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ISalesforceAuthService _salesforceAuthService;

        public DataController(ApplicationDbContext context, ISalesforceAuthService salesforceAuthService)
        {
            _context = context;
            _salesforceAuthService = salesforceAuthService;
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

        [HttpPost("sendAddresses")]
        public async Task<ActionResult> SendAddresses()
        {
            var addresses = await _context.Organizations.ToListAsync();

            var salesforceAddresses = addresses.Select(a => new
            {
                organizationId__c = a.OrganizationId,
                organizationTypeCode__c = a.OrganizationTypeCode,
                organizationDetails__c = a.OrganizationDetails
            }).ToList();

            var authResult = await _salesforceAuthService.AuthenticateAsync("maria.pozniak2013-ju1u@force.com", "maria.pozniak2013", "HWhsRfqe6KfraF9ORijBakN1");

            if (!authResult.IsSuccess)
            {
                return Unauthorized($"Authentication failed with Salesforce. Error: {authResult.Result}");
            }

            string accessToken = authResult.AuthToken;
            string instanceUrl = authResult.InstanceUrl;

            string salesforceApiUrl = $"{instanceUrl}/services/data/v57.0/sobjects/Organizations/";

            var client = new RestClient(salesforceApiUrl);

            foreach (var address in salesforceAddresses)
            {
                var body = JsonConvert.SerializeObject(address);

                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", "Bearer " + accessToken);
                request.AddHeader("Content-Type", "application/json");
                request.AddJsonBody(body);

                var response = await client.ExecuteAsync(request);

                if (!response.IsSuccessful)
                {
                    return BadRequest($"Error sending data to Salesforce: {response.Content}");
                }
            }


            return Ok("Data successfully sent to Salesforce.");
        }

        [HttpGet("Countries")]
        public async Task<IActionResult> GetCountries()
        {
            var countries = await _context.Countries.ToListAsync();
            return Ok(countries);
        }
    }
}
