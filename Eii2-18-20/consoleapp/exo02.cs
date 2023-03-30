using System.Reflection.Metadata.Ecma335;
using System.Linq;
using System;
using System.Collections.Generic;

namespace Csharp.Assignment
{
    /** 1
Créer une classe abstraite Pokemon avec une fonction abstraite Crier().
Les pokemons ont aussi une proriété (get, set) "Speed" de type int.
Définir deux espèces de pokemons Salameche et Carapuce et définir la fonction Crier() de chacun.

Créer la classe “PokemonTrainer” qui a comme propriétés:
- Name
- Une liste de pokemons (utiliser la classe List)

*/

    /** 2
Créer les interfaces suivantes:
            - IWalker avec la fonction Walk
            - IFlyer avec la fonction Fly
            - ISwimmer ave la fonction Swim

Implémenter les interfaces Walker et Swimmer pour Carapuce
Implémenter les interfaces Walker et Flyer pour Salameche
*/

    abstract class Pokemon
    {
        // protected: comme un public dans les sous classes, comme du private en dehors
        public abstract void Crier(); // doit être implémentée par la sous-classe, donc elle ne peut être private
        public int Speed { get; set; }
        public int HealthPoints { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }

        public override string ToString() => $"{GetType().Name}, speed: {Speed} ...";
    }

    interface IWalker
    {
        void Walk();
    }
    interface IFlyer
    {
        void Fly();
    }
    interface ISwimmer
    {
        void Swim();
    }

    class Carapuce : Pokemon, IWalker, ISwimmer
    {
        // Je mets override pour signifier que j'implémente la méthode virtuelle
        public override void Crier()
        {
            Console.WriteLine("Carapuuuuuuuuuce");
        }

        public void Walk()
        {
            Console.WriteLine("tok tok");
        }

        public void Swim()
        {
            Console.WriteLine("flou flou");
        }
    }

    class Salameche : Pokemon, IFlyer, IWalker
    {
        public override void Crier()
        {
            Console.WriteLine("Sale la mèche, lave toi les cheveux");
        }

        public void Walk()
        {
            Console.WriteLine("tic toc");
        }

        public void Fly()
        {
            Console.WriteLine("vou vou zella");
        }
    }

    class PokemonTrainer
    {
        public PokemonTrainer(string name, List<Pokemon> pokemons)
        {
            this.Name = name;
            this.Pokemons = pokemons;
        }
        public string Name { get; set; }
        public List<Pokemon> Pokemons { get; set; }

        public override string ToString() => $"Trainer: {Name}";
    }

    /** 3

    Créer une classe "PokemonGame" qui expose proproété "Trainers" de type List<PokemonTrainer>
    
    Mettre dans "Trainers" deux "PokemonTrainer" en leur attribuant un ou deux pokemons 
    différents de l'espèce Salameche et un Capauce

    Créer une méthode d'extension de "PokemonGame" qui retourne la liste de tous les pokmoens contenus dans 
        les "Trainers"

    Créer dans PokemonGame une fonction statique qui prend une liste de pokemons en paramètre et retourne les pokemons
    qui peuvent nager.
    */

    class PokemonGame
    {
        public List<PokemonTrainer> Trainers { get; set; } = new List<PokemonTrainer>();
        public PokemonGame()
        {
            Carapuce carapuce = new Carapuce();
            carapuce.Speed = 10;
            carapuce.Attack = 5;
            carapuce.Defense = 2;
            carapuce.HealthPoints = 30;
            // Sucre syntaxique du code plus haut. Attention: Ce n'est pas un constructeur
            Salameche salameche = new Salameche { Speed = 4, Attack = 4, Defense = 4, HealthPoints = 40 };
            var pokemons = new List<Pokemon> { carapuce };
            pokemons.Add(salameche);
            pokemons.Add(new Carapuce() { Speed = 20 });
            PokemonTrainer sacha = new PokemonTrainer("Sacha", pokemons);
            Console.WriteLine(String.Join(" - ", sacha.Pokemons));
            var pokemons2 = new List<Pokemon> { new Carapuce() { Speed = 5 }, new Salameche() { Speed = 6 } };
            PokemonTrainer ondine = new PokemonTrainer("Ondine", pokemons2);
            Trainers.Add(sacha);
            Trainers.Add(ondine);
        }

