using SuperJero_Api.Data;
using Microsoft.EntityFrameworkCore;
using Entities;


namespace SuperJero_Api.Services
{
    public interface ISuperHeroService
    {
        Task<List<SuperHero>> GetSuperHeroes();
        Task<SuperHero?> GetSuperHero(int id);

        Task<List<SuperHero>> AddSuperHero(SuperHero hero);

        Task<List<SuperHero>> UpdateSuperHero(int id, SuperHero request);

        Task<List<SuperHero>> DeleteSuperHero(int id);
    }
}