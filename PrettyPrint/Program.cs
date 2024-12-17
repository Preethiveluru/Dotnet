using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;

namespace SampleApp
{


    public class Class
    {
        static void Main()
        {
            Calci cal = new Calci();
            cal.GetMessage();
        }
    }

    public class Calci
    {
        public void GetMessage()
        {
            string msg;
            using (var httpClient = new HttpClient())
            {
                Console.WriteLine("Enter your Code");
                int pincode = Convert.ToInt32(Console.ReadLine());

                using (var response = httpClient.GetAsync($"https://api.postalpincode.in/pincode/{pincode}"))
                {
                    string apiResponse = response.Result.Content.ReadAsStringAsync().Result;
                    var jsonElement = JsonSerializer.Deserialize<JsonElement>(apiResponse);
                    var options = new JsonSerializerOptions { WriteIndented = true };
                    string prettyJson = JsonSerializer.Serialize(jsonElement, options);
                    Console.WriteLine(prettyJson);
                    msg = apiResponse;
                }
            }
        }
    }
}


