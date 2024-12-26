using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Taboo.Entities;

namespace Taboo.Configutations
{
    public class LanguageConfiguration : IEntityTypeConfiguration<Language>
    {
        void IEntityTypeConfiguration<Language>.Configure(EntityTypeBuilder<Language> builder)
        {
            builder.HasKey(x => x.Code);
            builder.HasIndex(x => x.Name).IsUnique();
            builder.Property(x => x.Code)
                    .IsFixedLength(true)
                    .HasMaxLength(2);
            builder.Property(x => x.Name)
                    .IsRequired()
                    .HasMaxLength(32);
            builder.Property(x => x.Icon)
                    .HasMaxLength(124);
        }
    }
}
