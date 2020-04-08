/**
Créer une classe abstraite Pokemon avec une fonction abstraite Crier(). 
Les pokemons ont aussi une proriété (get, set) "Speed" de type int.
Définir deux espèces de pokemons Salameche et Carapuce et définir la fonction Crier() de chacun.

Créer la classe “PokemonTrainer” qui a comme propriétés:
- Name
- Une liste de pokemons (utiliser la classe List)

Créer deux "PokemonTrainer" en leur attribuant un pokemon différent de l'espèce Salameche et un Capauce
*/
abstract class Pokemon
{
    // protected: comme un public dans les sous classes, comme du private en dehors
    public abstract void Crier(); // doit être implémentée par la sous-classe, donc elle ne peut être private
    public int Speed { get; set; }

    public override string ToString() => $"{GetType().Name}, speed: {Speed}";
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
Carapuce carapuce = new Carapuce();
carapuce.Speed = 10;
carapuce.Crier();
Salameche salameche = new Salameche() { Speed = 4 };
salameche.Crier();

class PokemonTrainer
{
    public PokemonTrainer(string name, List<Pokemon> pokemons)
    {
        this.Name = name;
        this.Pokemons = pokemons;
    }
    public string Name { get; set; }
    public List<Pokemon> Pokemons { get; set; }
}

// tableau dont on peut ajouter ou supprimer des éléments
var pokemons = new List<Pokemon> { carapuce };
pokemons.Add(salameche);
PokemonTrainer sacha = new PokemonTrainer("Sacha", pokemons);
var pokemons2 = new List<Pokemon> { new Carapuce() { Speed = 5 }, new Salameche() { Speed = 6 } };
PokemonTrainer ondine = new PokemonTrainer("Ondine", pokemons2);

/**
Créer les interfaces suivantes:
    - IWalker avec la fonction Walk
    - IFlyer avec la fonction Fly
    - ISwimmer ave la fonction Swim

Implémenter les interfaces Walker et Swimmer pour Carapuce
Implémenter les interfaces Walker et Flyer pour Salameche

Créer un fonction qui prend un liste de pokemons en paramètre et retourne les pokemons 
qui peuvent nager.
*/
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

List<Pokemon> GetSwimmers(List<Pokemon> pokemons)
{
    var swimmers = new List<Pokemon>();
    foreach (var pokemon in pokemons)
    {
        if (pokemon is ISwimmer)
        {
            swimmers.Add(pokemon);
        }
    }
    return swimmers;
}

var swimmers = GetSwimmers(sacha.Pokemons);
Console.WriteLine(String.Join(", ", swimmers));

/**
Créer une classe “GameEngine” qui définit une fonction statique “PredictTurns”.

Cette classe prend deux pokemons en paramètres et un entier 'turns' et fournit en résultat un tableau de pokemons.

Cette fonction retourne une List de taille 'turns'.
Chaque élément de la liste contient le pokemon qui va agir dans le prochaine tour i

Par exemple: PredictTurns(Pokemon1, Pokemon2, 4) peut retourner {Pokemon1, Pokemon2, Pokemon1, Pokemon1} 
-> Cela singifie que dans le tour suivant, Pokemon1 va agir, ensuite Pokemon2, ensuite Pokemon1 et efin Pokemon1.

Le tableau des prochains tours est déduit de la façon suivante:
1- Au début, on associe à chaque pokemon une variable action qui vaut 0.
2- Incrémenter l'action de chaque pokemon et répéter cela jusqu'à atteindre le "speed" d'un des deux Pokemon. 
3- Celui dont l'action atteint le "speed" en premier agit (prend le tour) et remet sa variable action à 0.
4- Si l'action est atteinte pour les deux pokemons à la fois, choisir un des deux au hasard.
5- Pour le tour suivant, reprendre à l'étape 2.

par exemple:
Pokemon A -> vitesse 10, Pokemon B -> vitesse 4
Déroulement des tours: B, B, A, B, 

Pokemon A -> vitesse 4, Pokemon B -> vitesse 4
Déroulement possible des tours: A, B, A, B, 

Pokemon A -> vitesse 2, Pokemon B -> vitesse 3
Déroulement (possible) des tours: A, B, A, A, B, A,... ou A, B, A, B, A,
*/

/**
Ajouter les propriétés Attack, Defense et HP (points de vie) aux pokemons.
 Créer dans GameEngine, une fonction statique "SimulateCombat" qui prend deux pokemons en paramètres
et retoune le pokemon qui aura gagné le simulation.

La simulation se déroule de cette façon
- Le tour de chaque chaque pokemon attaque dans l’ordre défini dans la partie 2.
Le pokemon subit l’attaque voit ses pv réduire avec cette formule: 
pv_attaqué = pv_attaqué - ( attaque_de_l’attaquant * -  défense_attaqué)
Le combat s’arrête dès qu’un pokemon a son pv <= 0.

Exemple:
Pokemon A -> vitesse 10, attaque 5, défense 2, hp 30
 Pokemon B -> vitesse 4, attaque 4, défense 3, hp 40
 Déroulement:
Pokemon A attaque, pokemon B subit 2 dégats. Pokemon B a 38 hp

*/
