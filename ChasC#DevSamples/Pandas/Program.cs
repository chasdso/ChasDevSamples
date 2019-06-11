using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;


namespace Pandas

{
    class Program
    {
        static void Main(string[] args)
        {
            AddPandas p1 = new AddPandas(" Pan Dee");
            AddPandas p2 = new AddPandas(" Pan Dah");
            Console.WriteLine(p1.Name); // Pan Dee 
            Console.WriteLine (p2. Name); // Pan Dah 
            Console.WriteLine (AddPandas.Population); //2
            Console.ReadKey();
            
        }
    }
}
