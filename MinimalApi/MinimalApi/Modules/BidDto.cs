using System.ComponentModel.DataAnnotations;

namespace MinimalApi.Modules;

public record BidDto(int Id,
    int HouseId,
    [property: Required] string Bidder,
    int Amount);
