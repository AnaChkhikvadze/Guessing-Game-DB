using System.ComponentModel.DataAnnotations;

namespace GuessTheNumberDB.Models
{
    public class Game
    {
        [Key]
        public Guid GameId { get; set; }
        public int LowerBound { get; set; }
        public int UpperBound { get; set; }
        public int PreviousGuess { get; set; }
        public bool IsGuessed { get; set; }
    }

}
