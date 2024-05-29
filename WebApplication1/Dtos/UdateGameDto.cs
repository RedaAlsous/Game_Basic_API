using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Dtos;

public record class UdateGameDto(
    
    [Required][StringLength(50)]string Name,
    [Required][StringLength(20)]string Genre,
    [Required][Range(1,100)]decimal price,
    DateOnly ReleaseDate
);
