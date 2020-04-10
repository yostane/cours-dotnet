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
            Console.WriteLine("Hello World!");
            Console.WriteLine("Appuyez sur une touche pour terminer.");
            Console.ReadKey();

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
}

