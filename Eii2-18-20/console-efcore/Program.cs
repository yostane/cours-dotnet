using System;
using System.Collections.Generic;
using System.Linq;
using efcore;

namespace console_efcore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            /**
            var context = new RpgContext(); // ouverture de la connexion
            ...code
            context.Dispose(); // fermer la connextion à la BDD
            */

            using (var context = new RpgContext())
            {
                context.MagicSpells.Add(new MagicSpell { Name = "Hadouken", Damage = 25 });
                context.MagicSpells.Add(new MagicSpell { Name = "Fireball", Damage = 50 });
                context.SpellCasters.Add(new SpellCaster
                {
                    Name = "Sangoku",
                    Level = 200
                ,
                    Spells = new List<MagicSpell> { new MagicSpell { Name = "Kamehameha", Damage = 200 } }
                });
                context.SaveChanges();
            }
            // Je suis certain d'avoir fermé la connextion

            using (var context = new RpgContext())
            {
                var spellCasters = context.SpellCasters;
                Console.WriteLine(string.Join(",", spellCasters));

                var powerfulSpells = context.MagicSpells.Where(ms => ms.Damage > 30);
                Console.WriteLine(string.Join(",", powerfulSpells));
            }
        }
    }
}
