using Microsoft.AspNetCore.Mvc;
using TestApplication.Data;
using TestApplication.Models;

namespace TestApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GamesController : ControllerBase
    {
        private IGameData _gameData;

        public GamesController(IGameData gameData)
        {
            _gameData = gameData;
        }

        [HttpGet]
        public IActionResult GetGames()
        {
            return Ok(_gameData.GetGames());
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetGame(int id)
        {
            var game = _gameData.GetGame(id);
            if (game != null)
                return Ok(_gameData.GetGame(id));
            return NotFound($"Game with ID: {id} was not found");
        }

        [HttpGet]
        [Route("genres/{genre}")]
        public IActionResult GetGamesByGenre(string genre)
        {
            var games = _gameData.GetGamesByGenre(genre);
            if (games != null)
                return Ok(games);
            return NotFound($"Games with genre: {genre} was not found");
        }

        [HttpPost]
        public IActionResult AddGame(Game game)
        {
            var addedGame = _gameData.AddGame(game);
            if (addedGame != null)
                return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host
                           + HttpContext.Request.Path + "/" + addedGame.Id, addedGame);
            return Conflict("Already exist");
        }

        [HttpDelete]
        [Route("{id}")]
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
        [Route("{id}")]
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
