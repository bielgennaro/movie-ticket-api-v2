using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MovieTicket.Domain.Entities;

namespace MovieTicket.Infra.Data.EntitiesConfiguration
{
    public class SessionConfiguration : IEntityTypeConfiguration<Session>
    {
        public void Configure( EntityTypeBuilder<Session> builder )
        {
            builder.ToTable( "Sessions" );

            builder.HasKey( s => s.Id );

            builder.Property( s => s.Id ).HasColumnName( "id" );

            builder.Property( s => s.Room ).HasColumnName( "room" );

            builder.Property( s => s.Date ).HasColumnName( "date" );

            builder.Property( s => s.Price )
                .HasColumnName( "price" );

            builder.Property( s => s.AvailableTickets ).HasColumnName( "available_tickets" );

            builder.HasOne( s => s.Movie )
                    .WithMany()
                   .HasForeignKey( s => s.MovieId )
                   .HasConstraintName( "movie_id" );
        }
    }
}
