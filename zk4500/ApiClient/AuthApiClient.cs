//using Microsoft.Playwright;
using Newtonsoft.Json;
using System;
using System.IO;
using System.IO.Pipes;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using zk4500.Abstractions.IServices;
using zk4500.Extensions;
using zk4500.Shared.Dtos;
using zk4500.Shared.Requests;

namespace zk4500.ApiClient
{
    public class AuthApiClient : IAuthApiClient
    {
        private readonly HttpClient client;
        private readonly IConfigurationService configurationService;

        public AuthApiClient(HttpClient HttpClient, IConfigurationService ConfigurationService)
        {
            client = HttpClient;
            configurationService = ConfigurationService;
        }

        public async Task InvokeHMIS(LoginRequest loginRequest)
        {
            try
            {
                string apiUrl = "http://192.168.8.100/promed/verification-api.php";
                int id = loginRequest.PowerAppShell;
                string username = loginRequest.Username ?? string.Empty;
                string ssd = loginRequest.Password ?? string.Empty;
                string password = AppExtensions.CTO ?? string.Empty;

                string queryString = $"id={Uri.EscapeDataString(id.ToString())}&Username={Uri.EscapeDataString(username)}&ssd={Uri.EscapeDataString(ssd)}&password={Uri.EscapeDataString(password)}";
                string fullUrl = apiUrl + "?" + queryString;

                //await InvokeBrowser(fullUrl);

                CallWindowsService($"https://learn.microsoft.com/en-us/dotnet/framework/configure-apps/how-to-enable-and-disable-automatic-binding-redirection?redirectedfrom=MSDN");

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ApiResponse<bool>> NotifyVerified(LoginRequest loginRequest)
        {
            try
            {
                var vefirficationEndPoint = $"{configurationService.GetApiEndpointUrl("LoginVerification").Result}";
                var content = new StringContent(JsonConvert.SerializeObject(loginRequest), Encoding.UTF8, "application/json");
                var response = await client.PostAsync(vefirficationEndPoint, content);
                if (!response.IsSuccessStatusCode)
                {
                    return new ApiResponse<bool>() { Successful = false, Message = $"Error Validating User | {response.ReasonPhrase}" };
                }

                var apiResponse = await response.Content.ReadAsStringAsync();
                var validatedUser = JsonConvert.DeserializeObject<bool>(apiResponse);

                try
                {
                    string apiUrl = "http://192.168.8.100/promed/verification-api.php";

                    string queryString = $"id={Uri.EscapeDataString(loginRequest.PowerAppShell.ToString())}&Username={Uri.EscapeDataString(loginRequest.Username)}&ssd={Uri.EscapeDataString(loginRequest.Password)}&password={Uri.EscapeDataString(AppExtensions.CTO)}";

                    string fullUrl = apiUrl + "?" + queryString;

                    CallWindowsService(fullUrl);

                    //await InvokeBrowser(fullUrl);
                }
                catch (Exception)
                {

                    throw;
                }

                return new ApiResponse<bool> { Successful = true, Message = "Validation successfully!", Data = validatedUser };
            }
            catch (Exception)
            {

                throw;
            }
        }

        private static void CallWindowsService(string url)
        {
            NamedPipeClientStream clientPipe = new NamedPipeClientStream(".", "BrowserServicePipe", PipeDirection.Out);

            clientPipe.Connect();

            using (StreamWriter writer = new StreamWriter(clientPipe))
            {
                // Send the URL to launch the browser
                writer.Write($"{url}");
            }

            clientPipe.Close();
        }

        public async Task CallApiWithEncodedQueryParams(LoginRequest loginRequest)
        {
            try
            {
                string apiUrl = "http://192.168.8.100/promed/verification-api.php";

                string queryString = $"id={Uri.EscapeDataString(loginRequest.PowerAppShell.ToString())}&Username={Uri.EscapeDataString(loginRequest.Username)}&ssd={Uri.EscapeDataString(loginRequest.Password)}&password={Uri.EscapeDataString(AppExtensions.CTO)}";

                string fullUrl = apiUrl + "?" + queryString;

                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(fullUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                    }
                    else
                    {

                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task CallApiWithNonEncodedQueryParams(LoginRequest loginRequest)
        {
            try
            {
                using (client)
                {
                    // Construct the URL with query parameters
                    string apiUrl = "http://192.168.8.100/promed/verification-api.php";

                    string queryString = $"id={loginRequest.PowerAppShell}&Username={loginRequest.Username}&ssd={loginRequest.Password}&password={AppExtensions.CTO}";

                    string fullUrl = apiUrl + "?" + queryString;

                    try
                    {
                        HttpResponseMessage response = await client.GetAsync(fullUrl);
                        if (response.IsSuccessStatusCode)
                        {
                            string responseBody = await response.Content.ReadAsStringAsync();
                            
                        }
                        else
                        {
                            
                        }
                    }
                    catch (HttpRequestException)
                    {
                        throw;
                    }
                }
            
            }
            catch (Exception)
            {

                throw;
            }
        }

        //private static async Task InvokeBrowser(string fullUrl)
        //{
        //    using (var playwright = await Playwright.CreateAsync())
        //    {
        //        var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        //        {
        //            Headless = false
        //        });

        //        var context = await browser.NewContextAsync();
        //        var page = await context.NewPageAsync();
        //        await page.GotoAsync($"{fullUrl}", new PageGotoOptions
        //        {
        //            WaitUntil = WaitUntilState.Commit,
        //            Timeout = 0
        //        });
        //    }
        //}



    }
}
