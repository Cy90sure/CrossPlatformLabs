using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace lab6.Services
{
    public interface ISalesforceAuthService
    {
        Task<AuthResult> AuthenticateAsync(string username, string password, string securityToken);
    }
    public class SalesforceAuthService : ISalesforceAuthService
    {
        private readonly string ClientId = "3MVG9gYjOgxHsENJRCS5fJRltehlGXdiQIREClVXuP6O048.krThOGrtSlov_mwByoar4gNMTmlWkL7QA1VWY";
        private readonly string ClientSecret = "31E6570F0DC977EC6E215FE79C81969CC7EAF846DA38CB0715FBA217085597D4";
        private readonly string loginEndpoint = "https://login.salesforce.com/services/oauth2/token";
        public async Task<AuthResult> AuthenticateAsync(string username, string password, string securityToken)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/x-www-form-urlencoded");
                var requestData = new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    {"grant_type", "password" },
                    {"client_id", ClientId },
                    {"client_secret", ClientSecret },
                    {"username", username },
                    {"password", $"{password}{securityToken}" }
                });


                var response = await client.PostAsync(loginEndpoint, requestData);
                if (response.IsSuccessStatusCode)
                {

                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonResponse);

                    return new AuthResult
                    {
                        IsSuccess = true,
                        AuthToken = values["access_token"],
                        InstanceUrl = values["instance_url"]
                    };
                }
                else
                {
                    var errorResponse = await response.Content.ReadAsStringAsync();

                    return new AuthResult
                    {
                        IsSuccess = false,
                        Result = errorResponse
                    };
                }
            }
        }
    }
    public class AuthResult
    {
        public bool IsSuccess { get; set; }
        public string AuthToken { get; set; }
        public string InstanceUrl { get; set; }
        public string Result { get; set; }
    }
}