using System;

namespace NameOf
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(nameof(C)); // -> "Method1"
            Console.WriteLine(nameof(C.Method2)); // -> "Method2"
        }
    }
    class C
    {
        static int myMethod1(string x, int y)
        {
            return y;
        }
        static int myMethod2(string x, int y)
        {
            return y;
        }

    }
}

