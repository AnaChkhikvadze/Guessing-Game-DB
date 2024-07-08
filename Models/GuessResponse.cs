namespace GuessTheNumberDB.Models
{
    public class GuessResponse
    {
        public int Guess { get; set; }
        public string Message { get; set; }
        public bool IsGuessed { get; set; }
    }
}
