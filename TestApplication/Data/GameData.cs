using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
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

        public Game AddGame(Game newGame)
        {
            var ids = _context.Games.Select(x => x.Id).ToList();
            if (!ids.Contains(newGame.Id))
            {
                _context.Games.Add(new GameDBModel()
                {
                    Id = newGame.Id,
                    Name = newGame.Name,
                    Developer = newGame.Developer,
                    Genres = string.Join(", ", newGame.Genres)
                });
                _context.SaveChanges();
                return newGame;
            }
            return null;
        }

        public void DeleteGame(Game game)
        {
            var needToDeleteGame = new GameDBModel()
            {
                Id = game.Id,
                Name = game.Name,
                Developer = game.Developer,
                Genres = string.Join(", ", game.Genres)
            };
            _context.Games.Remove(needToDeleteGame);
            _context.SaveChanges();
        }

        public Game EditGame(Game game)
        {
            var existingGame = _context.Games.AsNoTracking().FirstOrDefault(x => x.Id == game.Id);
            if (existingGame != null)
            {
                _context.Games.Update(new GameDBModel()
                {
                    Id = game.Id,
                    Name = game.Name,
                    Developer = game.Developer,
                    Genres = string.Join(", ", game.Genres)
                });
                _context.SaveChanges();
            }
            return game;
        }

        public List<Game> GetGames()
        {
            var games = new List<Game>();
            _context.Games.AsNoTracking().ToList().ForEach(game => games.Add(new Game()
            {
                Id = game.Id,
                Name = game.Name,
                Developer = game.Developer,
                Genres = game.Genres.Split(", ")
            }));
            return games;
        }

        public Game GetGame(int id)
        {
            var game = _context.Games.AsNoTracking().Where(x => x.Id == id).FirstOrDefault();
            if (game == null)
                return null;
            return new Game()
            {
                Id = game.Id,
                Name = game.Name,
                Developer = game.Developer,
                Genres = game.Genres.Split(", ")
            };
        }

        public List<Game> GetGamesByGenre(string genre)
        {
            var games = new List<Game>();
            _context.Games.AsNoTracking().Where(x => x.Genres.Contains(genre)).ToList().ForEach(game => games.Add(new Game()
            {
                Id = game.Id,
                Name = game.Name,
                Developer = game.Developer,
                Genres = game.Genres.Split(", ")
            }));
            return games;
        }
    }
}
