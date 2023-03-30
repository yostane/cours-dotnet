using System;
namespace Csharp
{
    abstract class BaseDemoClass
    {
        public void Talk()
        {
            Console.WriteLine("It's aliiiiiive");
        }

        public abstract void Listen();
    }

    // Héritage simple
    class YuGiOhCard : BaseDemoClass
    {
        private string _Name;
        // pouvoir avoir la main sur les accesseurs (lecture, écriture)
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public int Attack { get; set; }

        public YuGiOhCard(string name, int attack) : base()
        {
            this.Name = name;
            this.Attack = attack;
        }

        override public string ToString() => $"{Name} - Att: {Attack}" + base.ToString();

        public override void Listen()
        {
            Console.WriteLine("I listen");
        }
    }

    static class DemoClass
    {
        public static void Run()
        {
            var c = new YuGiOhCard("Dragon millénaire", 2000);
            c.Attack = 100;
            Console.WriteLine(c);
        }
    }
}