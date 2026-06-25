using System.ComponentModel.DataAnnotations;
namespace DTOs
{
public class RegisterDTO
{
    [Required]
    [StringLength(50, MinimumLength = 3)]

    public string Username {get; set;} = string.Empty;

    [Required]
    [MinLength(8)]
    public string Password {get; set;} = string.Empty;
}
}