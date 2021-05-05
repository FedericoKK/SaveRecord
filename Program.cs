using System;
using Santi.Federico._4H.SaveRecords.Models;
namespace Santi.Federico._4H.SaveRecords
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("SaveRecord - 2021 - santi.federico@studenti.ittsrimini.edu.it");
            // leggere un file csv con i comuni e trasformarlo in una list<comune>
            //Scrivere la list<comune> in un file binaroo
            //Rileggere il file binario in una list<comune>
            Comuni c = new Comuni("Comuni.csv");
           Console.WriteLine($"Ho letto {c.Count} righe");
           c.save();
    }
}
