using System;
using System.Collections.Generic;
using System.Threading;

namespace LinqBasics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> countries = new List<string>();

            countries.Add("USA");
            countries.Add("INDIA");
            countries.Add("UK");

            foreach (string country in countries)
            {
                Console.WriteLine(country);
            }

            Console.ReadLine();


        }
    }
}
