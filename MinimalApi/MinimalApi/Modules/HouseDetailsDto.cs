namespace MinimalApi.Modules;

//Learning to use record on Dtos
public record HouseDetailsDto(int Id,
    string? Address,
    string? Country,
    string? Description,
    decimal Price,
    string? Photo);

