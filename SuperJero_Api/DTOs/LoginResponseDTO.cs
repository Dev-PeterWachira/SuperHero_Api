using System.ComponentModel.DataAnnotations;

namespace DTOS
{
    public class LoginResponseDTO
    {
        public string Token {get; set;} = string.Empty;
    }
}