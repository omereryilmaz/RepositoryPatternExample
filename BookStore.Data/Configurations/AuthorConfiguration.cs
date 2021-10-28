using BookStore.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Data.Configurations
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id)
                .UseIdentityColumn();
            builder.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(50);
            builder.ToTable("Authors");
        }
    }
}
