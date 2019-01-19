using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ComicBooksAPI.Exceptions;
using ComicBooksAPI.Titles.Models;
using Microsoft.AspNetCore.Mvc;

namespace ComicBooksAPI.Titles
{
    [Route("api/[controller]")]
    public class TitlesController : Controller
    {
        private readonly TitlesService _titles;
        private readonly IMapper _mapper;

        public TitlesController(TitlesService titles, IMapper mapper)
        {
            _titles = titles;
            _mapper = mapper;
        }

        // GET: api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(_mapper.Map<IEnumerable<TitleDto>>(await _titles.GetAllTitles()));
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var title = _mapper.Map<TitleExtendedDto>(await _titles.GetTitle(id));
                return Ok(title);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TitleDto title)
        {
            var result = await _titles.Create(_mapper.Map<Title>(title));
            return Ok(_mapper.Map<TitleDto>(result));
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] TitleDto value)
        {
            try
            {
                await _titles.Update(id, _mapper.Map<Title>(value));
                return Ok(_mapper.Map<TitleDto>(await _titles.Get(id)));
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
                await _titles.Delete(id);
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    }
}