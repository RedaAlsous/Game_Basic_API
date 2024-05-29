namespace WebApplication1.Dtos;

public record class GameDetailsDto(
    int id,
    string Name,
    int GenreId,
    decimal price,
    DateOnly ReleaseDate
);

