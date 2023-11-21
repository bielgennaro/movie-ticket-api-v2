#region

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MovieTicket.Domain.Entities;

#endregion

namespace MovieTicket.Infra.Data.EntitiesConfiguration
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.ToTable("Movies");

            builder.HasKey(m => m.Id);

            builder.Property(m => m.Gender).HasColumnName("gender");

            builder.Property(m => m.Synopsis).HasColumnName("synopsis");

            builder.Property(m => m.Director).HasColumnName("director");

            builder.Property(m => m.BannerUrl).HasColumnName("banner_url");

            builder.Property(m => m.Title).HasColumnName("title");
        }
    }
}