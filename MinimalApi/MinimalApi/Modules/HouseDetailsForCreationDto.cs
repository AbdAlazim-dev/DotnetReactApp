namespace MinimalApi.Modules;

public record HouseForCreationDto(
    string? Address,
    string? Country,
    string? Description,
    decimal Price,
    string? Photo);
