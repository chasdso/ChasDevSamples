using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePractice
{
   class Program
    {
        static void Main(string[] args)
        {
   
            
            
            //BaseDudeInherits obj = new BaseDudeInherits();
            //obj.DudeWorkin();
            //obj.DudeInheritsWorkin();
            //Console.WriteLine("Writing from within Main");
            //Console.ReadKey();


            //IChasInterface obj = new IChasWorkinit();
            //obj.Workinit();
            //Console.WriteLine("Writing from within Main");
            //Console.ReadKey();

            //StructvClass doit = new StructvClass();
            //doit.Compare();
        }
    }
    public class BaseDude
    {
        public virtual void DudeWorkin()
        {
            Console.WriteLine("Writing from within DudeWorkin method in BaseDude");
        }
    }
    public class BaseDudeInherits:BaseDude
    {
        public void DudeInheritsWorkin()
        {
            Console.WriteLine("Writing from within DudeInheritsWorkin method in BaseDudeInherits");
        }
        public override void DudeWorkin()
        {
            Console.WriteLine("Writing from override DudeWorkin method in BaseDudeInherits");
        }
    }
    interface IChasInterface
    {
        void Workinit();
   
    }

    public class IChasWorkinit : IChasInterface
    {
        void IChasInterface.Workinit()
        {
            Console.WriteLine("Writing from within Workinit method in IChasInterface");
        }
    }

    public class StructvClass
    {
        public void Compare()
        {
            StructPoint chasStructIntTest = new StructPoint();
            chasStructIntTest.x = 5;

            ClassPoint chasClassIntTest = new ClassPoint();
            chasClassIntTest.x = 5;

            ScopeInt chasScopeInt = new ScopeInt();
            Console.WriteLine("Struct before test = " + chasStructIntTest.x);
            chasScopeInt.StructIntBaby(chasStructIntTest);
            Console.WriteLine("Struct after test = " + chasStructIntTest.x);

            Console.WriteLine();

            ScopeInt chasScopeInt2 = new ScopeInt();
            Console.WriteLine("Class before test = " + chasClassIntTest.x);
            chasScopeInt2.ClassIntBaby(chasClassIntTest);
            Console.WriteLine("Class after test = " + chasClassIntTest.x);

            Console.ReadKey();

            //StructPoint sPoint1 = new StructPoint();
            //ClassPoint cPoint1 = new ClassPoint();
            //sPoint1.x = 8;
            //StructPoint sPoint2 = sPoint1;

            //Console.WriteLine("sPoint1.x = " + sPoint1.x);
            //Console.WriteLine("sPoint2.x = " + sPoint2.x);
            //sPoint1.x = sPoint1.x + 2;
            //Console.WriteLine("sPoint1.x +2 = " + sPoint1.x);
            //Console.WriteLine("sPoint2.x = " + sPoint2.x);

            //Console.WriteLine("But...");
            //cPoint1.x = 8;
            //ClassPoint cPoint2 = cPoint1;

            //Console.WriteLine("cPoint1.x = " + cPoint1.x);
            //Console.WriteLine("cPoint2.x = " + cPoint2.x);
            //cPoint1.x = cPoint1.x + 2;
            //Console.WriteLine("cPoint1.x +2 = " + cPoint1.x);
            //Console.WriteLine("cPoint2.x = " + cPoint2.x);


        }
    }
    public struct StructPoint { public int x; }
    public class ClassPoint { public int x; }
    public class ScopeInt
    {
        public void StructIntBaby(StructPoint chasStructInt )
        {

            //IntTest chasIntTest2 = new IntTest();
            //Console.WriteLine(chasIntTest2.int1);
            //ClassPoint cPoint2 = new ClassPoint();
            //Console.WriteLine("cPoint2 =" + cPoint2.x);
            chasStructInt.x++;
            Console.WriteLine("Struct +1 during test =" + chasStructInt.x);
        }
        public void ClassIntBaby(ClassPoint chasClassInt)
        {

            //IntTest chasIntTest2 = new IntTest();
            //Console.WriteLine(chasIntTest2.int1);
            //ClassPoint cPoint2 = new ClassPoint();
            //Console.WriteLine("cPoint2 =" + cPoint2.x);
            chasClassInt.x++;
            Console.WriteLine("Class +1 during test =" + chasClassInt.x);
        }
    }   
    //public class IntTest
    //{
    //    public int int1 = 0;
    //    public int int2 = 0;
    //}

}
