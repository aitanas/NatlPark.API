using Microsoft.EntityFrameworkCore;

namespace ParkApi.Models
{
  public class ParkApiContext : DbContext
  {
    public DbSet<Park> Parks { get; set; }

    public ParkApiContext(DbContextOptions<ParkApiContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Park>()
        .HasData(
          new Park { ParkId = 1, Name ="Olympic National Park", State = "WA", Climate = "Temperate Rainforest", DogFriendly = "No", Image = "https://olympicpeninsula.org/wp-content/uploads/2018/07/Hall-of-Mosses-Trail-Hoh-Rain-Forest-2.jpg" }
        );
    }
  }
}