using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ReadingJSON.Models;

namespace ReadingJSON.Controllers
{
    public class PostController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        // Constructor to inject IHttpClientFactory for making HTTP requests
        public PostController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        // Action to get post information from the API and display it in the view
        public async Task<IActionResult> Index(int pincode)
        {
            var client = _httpClientFactory.CreateClient();
            string apiUrl = $"http://api.postalpincode.in/pincode/{pincode}"; // Replace with your actual API URL

            // Send GET request to the API
            HttpResponseMessage response = await client.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                // Deserialize the response content into a list of PostPinResponse objects
                var postJson = await response.Content.ReadAsStringAsync();
                var postPinResponseList = JsonConvert.DeserializeObject<List<PostPinResponse>>(postJson);

                // Pass the data to the view
                return View(postPinResponseList);
            }
            else
            {
                // Handle error (you can pass an error message or an empty object)
                ViewBag.ErrorMessage = "Unable to fetch data from the API.";
                return View(null);
            }
        }
    }
}
