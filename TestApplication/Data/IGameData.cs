using TestApplication.Models;
namespace TestApplication.Data
{
    public interface IGameData
    {
        List<Game> GetGames();

        Game GetGame(int id);

        Game AddGame(Game game);

        void DeleteGame(Game game);

        Game EditGame(Game game);

        List<Game> GetGamesByGenre(string genre);
    }
}
