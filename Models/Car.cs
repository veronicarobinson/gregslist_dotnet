using System.ComponentModel.DataAnnotations;

namespace gregslist_api_dotnet.Models;

public class Car
{
  public int Id { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
  [MinLength(3), MaxLength(50)] public string Make { get; set; }
  [MinLength(1), MaxLength(100)] public string Model { get; set; }
  // NOTE ? denotes that year will default to null instead of 0 now
  [Range(1886, 2026)] public int? Year { get; set; }
  [Range(0, 1000000)] public int? Price { get; set; }
  [Url, MaxLength(500)] public string ImgUrl { get; set; }
  [MaxLength(500)] public string Description { get; set; }
  public string EngineType { get; set; }
  [MaxLength(50)] public string Color { get; set; }
  [Range(0, 1000000)] public int? Mileage { get; set; }
  public bool? HasCleanTitle { get; set; }
  public string CreatorId { get; set; }
  public Profile Creator { get; set; }
}