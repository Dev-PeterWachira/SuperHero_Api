
using Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using SuperJero_Api.Data;

namespace SuperJero_Api.Services
{
    public class Services : ISuperHeroService
    {
        private readonly Database _context;
        
        public Services(Database context)
        {
            _context = context;
        }

        public async Task<List<SuperHero>> GetSuperHeroes()
        {
            return await _context.SuperHeroes.ToListAsync();
        }

        public async Task<SuperHero?> GetSuperHero(int id)
        {
            return await _context.SuperHeroes.FindAsync(id);
        }

        public async Task<List<SuperHero>> AddSuperHero(SuperHero hero)
        {
            _context.SuperHeroes.Add(hero);
            await _context.SaveChangesAsync();

            return await _context.SuperHeroes.ToListAsync();
        }

        public async Task<List<SuperHero>> UpdateSuperHero(int id, SuperHero request)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);

            if(hero == null)
            {
                return await _context.SuperHeroes.ToListAsync();
            }

            hero.Name = request.Name;
            hero.FirstName = request.FirstName;
            hero.LastName = request.LastName;
            hero.Place = request.Place;

            await _context.SaveChangesAsync();
            return await _context.SuperHeroes.ToListAsync();

        }

        public async Task<List<SuperHero>> DeleteSuperHero(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);

            if(hero == null)
            {
                return await _context.SuperHeroes.ToListAsync();
            }
            

            _context.SuperHeroes.Remove(hero);
            await _context.SaveChangesAsync();
            return await _context.SuperHeroes.ToListAsync();
        }
    }
}