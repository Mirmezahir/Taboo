using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Taboo.Entities;

namespace Taboo.Configutations
{
    public class WordConfiguration : IEntityTypeConfiguration<Word>
    {
        void IEntityTypeConfiguration<Word>.Configure(EntityTypeBuilder<Word> builder)
        {
            builder.Property(x => x.Text)
               .IsRequired()
               .HasMaxLength(32);
            builder.HasOne(x => x.Language)
            .WithMany(x => x.Words)
            .HasForeignKey(x => x.LanguageCode);
            builder.HasMany(x => x.BannedWords)
            .WithOne(x => x.Word)
            .HasForeignKey(x => x.WordId);
        }
    }
}
