using System.ComponentModel.DataAnnotations;

namespace MinimalApi.Modules;

public record HouseForCreationDto(
    [property: Required] string? Address,
    [property: Required, MaxLength(100, ErrorMessage = "There is no country have more then 100 letter")] string? Country,
    string? Description,
    decimal Price,
    string? Photo);
