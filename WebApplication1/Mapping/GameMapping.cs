using WebApplication1.Dtos;
using WebApplication1.Entites;

namespace WebApplication1.Mapping;

public static class GameMapping
{
    public static Game ToEntity(this CreateGameDto game)
    {
        return new Game ()
            {
                Name = game.Name,
                GenreId = game.GenreId,
                price = game.price,
                ReleaseDate = game.ReleaseDate
            };
    }

    public static GameSummaryDto ToGameSummaryDto(this Game game)
    {
        return new (
                game.Id,
                game.Name,
                game.Genre!.Name,
                game.price,
                game.ReleaseDate
        );
    }


    public static GameDetailsDto ToGameSDetailsDto(this Game game)
    {
        return new (
                game.Id,
                game.Name,
                game.GenreId,
                game.price,
                game.ReleaseDate
        );
    }
}
