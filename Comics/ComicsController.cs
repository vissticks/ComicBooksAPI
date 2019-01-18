using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComicBooksAPI.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComicBooksAPI.Comics
{
    [Route("api/[controller]")]
    public class ComicsController : Controller
    {
        private readonly ComicsService _comics;

        public ComicsController(ComicsService comics)
        {
            _comics = comics;
        }

        // GET: api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _comics.GetAll());
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var comic = await _comics.Get(id);
            if (comic != null)
            {
                return Ok(comic);
            }

            return NotFound();
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Comic comic)
        {
            var result = await _comics.Create(comic);
            return Ok(result);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var comic = await _comics.Get(id);
            if (comic == null) return NotFound();

            await _comics.Delete(id);
            return Ok();
        }
    }
}