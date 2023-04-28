using CoffeeShopAPI3.Model;
using CoffeeShopAPI3.Services.Interface;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoffeeShopAPI3.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MenuController : ControllerBase
    {

        private readonly IMenuService _menuService;
        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }
        // GET: api/<MenuController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _menuService.SelectAll();
            return Ok(result);
        }

        // GET api/<MenuController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _menuService.SelectById(id);
            return Ok(result);
        }

        // POST api/<MenuController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MenuModel menu)
        {
            if (ModelState.IsValid)
            {
                await _menuService.Insert(menu);
                return Ok();
            }

            return Ok();

        }

        // PUT api/<MenuController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] MenuModel menu)
        {
            await _menuService.Update(menu,id);
            return Ok();
        }

        // DELETE api/<MenuController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _menuService.Delete(id);
            return Ok();
        }
    }
}
