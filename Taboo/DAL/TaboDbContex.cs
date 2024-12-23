using Microsoft.EntityFrameworkCore;
using Taboo.Entities;

namespace Taboo.DAL
{
    public class TaboDbContex : DbContext
    {
        
        public TaboDbContex(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Language> Languages { get; set; }  
        public DbSet<Word> Words { get; set; }  
        public DbSet<BannedWord> BannedWords { get; set; }  
        public DbSet<Game> Games { get; set; }  
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Language>(b =>
            {
                b.HasKey(x=>x.Code);
                b.HasIndex(x=>x.Name).IsUnique();
                b.Property(x => x.Code)
                .IsFixedLength(true)
                .HasMaxLength(2);
                b.Property(x=> x.Name)
                .IsRequired()
                .HasMaxLength(32);
                b.Property(x => x.Icon)
                .HasMaxLength(124);
            });
            modelBuilder.Entity<Word>(w =>
            {
                w.Property(x=>x.Text)
                .IsRequired()
                .HasMaxLength(32);
                w.HasOne(x=>x.Language)
                .WithMany(x => x.Words)
                .HasForeignKey(x => x.LanguageCode);
                w.HasMany(x => x.BannedWords)
                .WithOne(x => x.Word)
                .HasForeignKey(x => x.WordId);


            });
            modelBuilder.Entity<Game>(g =>
            {
                g.HasOne(x => x.Language)
                .WithMany(x => x.Games)
                .HasForeignKey(x => x.LanguageCode);

            });
            base.OnModelCreating(modelBuilder);
        }
     
    }
}
