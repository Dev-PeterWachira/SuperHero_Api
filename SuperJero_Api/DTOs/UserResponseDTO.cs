using System.ComponentModel.DataAnnotations;

namespace DTOs
{
    public class UserResponseDTO
    {
        public string Id {get; set;} = string.Empty;

        public string Username {get; set;} = string.Empty;
    }
}