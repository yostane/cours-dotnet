using System.Data;
using System;
namespace Csharp
{
    public class DemoFunctions
    {
        public static void SayPika()
        {
            Console.WriteLine("Pikaaaaa");
        }

        public static int AddExperience(int currentExperience, int acquiredExperience = 0)
        {
            return currentExperience + acquiredExperience;
        }

        // one-line function
        public static int UpgradeLevel(int currentLevel) => currentLevel + 1;

        public static void Run()
        {
            // Pas besoin de préfixer le nom de la classe dans la même classe
            Console.WriteLine(UpgradeLevel(7));
            Console.WriteLine(AddExperience(7, 5));
            DemoFunctions.SayPika();
        }
    }
}
