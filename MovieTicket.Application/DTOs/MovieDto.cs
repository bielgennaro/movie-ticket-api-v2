#region

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

#endregion

namespace MovieTicket.Application.DTOs;

public class MovieDto
{
    [JsonIgnore]
    public int Id { get; set; }

    [Required(ErrorMessage = "Please enter a gender")]
    [MinLength(3)]
    [MaxLength(100)]
    [Display(Name = "Gender")]
    public required string Gender { get; set; }

    [Required(ErrorMessage = "Please enter a synopsis")]
    [MinLength(3)]
    [MaxLength(100)]
    [Display(Name = "Synopsis")]
    public required string Synopsis { get; set; }

    [Required(ErrorMessage = "Please enter a title")]
    [MinLength(3)]
    [MaxLength(100)]
    [Display(Name = "Title")]
    public required string Title { get; set; }

    [Required(ErrorMessage = "Please enter a director")]
    [MinLength(3)]
    [MaxLength(100)]
    [Display(Name = "Director")]
    public required string Director { get; set; }

    [Required(ErrorMessage = "Please enter a banner url")]
    [MinLength(3)]
    [MaxLength(255)]
    [DataType(DataType.Url)]
    [Display(Name = "Banner Url")]
    public required string BannerUrl { get; set; }
}