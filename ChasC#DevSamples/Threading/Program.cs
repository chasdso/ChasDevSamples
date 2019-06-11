using System;
using System.Threading;


//good training for C# threading (and others) here: https://www.youtube.com/watch?v=hOVSKuFTUiI
//full c# training (excellent) here: https://www.youtube.com/playlist?list=PLGLfVvz_LVvRX6xK1oi0reKci6ignjdSa
namespace Threading
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread t = new Thread(Print1);
            t.Start();
            for (int i = 0; i < 1000; i++)
            {
                Console.Write(0);
                //remove sleep and you'll get even threading, note after first 0 all 1s until sleep is done
                Thread.Sleep(1000);

            }
            Console.ReadLine();

        }

        static void Print1()
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.Write(1);
            }
        }

    }
}
