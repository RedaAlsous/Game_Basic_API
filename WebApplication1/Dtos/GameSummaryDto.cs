namespace WebApplication1.Dtos;

public record class GameSummaryDto(
    int id,
    string Name,
    string Genre,
    decimal price,
    DateOnly ReleaseDate
);

