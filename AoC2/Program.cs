using System;
using System.IO;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2
{
    class Program
    {
        static void Main()
        {
            StreamReader reader = new StreamReader("C:\\Users\\willh\\AoC2020Input\\2.txt");

            List<string> input = new List<string>();

            string line;
            while ((line = reader.ReadLine()) != null)
            {
                input.Add(line);
            }

            Console.WriteLine("First solution");
            SolutionOne(input);
            Console.WriteLine("Second solution");
            SolutionTwo(input);

            Console.ReadKey();
        }
        static void SolutionOne(List<string> input)
        {
            int count = 0;

            foreach (string item in input)
            {
                string[] candidate = item.Split(' ');

                int min = Int32.Parse(candidate[0].Split('-')[0]);
                int max = Int32.Parse(candidate[0].Split('-')[1]);
                char letter = char.Parse(candidate[1].Substring(0, 1));
                int amount = candidate[2].Split(letter).Length - 1;

                if (amount >= min && amount <= max)
                {
                    count += 1;
                }
            }

            Console.WriteLine(count);
        }

        static void SolutionTwo(List<string> input)
        {
            int count = 0;

            foreach (string item in input)
            {
                string[] candidate = item.Split(' ');

                int first = Int32.Parse(candidate[0].Split('-')[0]) - 1;
                int second = Int32.Parse(candidate[0].Split('-')[1]) - 1;
                char letter = char.Parse(candidate[1].Substring(0, 1));
                char letterInPosOne;
                char letterInPosTwo;

                try
                {
                    letterInPosOne = char.Parse(candidate[2].Substring(first, 1));
                }
                catch (Exception)
                {

                    letterInPosOne = '-';
                }

                try
                {
                    letterInPosTwo = char.Parse(candidate[2].Substring(second, 1));
                }
                catch (Exception)
                {

                    letterInPosTwo = '-';
                }


                if (letterInPosOne == letter ^ letterInPosTwo == letter)
                {
                    count += 1;
                }
            }

            Console.WriteLine(count);
        }
    }
}
