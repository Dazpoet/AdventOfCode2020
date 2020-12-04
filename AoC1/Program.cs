using System;
using System.IO;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC1
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("C:\\Users\\willh\\AoC2020Input\\1.txt");

            List<int> input = new List<int>();

            string line;
            while ((line = reader.ReadLine()) != null)
            {
                input.Add(int.Parse(line));
            }

            foreach (int candidate in input)
            {
                foreach (int factor in input)
                {
                    foreach (int factor2 in input)
                    {
                        if (candidate + factor + factor2 == 2020)
                        {
                            Console.WriteLine(candidate * factor * factor2);
                        }
                    }
                }
            }

            Console.ReadKey();
        }
    }
}
