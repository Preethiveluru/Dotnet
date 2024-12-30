using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using webApplicationwebAPIEFwithmvc.Models;

namespace webApplicationwebAPIEFwithmvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient _client;

        public HomeController(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient();
            _client.BaseAddress = new Uri("http://localhost:5236/api/PetAnimals"); // Update base URL if needed
        }

        // GET: Home/Index
        public async Task<IActionResult> Index()
        {
            var response = await _client.GetStringAsync("PetAnimals");
            var petAnimals = JsonConvert.DeserializeObject<List<PetAnimal>>(response);
            return View(petAnimals);
        }

        // GET: Home/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public async Task<IActionResult> Create(PetAnimal petAnimal)
        {
            var json = JsonConvert.SerializeObject(petAnimal);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("PetAnimals", content);
            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));

            return View(petAnimal);
        }




        // GET: Home/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var response = await _client.GetStringAsync($"{id}"); // Call API to fetch the specific pet
                var petAnimal = JsonConvert.DeserializeObject<PetAnimal>(response);
                return View(petAnimal);
            }
            catch (HttpRequestException ex)
            {
                // Log the error or handle it appropriately
                Console.WriteLine($"Error fetching pet: {ex.Message}");
                return RedirectToAction(nameof(Index)); // Redirect to Index if pet not found
            }
        }


        // POST: Home/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var response = await _client.DeleteAsync($"{id}"); // Call API to delete the pet
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (HttpRequestException ex)
            {
                // Log the error or handle it appropriately
                Console.WriteLine($"Error deleting pet: {ex.Message}");
            }

            return RedirectToAction(nameof(Index)); // Redirect to Index even if there's an error
        }

        // GET: Home/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var response = await _client.GetStringAsync($"{id}"); // Call API to fetch the specific pet
                var petAnimal = JsonConvert.DeserializeObject<PetAnimal>(response);
                return View(petAnimal);
            }
            catch (HttpRequestException ex)
            {
                // Log the error or handle it appropriately
                Console.WriteLine($"Error fetching pet: {ex.Message}");
                return RedirectToAction(nameof(Index)); // Redirect to Index if pet not found
            }
        }

        // POST: Home/Edit/5
      
   
        [HttpPost]
        public async Task<IActionResult> Edit(int id, PetAnimal petAnimal)
        {
            if (id != petAnimal.petId)
            {
                return BadRequest(); // Ensure the id matches the petAnimal's ID
            }

            var json = JsonConvert.SerializeObject(petAnimal);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PutAsync($"{id}", content); // Call API to update the pet
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(petAnimal); // Return to the Edit view in case of failure
        }

    }
}
