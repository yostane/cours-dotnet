using System;
namespace Csharp
{
    // convention: les interfaces commentces par I
    interface ISpeaker
    {
        void Speak();
        int Volume { get; set; }
    }

    interface IRecorder
    {
        void Record();
    }

    class BouzeSpeakerRecorder : ISpeaker, IRecorder
    {
        public int Volume { get; set; }

        public void Record()
        {
            Console.WriteLine("recording");
        }

        public void Speak()
        {
            Console.WriteLine("Speaking");
        }

        public static void Run()
        {
            BouzeSpeakerRecorder bsr = new BouzeSpeakerRecorder();
            ISpeaker i = bsr;
            IRecorder r = bsr;
            i.Speak();
            r.Record();
            Console.WriteLine(bsr is BouzeSpeakerRecorder);
            Console.WriteLine(bsr is ISpeaker);
            Console.WriteLine(bsr is string);
        }
    }
}