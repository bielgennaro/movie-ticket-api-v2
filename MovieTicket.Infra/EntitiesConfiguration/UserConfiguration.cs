#region

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MovieTicket.Domain.Entities;

#endregion

namespace MovieTicket.Infra.Data.EntitiesConfiguration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure( EntityTypeBuilder<User> builder )
    {
        builder.ToTable( "Users" );

        builder.HasKey( u => u.Id )
            .HasName( "pk_users" );

        builder.Property( u => u.Email )
            .HasColumnName( "email" )
            .HasMaxLength( 100 );

        builder.Property( u => u.Password )
            .HasColumnName( "password" );

        builder.Property( u => u.IsAdmin )
            .HasColumnName( "is_admin" );
    }
}