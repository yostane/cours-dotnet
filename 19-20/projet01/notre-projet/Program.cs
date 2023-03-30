using System;

//permet de classer les indetifiants dans espace de noms
namespace notre_projet
{
    class Program
    {
        /**
         point d'entrée:
            1- fonction statique qui s'appelle Main (principal en français)
            2- Le namespace de la fonction doit être renseigné dans le .csproj
        */
        static void Main(string[] args)
        {
            var x = 10;
            Console.WriteLine($"Hello World! {x}");
            Console.WriteLine("Appuyez sur une touche pour terminer.");
            Console.ReadKey();

            // les names spaces permettent de trier et d'organiser les classes fonctions et interfaces, etc.
            var p = new notre_projet.Program();
            var y = new yostane.Program();
        }
    }
}

namespace yostane
{
    class Program
    {

    }

    interface ITest
    {

    }

    class Toto
    {

    }

    struct Point
    {

    }

    enum Meteo
    {

    }
}