        public static List<Pokemon> GetSwimmers(List<Pokemon> pokemons) => pokemons.Where(p => p is ISwimmer).ToList();

        public override string ToString() => $"Game with trainers: {String.Join(", ", Trainers)}";

        public static void Run()
        {
            var game = new PokemonGame();
            Console.WriteLine(game);
            var allPokemons = game.GetThemAll();
            Console.WriteLine($"All pokemons: {String.Join("\n", allPokemons)}");
            Console.WriteLine($"All swimmers: {String.Join("\n", PokemonGame.GetSwimmers(allPokemons))}");
            var predictions = PredictTurns(new Carapuce { Speed = 2 }, new Salameche { Speed = 3 }, 10);
            Console.WriteLine($"Future turns: {String.Join("\n", predictions)}");
            SimulateCombat(new Carapuce { Speed = 2, Attack = 10, Defense = 5, HealthPoints = 40 }
                            , new Salameche { Speed = 3, Attack = 12, Defense = 9, HealthPoints = 20 });
        }

        /** 4
Dans "PokemonGame", définir une fonction statique "PredictTurns".

Cette fonction prend deux pokemons en paramètres et un entier 'turns'. Elle retourne en résultat une liste de pokemons.
La liste est de taille 'turns'.

Chaque élément de la liste contient le pokemon qui va agir dans le prochaine tour i

Par exemple: PredictTurns(pokemon1, pokemon2, 4) peut retourner {pokemon1, pokemon2, pokemon1, pokemon1} 
-> Cela singifie que dans le tour suivant, Pokemon1 va agir, ensuite Pokemon2, ensuite Pokemon1 et efin Pokemon1.

Le tableau des prochains tours est construit de la façon suivante:
1- Au début, on associe à chaque pokemon une variable 'action' qui vaut 0.
2- Incrémenter (+1) l'action de chaque pokemon et répéter cela jusqu'à atteindre le "Speed" d'un des deux Pokemon. 
3- Celui dont l'action atteint le "Speed" en premier agit (prend le tour) et remet sa variable action à 0. 
                L'autre pokemon garde son action intacte
4- Si l'action atteint le "speed" pour les deux pokemons à la fois, choisir un des deux au hasard et on remet l'action du pokemon choisi à 0. 
                L'action de l'autre pokemon reste intacte.
5- Pour le tour suivant, reprendre à l'étape 2.

par exemple:
Pokemon A -> vitesse 10, Pokemon B -> vitesse 4
Déroulement des tours: B, B, A, B,

actionA => 4, ActionB => 4 -> B (actionB => 0)
ActionA => 8, ActionB => 4 -> B (actionB => 0)
ActionA => 10, ActionB => 2 -> A (actionA => 0)

Pokemon A -> vitesse 4, Pokemon B -> vitesse 4
Déroulement possible des tours: A, B, A, B, 

Pokemon A -> vitesse 2, Pokemon B -> vitesse 3
Déroulement (possible) des tours: A, B, A, A, B, A,... ou A, B, A, B, A,
*/

        private static void AddPokemonToPredictions(List<Pokemon> predictions, Pokemon p, out int action)
        {
            predictions.Add(p);
            action = 0;
            Console.WriteLine($"{p} turn");
        }

        public static List<Pokemon> PredictTurns(Pokemon p1, Pokemon p2, int turns)
        {
            Console.WriteLine($"Start predict turns {p1} vs {p2}. Fighto !!!!!");
            var predictions = new List<Pokemon>();
            int action1 = 0;
            int action2 = 0;
            var r = new Random();
            while (predictions.Count < turns)
            {
                action1 += 1;
                action2 += 1;
                Console.WriteLine($"Action1: {action1}. Action2: {action2}");
                if (action1 >= p1.Speed && action2 >= p2.Speed)
                {
                    if (r.Next(1) == 0)
                    {
                        AddPokemonToPredictions(predictions, p1, out action1);
                    }
                    else
                    {
                        AddPokemonToPredictions(predictions, p2, out action2);
                    }
                }
                else if (action1 >= p1.Speed)
                {
                    AddPokemonToPredictions(predictions, p1, out action1);
                }
                else if (action2 >= p2.Speed)
                {
                    AddPokemonToPredictions(predictions, p2, out action2);
                }
            }
            return predictions;
        }

