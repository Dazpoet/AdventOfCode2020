using System;
using System.IO;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC3
{
    class Program
    {
        static void Main()
        { 
            List<string> lines = File.ReadAllLines("C:\\Users\\willh\\AoC2020Input\\3.txt").ToList();

            char[,] input = new char[lines.Count, lines[0].Length];

            for (int i = 0; i < lines.Count; i++)
            {
                string temp = lines[i];
                for (int j = 0; j < lines[0].Length; j++)
                {
                    input[i, j] = temp[j];
                }
            }

            double answer = CountTrees(input, 3, 1);

            double answer2 = answer * CountTrees(input, 1, 1) * CountTrees(input, 5, 1) * CountTrees(input, 7, 1) * CountTrees(input, 1, 2);

            Console.WriteLine("Answer 1 = {0}", answer);

            Console.WriteLine("Answer 2 = {0}", answer2);

            Console.ReadKey();
        }

        static double CountTrees(char[,] input, int right, int down)
        {
            int row = 0;
            int col = 0;
            double count = 0;

            for (int i = 0; i < input.GetLength(0); i++)
            {
                row += down;
                col += right;

                if (row >= input.GetLength(0))
                {
                    break;
                }
                if (col >= input.GetLength(1))
                {
                    col -= input.GetLength(1);
                }
                if (input[row,col] == '#')
                {
                    count++;
                }
            }

            return count;
        }
    }
}
