using Entities;
using SuperJero_Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Services;
using Microsoft.AspNetCore.Authorization;
using DTOS;


namespace SuperJero_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SuperHeroController : ControllerBase
    {

        private readonly ISuperHeroService _service;
        private readonly ILogger<SuperHeroController> _logger;

        public SuperHeroController(ISuperHeroService service, ILogger<SuperHeroController> logger)
        {
            _service = service;
            _logger = logger;
        }
        
        [HttpGet]
        public async Task<ActionResult<SuperHero>> GetSuperHeroes()
        {
            var heroes = await _service.GetSuperHeroesAsync();
            if(heroes == null)
            {
                return NotFound("No Heroes Found.");
            }
            return Ok(heroes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetSuperHeroAsync(int id)
        {
            var user = await _service.GetSuperHeroAsync(id);
            if(user == null)
            {
                return NotFound("Hero Not Found.");
            }
            return Ok(user);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddSuperHero(CreateSuperHeroDTO request)
        {
            var hero = await _service.AddSuperHeroAsync(request);
          
            return CreatedAtAction(
                nameof(GetSuperHeroAsync),
                new {id = hero.Id},
                hero
            );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSuperHero(int id, UpdateSuperHeroDTO request)
        {
            var hero = await _service.UpdateSuperHeroAsync(id, request);

            if(hero == null)
            {
                return NotFound("Hero Not Found.");
            }
            return Ok(hero);
        }
         [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSuperHero (int id)
        {
            var deleted = await _service.DeleteSuperHeroAsync(id);
            if(deleted == false)
            {
                return NotFound("Hero Not Found.");
            }
             return NoContent();
        }

              
    }
}

