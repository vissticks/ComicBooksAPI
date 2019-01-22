using System;
using System.Collections;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Principal;
using System.Threading.Tasks;
using AutoMapper;
using ComicBooksAPI.Comics.Models;
using ComicBooksAPI.Exceptions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace ComicBooksAPI.Comics
{
    [Authorize]
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("api/[controller]")]
    public class ComicsController : Controller
    {
        private readonly ComicsService _comics;
        private readonly IMapper _mapper;

        public ComicsController(ComicsService comics, IMapper mapper)
        {
            _comics = comics;
            _mapper = mapper;
        }

        // GET: api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var comics = _mapper.Map<IEnumerable<ComicDto>>(await _comics.GetAllComics());
            return Ok(comics);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var comic = await _comics.GetComic(id);
                return Ok(_mapper.Map<ComicExtendedDto>(comic));
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        // POST api/<controller>
        [HttpPost]
        [RequestSizeLimit(100_000_000)] // ~100 mb
        [Consumes("multipart/form-data")]
        public IActionResult Post([FromForm] List<IFormFile> files)
        {
            var user = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            foreach (var file in files)
            {

            }
            return Ok(user);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] ComicDto value)
        {
            try
            {
                await _comics.Update(id, _mapper.Map<Comic>(value));
                return Ok(_mapper.Map<ComicExtendedDto>(await _comics.GetComic(id)));
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