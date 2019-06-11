//From https://docs.microsoft.com/en-us/dotnet/csharp/tutorials/inheritance
using System;

namespace Inheritance
{
    public class Example
    {
        public static void Main(string[] args)
        {
            var b = new A.B();
            Console.WriteLine(b.GetValue());
            Console.ReadLine();
        }
    }
    // The example displays the following output:
    //       10

    public class A
    {
        private int value = 10;

        public class B : A
        {
            public int GetValue()
            {
                return this.value;
            }
        }
    }

    public class C : A
    {

        //public int GetValue()
        //{
        //This return fails, private property 'value' is not visible in directly derived classes
        //    return this.value;
        //}
    }





}
