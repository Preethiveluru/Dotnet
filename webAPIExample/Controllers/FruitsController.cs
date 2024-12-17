using Microsoft.AspNetCore.Mvc;

namespace webAPIExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FruitsController : ControllerBase
    {
        // Using a static list to simulate a data store
        private static readonly IList<string> _Fruits = new List<string>
        {
            "apple", "banana", "kiwi", "pomegranate", "orange"
        };

        // GET: api/<FruitsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            // Return all fruits

            return _Fruits.ToList();
        }

        // GET api/<FruitsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            

            return Ok(_Fruits[id]);
        }

        // POST api/<FruitsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
   

            _Fruits.Add(value);
           
        }

        // PUT api/<FruitsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string value)
        {
            
            _Fruits[id] = value;
            return Ok("Fruit updated successfully!");
        }

        // DELETE api/<FruitsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            

            _Fruits.RemoveAt(id);
            return Ok("Fruit deleted successfully!");
        }
    }
}
