using WebApplication1.Data;
using WebApplication1.Dtos;
using WebApplication1.Entites;
using WebApplication1.Mapping;

namespace WebApplication1.Endpoints;

public static class GamesEndpoints
{
    const string GetGameEndpointName = "GetGame";

    private static readonly List<GameSummaryDto> games = [
        new (
        1,
        "Street Fighter II",
        "Fighting",
        19.99M,
        new DateOnly(1992,7,15)),
    new (
        2,
        "Final FAntasy XIV",
        "Roleplaying",
        59.99M,
        new DateOnly(2010,9,30)),
    new(
        3,
        "FIFA 23",
        "Sports",
        69.99m,
        new DateOnly(2022,9,27))
    ];

    public static RouteGroupBuilder MapGamesEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("games").WithParameterValidation();

        // Get Games
        group.MapGet("/", () => games);

        // Get Games by id
        group.MapGet("/{id}", (int id , GameStoreContext dbContext) =>
        {
            Game? game = dbContext.Games.Find(id);

            return game is null ? 
            Results.NotFound() : Results.Ok(game.ToGameSDetailsDto());
        })
        .WithName(GetGameEndpointName);

        // Post /Games

        group.MapPost("/", (CreateGameDto newGame , GameStoreContext dbContext) =>
        {
            Game game= newGame.ToEntity();
            
            dbContext.Games.Add(game);
            dbContext.SaveChanges();

            return Results.CreatedAtRoute(GetGameEndpointName, new { id = game.Id }, game.ToGameSDetailsDto());

        });
        // Update

        group.MapPut("/{id}", (int id, UdateGameDto updatedGame) =>
        {
            var index = games.FindIndex(game => game.id == id);

            if (index == -1)
            {
                return Results.NotFound();
            }
            games[index] = new GameSummaryDto(
                id,
                updatedGame.Name,
                updatedGame.Genre,
                updatedGame.price,
                updatedGame.ReleaseDate

            );

            return Results.NoContent();
        });


        //  Delete
        group.MapDelete("/{id}", (int id) =>
        {
            games.RemoveAll(game => game.id == id);

            return Results.NoContent();
        });

        return group;

    }
}