        /** 5
        Ajouter les propriétés Attack, Defense et HealthPoints (points de vie) aux pokemons.
        Ces valeurs sont initialisées par défaut de cette facon:
        - attack: valeur aléatoire entre 5 et 10
        - défense: valeur aléatoire entre 5 et 10
        - contrainte: attack + défense <= 15
        - HealthPoints: valeut aléatoire entre 30 et 40

        Créer dans GameEngine, une fonction statique "SimulateCombat" qui prend deux pokemons en paramètres
        et retoune le pokemon qui aura gagné le simulation de combat après 20 tours.

        La fonction affiche dans la console le déroulement de la "simulation" de combat.

        La simulation se déroule de cette façon:
        - Le tour de chaque pokemon est dans l’ordre défini dans la partie précédente.
        - Le pokemon qui le moins de pv a perdu
        - Dès qu'un pokemon est ko, la simulation s'arrête et ce dernier a perdu

        Le pokemon qui subit l’attaque voit ses pv réduire avec cette formule: 
        pv_attaqué = pv_attaqué - ( attaque_de_l’attaquant * (multiplicateur alétoire en 0.5 et 1.5) -  défense_attaqué)

        Exemple:
        Pokemon A -> vitesse 10, attaque 5, défense 2, hp 30
        Pokemon B -> vitesse 4, attaque 4, défense 3, hp 40
        Déroulement: Pokemon A attaque, pokemon B subit 2 dégats. Pokemon B a 38 hp
        */
        public static Pokemon SimulateCombat(Pokemon pokemon1, Pokemon pokemon2)
        {
            var predictions = PredictTurns(pokemon1, pokemon2, 20);
            var random = new Random();
            int currentTurn = 0;
            while (currentTurn < predictions.Count && pokemon1.HealthPoints > 0 && pokemon2.HealthPoints > 0)
            {
                Pokemon attackPokemon = predictions[currentTurn];
                Pokemon defensePokemon = attackPokemon == pokemon1 ? pokemon2 : pokemon1;
                double randomMultiplicator = random.NextDouble() + 0.5;
                int damage = (int)(attackPokemon.Attack * randomMultiplicator) - defensePokemon.Defense;
                if (damage <= 0)
                {
                    Console.WriteLine($"{attackPokemon.GetType().Name} n'a pas fait de dégats");
                }
                else
                {
                    defensePokemon.HealthPoints -= damage;
                    Console.WriteLine($"{attackPokemon.GetType().Name} attaque");
                    Console.WriteLine($"{defensePokemon.GetType().Name} subit {damage} degats");
                    Console.WriteLine($"{defensePokemon.GetType().Name} a {defensePokemon.HealthPoints} HP");
                }
                currentTurn += 1;
            }
            var winner = pokemon1.HealthPoints > pokemon2.HealthPoints ? pokemon1 : pokemon2;
            Console.WriteLine($"And the winner is {winner.GetType().Name}. Shah pour le perdant !");
            return winner;
        }
    }

    static class Extentions
    {
        public static List<Pokemon> GetThemAll(this PokemonGame game)
        {
            var pokemons = game.Trainers.SelectMany(trainer => trainer.Pokemons).ToList();
            /*var pokemons = game.Trainers.Aggregate(new List<Pokemon>(), (acc, trainer) =>
            {
                acc.AddRange(trainer.Pokemons);
                return acc;
            }).ToList();*/
            return pokemons;


            //select: [[p1, p2], [p3, p4]]
            // selectMany: [p1, p2, p3, p4]
        }
    }
}