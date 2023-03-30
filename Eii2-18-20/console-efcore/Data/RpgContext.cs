using Microsoft.EntityFrameworkCore;

namespace efcore
{
    public class RpgContext : DbContext
    {
        public DbSet<MagicSpell> MagicSpells { get; set; }
        public DbSet<SpellCaster> SpellCasters { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=database.db");
        }

    }
}