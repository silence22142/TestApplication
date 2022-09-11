using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestApplication.Data;
using TestApplication.Models;

namespace TestApplication.Controllers
{
    [ApiController]
    public class GamesController : ControllerBase
    {
        private IGameData _gameData;

        public GamesController(IGameData gameData)
        {
            _gameData = gameData;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetGames()
        {
            return Ok(_gameData.GetGames());
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetGame(int id)
        {
            var game = _gameData.GetGame(id);
            if (game != null)
                return Ok(_gameData.GetGame(id));
            return NotFound($"Game with ID: {id} was not found");
        }

        [HttpGet]
        [Route("api/[controller]/games/{genre}")]
        public IActionResult GetGamesByGenre(string genre)
        {
            var games = _gameData.GetGamesByGenre(genre);
            if (games != null)
                return Ok(games);
            return NotFound($"Games with genre: {genre} was not found");
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult AddGame(Game game)
        {
            _gameData.AddGame(game);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host
                           + HttpContext.Request.Path + "/" + game.Id, game);
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult DeleteGame(int id)
        {
            var game = _gameData.GetGame(id);
            if (game != null)
            {
                _gameData.DeleteGame(game);
                return Ok();
            }
            return NotFound($"Game with ID: {id} was not found");
        }

        [HttpPatch]
        [Route("api/[controller]/{id}")]
        public IActionResult EditGame(int id, Game game)
        {
            var existingGame = _gameData.GetGame(id);
            if (existingGame != null)
            {
                game.Id = existingGame.Id;
                _gameData.EditGame(game);
            }

            return Ok(game);
        }
    }
}
