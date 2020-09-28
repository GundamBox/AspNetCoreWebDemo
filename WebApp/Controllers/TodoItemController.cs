using Entities.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Repository.CustomSearch;
using Services.Interfaces;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemController : ControllerBase
    {
        private readonly ITodoItemService _service;

        public TodoItemController(ITodoItemService service)
        {
            _service = service;
        }

        // GET: api/TodoItem
        [HttpGet]
        public IActionResult Get([FromQuery] TodoItemCustomSearch search)
        {
            return Ok(_service.List(search));
        }
        // GET: api/TodoItem/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_service.Get(id));
        }
        // POST: api/TodoItem
        [HttpPost]
        public IActionResult Post([FromBody] TodoItemCreateViewModel value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            TodoItemGetViewModel model = _service.Create(value);
            return CreatedAtRoute("DefaultApi", new { model.Id }, model);
        }
        // PUT: api/TodoItem/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] TodoItemUpdateViewModel value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(_service.Update(id, value));
        }
        // DELETE: api/TodoItem/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.Delete(id);
        }
    }
}
