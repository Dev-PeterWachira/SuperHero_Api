using System.ComponentModel.DataAnnotations;

namespace DTOS {
    public class CreateSuperHeroDTO{
        [Required]
        [MinLength(20)]
        public string Name {get; set;} = string.Empty;

        [Required]
        public string FirstName {get; set;} = string.Empty;

        [Required]
        public string LastName {get; set;} = string.Empty;

       
    }
 }