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
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TaboDbContex).Assembly);
            base.OnModelCreating(modelBuilder);
        }
     
    }
}
