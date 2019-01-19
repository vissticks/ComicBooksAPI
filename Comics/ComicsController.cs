using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComicBooksAPI.DAL;
using ComicBooksAPI.Exceptions;
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
            try
            {
                var comic = await _comics.Get(id);
                return Ok(comic);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
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
        public async Task<IActionResult> Put(Guid id, [FromBody] Comic value)
        {
            try
            {
                await _comics.Update(id, value);
                return Ok(await _comics.Get(id));
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _comics.Delete(id);
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    }
}