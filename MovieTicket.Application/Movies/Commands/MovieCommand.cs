using MediatR;

using MovieTicket.Domain.Entities;

namespace MovieTicket.Application.Movies.Commands
{
    public abstract class MovieCommand : IRequest<Movie>
    {
        public string Gender { get; set; }
        public string Synopsis { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public string BannerUrl { get; set; }
    }
}
