using DTOs;

namespace Services;

public interface IAuthService
{
    Task<UserResponseDTO?> RegisterAsync(RegisterDTO request);

    Task<string?> LoginAsync(LoginDTO request);
}