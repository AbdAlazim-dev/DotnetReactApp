using System.ComponentModel.DataAnnotations;

namespace MinimalApi.Modules;

//Learning to use record on Dtos
public record HouseDetailsDto(int Id,
    [property : Required] string? Address,
    [property: Required] string? Country,
    string? Description,
    decimal Price,
    string? Photo);

