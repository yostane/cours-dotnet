// import d'un namespace
using System;
using Csharp.Typing;
using Csharp;
using Csharp.Assignment;
using System.Threading.Tasks;

// définit le namespace de la classe
namespace consoleapp
{
    class Program
    {
        // Point d'entrée
        static public async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //Demo.showTypes();
            //DemoFunctions.Run();
            //DemoLambda.Run();
            //DemoLinq01.Run();
            //Assignment01.Run();
            //DemoControlFlow.Run();
            //DemoArray.Run();
            //DemoClass.Run();
            //BouzeSpeakerRecorder.Run();
            //Complex.Run();
            //PokemonGame.Run();
            //ThreadDemo.Run();
            //await AsyncDemo.Run();
            Console.WriteLine($"Length: {args.Length}. args: {String.Join("\n", args)}");
            //Assignment03.RunExo1();
            //await Assignment03.RunExo3(args);
            //Assignment03.RunExo4();
            Assignment03.RunExo5();
        }
    }
}
