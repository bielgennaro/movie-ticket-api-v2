using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MovieTicket.Domain.Entities;

namespace MovieTicket.Infra.Data.EntitiesConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure( EntityTypeBuilder<User> builder )
        {
            builder.ToTable( "Users" );

            builder.HasKey( u => u.Id );

            builder.Property( u => u.Email )
                   .HasColumnName( "email" )
                   .HasMaxLength( 100 );

            builder.Property( u => u.IsAdmin )
                   .HasColumnName( "is_admin" );

            builder.Property( u => u.HashedPassword )
                   .HasColumnName( "hashed_password" )
                   .HasMaxLength( 100 );
        }
    }
}
