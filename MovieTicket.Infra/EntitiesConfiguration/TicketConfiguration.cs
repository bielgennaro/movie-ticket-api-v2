using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MovieTicket.Domain.Entities;

namespace MovieTicket.Infra.Data.EntitiesConfiguration
{
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure( EntityTypeBuilder<Ticket> builder )
        {
            builder.ToTable( "Tickets" );

            builder.HasKey( t => t.Id );

            builder.Property( t => t.Id ).HasColumnName( "id" );

            builder.HasOne( t => t.Session )
                   .WithMany()
                   .HasForeignKey( t => t.SessionId )
                   .HasConstraintName( "session_id" );

            builder.HasOne( t => t.User )
                   .WithMany()
                   .HasForeignKey( t => t.UserId )
                   .HasConstraintName( "user_id" );
        }
    }
}
