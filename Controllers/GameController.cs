using Microsoft.AspNetCore.Mvc;
using GuessTheNumberDB.Models;
using GuessTheNumberDB.Data;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GuessTheNumberDB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase
    {
        private readonly GuessingGameContext _context;

        public GameController(GuessingGameContext context)
        {
            _context = context;
        }

        [HttpPost("start")]
        public async Task<ActionResult<GuessResponse>> StartGame([FromBody] Game game)
        {
            game.GameId = Guid.NewGuid();
            game.IsGuessed = false;

            Random random = new Random();
            game.PreviousGuess = random.Next(game.LowerBound, game.UpperBound + 1);

            _context.Games.Add(game);
            await _context.SaveChangesAsync();

            return new GuessResponse
            {
                Guess = game.PreviousGuess,
                Message = $"Is your number {game.PreviousGuess}? (Type >, <, or =)",
                IsGuessed = false
            };
        }

        [HttpPost("guess/{gameId}")]
        public async Task<ActionResult<GuessResponse>> MakeGuess(Guid gameId, [FromBody] GuessRequest request)
        {
            var game = await _context.Games.FindAsync(gameId);
            if (game == null)
            {
                return NotFound("Game not found.");
            }

            if (game.IsGuessed)
            {
                return BadRequest("Game is already finished.");
            }

            if (request.Response == ">")
            {
                game.UpperBound = game.PreviousGuess - 1;
            }
            else if (request.Response == "<")
            {
                game.LowerBound = game.PreviousGuess + 1;
            }
            else if (request.Response == "=")
            {
                game.IsGuessed = true;
                await _context.SaveChangesAsync();
                return new GuessResponse
                {
                    Guess = game.PreviousGuess,
                    Message = "Number Guessed!",
                    IsGuessed = true
                };
            }

            Random random = new Random();
            game.PreviousGuess = random.Next(game.LowerBound, game.UpperBound + 1);
            await _context.SaveChangesAsync();

            return new GuessResponse
            {
                Guess = game.PreviousGuess,
                Message = $"Is your number {game.PreviousGuess}? (Type >, <, or =)",
                IsGuessed = false
            };
        }
    }
}
