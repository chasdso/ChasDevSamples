
// C# Program to illustrate calling 
// a Copy constructor 
using System;
namespace copyConstructorExample
{

    class Geeks
    {

        private string month;
        private int year;

        // declaring Copy constructor 
        public Geeks(Geeks s)
        {
            month = s.month;
            year = s.year;
        }

        // Instance constructor 
        public Geeks(string month, int year)
        {
            this.month = month;
            this.year = year;
        }

        // Get deatils of Geeks 
        public string Details
        {
            get
            {
                return "Month: " + month.ToString() +
                         "\nYear: " + year.ToString();
            }
        }

        // Main Method 
        public static void Main()
        {

            // Create a new Geeks object. 
            Geeks g1 = new Geeks("June", 2018);

            // here is g1 details is copied to g2. 
            Geeks g2 = new Geeks(g1);

            Console.WriteLine(g2.Details);
            Console.ReadLine();
        }
    }
}













//// C# Program to illustrate calling 
//// a Default constructor 
//using System;
//namespace DefaultConstructorExample
//{

//    class Geek
//    {

//        int num;
//        string name;

//        // this would be invoked while the 
//        // object of that class created. 
//        Geek()
//        {
//            Console.WriteLine("Constructor Called");
//        }

//        // Main Method 
//        public static void Main()
//        {

//            // this would invoke default 
//            // constructor. 
//            Geek geek1 = new Geek();

//            // Default constructor provides 
//            // the default values to the 
//            // int and object as 0, null 
//            // Note: 
//            // It Give Warning because 
//            // Fields are not assign 
//            Console.WriteLine(geek1.name);
//            Console.WriteLine(geek1.num);
//            Console.ReadLine();
//        }
//    }
//}
