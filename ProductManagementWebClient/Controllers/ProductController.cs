using Microsoft.AspNetCore.Mvc;
using ProjectManagementAPI.Models;
using System.Net.Http.Headers;
using System.Text.Json;

public class ProductController : Controller
{
    private readonly HttpClient _httpClient;
    private readonly string _webApiBaseUrl = "https:localhost:7001/"; // Replace with your Web API URL

    public ProductController()
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri(_webApiBaseUrl);
        _httpClient.DefaultRequestHeaders.Accept.Clear();
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }

    public async Task<IActionResult> Index()
    {
        HttpResponseMessage response = await _httpClient.GetAsync("api/Product/GetAllProducts"); // Replace with your Web API endpoint
        if (response.IsSuccessStatusCode)
        {
            using (var stream = await response.Content.ReadAsStreamAsync())
            {
                var products = await JsonSerializer.DeserializeAsync<IEnumerable<Product>>(stream, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                return View(products);
            }
        }
        else
        {
            // Handle the error, such as logging or displaying an error message.
            return View(new List<Product>());
        }
    }

}
