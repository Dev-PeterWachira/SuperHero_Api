using System.ComponentModel.DataAnnotations;

namespace DTOs
{
    public class UserResponseDTO
    {
        public Guid Id {get; set;} 

        public string Username {get; set;} = string.Empty;
    }
}