using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace efcore
{
    public class SpellCaster
    {
        public int Id { get; set; }

        public int Level { get; set; }

        public ICollection<MagicSpell> Spells { get; set; } = new List<MagicSpell>();

        [Required]
        public string Name { get; set; }
    }
}