
using Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using SuperJero_Api.Data;
using DTOS;
 

namespace Services
{
    public class SuperHeroService : ISuperHeroService
    {
        private readonly Database _context;
        
        public SuperHeroService(Database context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SuperHeroResponseDTO>> GetSuperHeroesAsync()
        {
            return await _context.SuperHeroes
            .AsNoTracking()
            .Select(hero => new SuperHeroResponseDTO
            {
                Id = hero.Id,
                Name = hero.Name,
                FirstName = hero.FirstName,
                LastName = hero.LastName,
                Place = hero.Place
            })
            .ToListAsync();
        }

        public async Task<SuperHeroResponseDTO?> GetSuperHeroAsync(int id)
        {
            return await _context.SuperHeroes
            .AsNoTracking()
            .Where(h => h.Id == id)
            .Select(h => new SuperHeroResponseDTO
            {
                Id = h.Id,
                Name = h.Name,
                FirstName = h.FirstName,
                LastName = h.LastName,
                Place = h.Place
            })
            .FirstOrDefaultAsync();
        }

        public async Task<SuperHeroResponseDTO> AddSuperHeroAsync(CreateSuperHeroDTO request)
        {
            var hero = new SuperHero
            {
                Name = request.Name,
                FirstName = request.FirstName,
                LastName = request.LastName
            };
            _context.SuperHeroes.Add(hero);
           await _context.SaveChangesAsync();

           return new SuperHeroResponseDTO
           {
               Id = hero.Id,
               Name = hero.Name,
               FirstName = hero.FirstName,
               LastName = hero.LastName,
               Place = hero.Place
           };
        }

        public async Task<SuperHeroResponseDTO?> UpdateSuperHeroAsync(int id, UpdateSuperHeroDTO request)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);

            if(hero == null)
            {
                return null;
            }

            hero.Name = request.Name;
            hero.FirstName = request.FirstName;
            hero.LastName = request.LastName;
            hero.Place = request.Place;

            await _context.SaveChangesAsync();
            
            return new SuperHeroResponseDTO
            {
                Id = hero.Id,
                Name = hero.Name,
                FirstName = hero.FirstName,
                LastName = hero.LastName,
                Place = hero.Place
            };

        }

        public async Task<bool> DeleteSuperHeroAsync(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);

            if(hero == null)
            {
                return false;
            }
            

            _context.SuperHeroes.Remove(hero);
            await _context.SaveChangesAsync();
           return true;
        }

    }
}