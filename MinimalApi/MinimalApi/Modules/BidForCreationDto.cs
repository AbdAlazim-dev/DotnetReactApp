using System.ComponentModel.DataAnnotations;

namespace MinimalApi.Modules;

public record BidForCreationDto(int HouseId,
    [property: Required] string Bidder,
    int Amount);

