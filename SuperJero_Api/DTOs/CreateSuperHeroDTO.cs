using System.ComponentModel.DataAnnotations;

namespace DTOS {
    public class CreateSuperHeroDTO{
        [Required]
        [MinimumLength(20)]
        public string Name {get; set;} = string.Empty;

        [Required]
        public string FirstName {get; set;} = string.Empty;

        [Required]
        public string LastName {get; set;} = string.Empty;

        // [Required]
        // [MinimumLength(30)]
        // public string Password {get; set;} = string.Empty;
    }
 }