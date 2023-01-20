namespace ParkApi.Models
{
  public class Park
  {
    public int ParkId { get; set; }
    public string Name { get; set; }
    public string State { get; set; }
    public string Climate { get; set; }
    public string DogFriendly { get; set; }
    public string Image { get; set; }
  }
}