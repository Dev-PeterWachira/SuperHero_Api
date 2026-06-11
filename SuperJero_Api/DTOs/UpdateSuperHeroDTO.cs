using System.ComponentModel.DataAnnotations;

namespace DTOS
{
public class UpdateSuperHeroDTO
{
[Required]
[StringLength(100)]
public string Name  {get; set;} = string.Empty;

[Required]
[StringLength(100)]
public string FirstName {get; set;} = string.Empty;

[Required]
[StringLength(100)]
public string LastName {get; set;} = string.Empty;

[Required]
[StringLength(100)]
public string Place {get; set;} = string.Empty;
}
}