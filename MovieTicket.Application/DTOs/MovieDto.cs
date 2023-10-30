#region

using System.ComponentModel.DataAnnotations;

#endregion

namespace MovieTicket.Application.DTOs;

public class MovieDto
{
    public int Id { get; set; }

    [Required( ErrorMessage = "Please enter a gender" )]
    [MinLength( 3 )]
    [MaxLength( 100 )]
    [Display( Name = "Gender" )]
    public string Gender { get; set; }

    [Required( ErrorMessage = "Please enter a synopsis" )]
    [MinLength( 3 )]
    [MaxLength( 100 )]
    [Display( Name = "Synopsis" )]
    public string Synopsis { get; set; }

    [Required( ErrorMessage = "Please enter a title" )]
    [MinLength( 3 )]
    [MaxLength( 100 )]
    [Display( Name = "Title" )]
    public string Title { get; set; }

    [Required( ErrorMessage = "Please enter a director" )]
    [MinLength( 3 )]
    [MaxLength( 100 )]
    [Display( Name = "Director" )]
    public string Director { get; set; }

    [Required( ErrorMessage = "Please enter a banner url" )]
    [MinLength( 3 )]
    [MaxLength( 255 )]
    [DataType( DataType.Url )]
    [Display( Name = "Banner Url" )]
    public string BannerUrl { get; set; }
}