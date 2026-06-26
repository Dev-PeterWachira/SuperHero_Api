using DTOS;


namespace Services
{
    public interface ISuperHeroService
    {
        Task<IEnumerable<SuperHeroResponseDTO>> GetSuperHeroesAsync();

        Task<SuperHeroResponseDTO?> GetSuperHeroAsync(int id);

        Task<SuperHeroResponseDTO> AddSuperHeroAsync(CreateSuperHeroDTO request);

        Task<SuperHeroResponseDTO?> UpdateSuperHeroAsync(int id, UpdateSuperHeroDTO request);

        Task<bool> DeleteSuperHeroAsync(int id);

    }
}