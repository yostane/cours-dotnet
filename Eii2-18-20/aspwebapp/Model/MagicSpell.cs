using System.ComponentModel.DataAnnotations;

namespace efcore
{
    public class MagicSpell
    {
        public int Id { get; set; }

        public int Damage { get; set; }

        [Required]
        public string Name { get; set; }
    }
}