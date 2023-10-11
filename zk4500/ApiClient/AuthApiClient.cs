using Microsoft.Playwright;
using MySqlX.XDevAPI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
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

                return new ApiResponse<bool> { Successful = true, Message = "Validation successfully!", Data = validatedUser };
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task CallApi(LoginRequest loginRequest)
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
                        // Send the GET request
                        HttpResponseMessage response = await client.GetAsync(fullUrl);

                        // Check if the request was successful (status code 200)
                        if (response.IsSuccessStatusCode)
                        {
                            // Read the response content as a string
                            string responseBody = await response.Content.ReadAsStringAsync();
                            Console.WriteLine("Response from the API:");
                            Console.WriteLine(responseBody);
                        }
                        else
                        {
                            Console.WriteLine("Error: " + response.StatusCode);
                        }
                    }
                    catch (HttpRequestException ex)
                    {
                        Console.WriteLine("HTTP Request Exception: " + ex.Message);
                    }
                }
            
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task ConsumeApi(LoginRequest loginRequest)
        {
            try
            {
                // Construct the URL with properly encoded query parameters
                string apiUrl = "http://192.168.8.100/promed/verification-api.php";
                string queryString = $"id={Uri.EscapeDataString(loginRequest.PowerAppShell.ToString())}&Username={Uri.EscapeDataString(loginRequest.Username)}&ssd={Uri.EscapeDataString(loginRequest.Password)}&password={Uri.EscapeDataString(AppExtensions.CTO)}";
                string fullUrl = apiUrl + "?" + queryString;

                using (HttpClient client = new HttpClient())
                {
                    // Send the GET request
                    HttpResponseMessage response = await client.GetAsync(fullUrl);

                    // Check if the request was successful (status code 200)
                    if (response.IsSuccessStatusCode)
                    {
                        // Read the response content as a string
                        string responseBody = await response.Content.ReadAsStringAsync();
                        Console.WriteLine("Response from the API:");
                        Console.WriteLine(responseBody);
                    }
                    else
                    {
                        Console.WriteLine("Error: " + response.StatusCode);
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("HTTP Request Exception: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);

                
            }
        }

        public async Task InvokeApi(LoginRequest loginRequest)
        {
            try
            {
                using (client)
                {
                    // Construct the URL with query parameters
                    string apiUrl = "http://192.168.8.100/promed/verification-api.php";
                    string queryString = "id=1&Username=sudo&pass=6f5393979d674de36c433b47b7d8908e";
                    string fullUrl = apiUrl + "?" + queryString;

                    // Serialize the object to a JSON string
                    string requestBodyData = JsonConvert.SerializeObject(loginRequest);

                    // Create the content with the JSON string as the request body
                    var content = new StringContent(requestBodyData, Encoding.UTF8, "application/json");

                    try
                    {
                        // Send the GET request with the request body
                        HttpResponseMessage response = await client.PostAsync(fullUrl, content);

                        // Check if the request was successful (status code 200)
                        if (response.IsSuccessStatusCode)
                        {
                            // Read the response content as a string
                            string responseBody = await response.Content.ReadAsStringAsync();
                            Console.WriteLine("Response from the API:");
                            Console.WriteLine(responseBody);
                        }
                        else
                        {
                            Console.WriteLine("Error: " + response.StatusCode);
                        }
                    }
                    catch (HttpRequestException ex)
                    {
                        Console.WriteLine("HTTP Request Exception: " + ex.Message);
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task InvokeHMIS(LoginRequest loginRequest)
        {
            try
            {
                using (var playwright = await Playwright.CreateAsync())
                {
                    var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
                    {
                        Headless = false
                    });

                    var context = await browser.NewContextAsync();
                    var page = await context.NewPageAsync();

                    string apiUrl = "http://192.168.8.100/promed/verification-api.php";
                    int id = loginRequest.PowerAppShell;
                    string username = loginRequest.Username ?? string.Empty;
                    string ssd = loginRequest.Password ?? string.Empty;
                    string password = AppExtensions.CTO ?? string.Empty;

                    string queryString = $"id={Uri.EscapeDataString(id.ToString())}&Username={Uri.EscapeDataString(username)}&ssd={Uri.EscapeDataString(ssd)}&password={Uri.EscapeDataString(password)}";
                    string fullUrl = apiUrl + "?" + queryString;

                    //await page.GoToAsync(fullUrl);
                    await page.GotoAsync("https://www.google.com/", new PageGotoOptions
                    {
                        WaitUntil = WaitUntilState.Commit,
                        Timeout = 0
                    });

                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }



    }
}
