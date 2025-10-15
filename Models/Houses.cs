using System.ComponentModel.DataAnnotations;

namespace gregslist_api_dotnet.Models;

public class House
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    [Range(0, 1000000)] public int? Sqft { get; set; }

    [Range(0, 100)] public int? Bedrooms { get; set; }

    [Range(0, 10)] public double? Bathrooms { get; set; }

    [Url, MaxLength(255)] public string ImgUrl { get; set; }

    [MaxLength(255)] public string Description { get; set; }

    public int? Price { get; set; }
    public string CreatorId { get; set; }
    public Profile Creator { get; set; }

}