using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Najemnicy n = new Najemnicy();
           // n.WriteData();
            Console.WriteLine($"Siła rażenia armi rzymianina: {n.Najlepszy_wybor()}");
            n.Pisz_indeksy();
            Console.WriteLine($"\nIlosc operacji: {n.getCounter()}");
            Console.ReadKey();
            
        }
    }
}
