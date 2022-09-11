using Microsoft.AspNetCore.Mvc;
using TestApplication.Models;

namespace TestApplication.Data
{
    public class GameData : IGameData
    {
        private GameDBContext _context;

        public GameData(GameDBContext context)
        {
            _context = context;
        }

        public Game AddGame(Game game)
        {
            _context.Games.Add(game);
            _context.SaveChanges();
            return game;
        }

        public void DeleteGame(Game game)
        {
            _context.Games.Remove(game);
            _context.SaveChanges();
        }

        public Game EditGame(Game game)
        {
            var existingGame = _context.Games.Find(game.Id);
            if (existingGame != null)
            {
                _context.Games.Update(existingGame);
                _context.SaveChanges();
            }
            return game;
        }

        public List<Game> GetGames()
        {
            return _context.Games.ToList();
        }

        public Game GetGame(int id)
        {
            var game = _context.Games.Find(id);
            return game;
        }

        public List<Game> GetGamesByGenre(string genre)
        {
            var games = _context.Games.ToList();
            var foundGames = new List<Game>();
            foreach (var game in games)
            {
                if (game.Genres.Contains(genre))
                    foundGames.Add(game);
            }
            return foundGames;
        }
    }
}
