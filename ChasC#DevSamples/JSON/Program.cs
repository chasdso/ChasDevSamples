using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Web;
using System.Diagnostics;

namespace JSON
{

    public class ChasJSON
    {
        public string Name { get; set; }
        public string Occupation { get; set; }
        public string DateofBirth { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //string curDir = Directory.GetCurrentDirectory();

            string JSONstring = File.ReadAllText("../../ChasJSONpractice.json");
            ChasJSON p1 = JsonConvert.DeserializeObject<ChasJSON>(JSONstring);

            Console.WriteLine("Name: " + p1.Name + ", " + "Occupation: " + p1.Occupation + ", " + "Date of Birth: " + p1.DateofBirth);
            //Console.WriteLine(curDir);
            Console.ReadKey();
        }
    }
}
;