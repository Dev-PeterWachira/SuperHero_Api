using Entities;
using SuperJero_Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using SuperJero_Api.Services;


namespace SuperJero_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SuperHeroController : ControllerBase
    {
        private readonly Database _context;
        public SuperHeroController(Database context)
        {
            _context = context;
        }


        private readonly ISuperHeroService _service;

        public SuperHeroController(ISuperHeroService service)
        {
            _service = service;
        }
        
        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetSuperHeroes()
        {
            var result = await _service.GetSuperHeroes();
            if(result == null)
            {
                return NotFound("No Heroes Found.");
            }
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetSuperHero(int id)
        {
            var user = await _service.GetSuperHero(id);
            if(user == null)
            {
                return NotFound("Hero Not Found.");
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddSuperHero(SuperHero hero)
        {
            var result = await _service.AddSuperHero(hero);
            if(result == null)
            {
                return BadRequest("Hero Not Added.");
            }
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<SuperHero>>> UpdateSuperHero(int id, SuperHero request)
        {
            var result = await _service.UpdateSuperHero(id, request);

            if(result == null)
            {
                return NotFound("Hero Not Found.");
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> DeleteSuperHero (int id)
        {
            var result = await _service.DeleteSuperHero(id);
            if(result == null)
            {
                return NotFound("Hero Not Found.");
            }
             return Ok(result);
        }

        }
    }

