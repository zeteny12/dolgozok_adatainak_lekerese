using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dolgozok_adatainak_lekerese
{
    internal class Program
    {
        static Adatbazis db = new Adatbazis();
        static List<Dolgozok> dolgozok;
        static void Main(string[] args)
        {
            dolgozok = db.getAllDolgozo();

            feladat01();
            feladat02();
            feladat03();
            feladat04();

            Console.WriteLine("\nProgram Vége...");
            Console.ReadKey();
        }

        private static void feladat04()
        {
            //Kilistázza az "asztalosműhely"-ben dolgozók nevét
            Console.WriteLine("\n3. Feladat:");
            Console.WriteLine("\tAsztalosműhelyben dolgozók nevei:");
            foreach (var item in dolgozok.FindAll(a => a.reszleg == "asztalosműhely"))
            {
                Console.WriteLine($"\t{item.nev}");
            }
        }

        private static void feladat03()
        {
            //Hányan dolgoznak az egyes részlegeken
            Console.WriteLine("\n3. Feladat:");
            foreach (var item in dolgozok.GroupBy(a => a.reszleg).Select(b => new {reszleg = b.Key,letszam=b.Count()}).OrderBy(c => c.reszleg))
            {
                Console.WriteLine($"\t{item.reszleg}: {item.letszam} fő");
            }
        }

        private static void feladat02()
        {
            //A legmagasabb keresetű dolgozó nevét
            int maxber = dolgozok.Max(a => a.ber);
            Dolgozok dolgozo = dolgozok.Find(a => a.ber == maxber);
            Console.WriteLine("\n2. Feladat:");
            Console.WriteLine($"\tA legjobban kereső dolgozó: {dolgozo.nev}");
        }

        private static void feladat01()
        {
            //Kiírja a dolgozók számát
            Console.WriteLine("1. Feladat:");
            Console.WriteLine($"\tA dolgozók száma: {dolgozok.Count}");
        }
    }
}
