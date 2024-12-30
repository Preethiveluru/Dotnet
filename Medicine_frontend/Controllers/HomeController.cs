using System.Diagnostics;
using Medicine_frontend.Models;
using Medicines_Management.Models;
using Microsoft.AspNetCore.Mvc;

namespace Medicine_frontend.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            IEnumerable<Medicine> Medicines = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5066/api/Medicines");
                var responseTask = client.GetAsync("Medicines");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadFromJsonAsync<IList<Medicine>>();
                    readTask.Wait();

                    Medicines = readTask.Result;
                }
                else
                {
                    Medicines = Enumerable.Empty<Medicine>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(Medicines);
        }


        // GET: Medicines/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Medicines/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Id, Name, ExpiryDate, Type, Price")] Medicine Medicine)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:5066/api/Medicines");

                    try
                    {
                        var postTask = client.PostAsJsonAsync("Medicines", Medicine);
                        postTask.Wait();

                        var result = postTask.Result;

                        if (result.IsSuccessStatusCode)
                        {
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            // Log API response for debugging
                            var errorDetails = result.Content.ReadAsStringAsync().Result;
                            ModelState.AddModelError(string.Empty, $"Error creating Medicines: {result.StatusCode} - {errorDetails}");
                        }
                    }
                    catch (Exception ex)
                    {
                        // Log any exceptions
                        ModelState.AddModelError(string.Empty, $"Exception occurred: {ex.Message}");
                    }
                }
            }
            return View(Medicine);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
