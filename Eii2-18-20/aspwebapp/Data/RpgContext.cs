using Microsoft.EntityFrameworkCore;

namespace efcore
{
    public class RpgContext : DbContext
    {
        public DbSet<MagicSpell> MagicSpells { get; set; }
        public DbSet<SpellCaster> SpellCasters { get; set; }

        public RpgContext(DbContextOptions<RpgContext> options) : base(options)
        {
        }
    }
}