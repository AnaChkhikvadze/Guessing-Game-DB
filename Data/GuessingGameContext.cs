using GuessTheNumberDB.Models;
using Microsoft.EntityFrameworkCore;

namespace GuessTheNumberDB.Data
{
    public class GuessingGameContext : DbContext
    {
        public GuessingGameContext(DbContextOptions<GuessingGameContext> options) : base(options) { }

        public DbSet<Game> Games { get; set; }
    }
}
