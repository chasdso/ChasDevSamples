using GenericNamespace;
using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Program myUT = new Program();
            int resultx = Test1();
            Console.WriteLine(resultx);
            Console.ReadLine();
        }
        //[Fact]
        public static int Test1()
        {
            GenericSample myTestClass = new GenericSample();
            int testInt = myTestClass.Add(4, 5);
            return testInt;

        }
    }
}
