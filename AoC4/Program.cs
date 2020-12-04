using System;
using System.Net;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC4
{
    class Program
    {
        static void Main()
        {
            //Grab the input and create a list of passportdata
            string[] splitter = new string[] { "\r\n\r\n" };
            List<string> input = File.ReadAllText("C:\\Users\\willh\\AoC2020Input\\4.txt").Split(splitter, StringSplitOptions.RemoveEmptyEntries).ToList();

            //A valid passport must contain certain fields and these are it
            string[] fields = new string[] { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid"};          

            //Check how many are valid, as in contains the fields above
            int solutionOne = CountValid(input, fields);

            Console.WriteLine("Solution 1 = {0}", solutionOne);

            //Part two requires being able to lockup data based on KeyValue pairs so we build a dictionary of each passport
            var passports = BuildPassportData(input);

            int solutionTwo = CountValidPassports(passports, fields);

            Console.WriteLine("Solution 2 = {0}", solutionTwo);

            Console.ReadKey();
        }

        static Dictionary<string, string>[] BuildPassportData(List<string> input)
        {
            //Create an array of dictionaries
            Dictionary<string, string>[] passports = new Dictionary<string, string>[input.Count];         

            //Walk through the List used for part one and act on each passport
            for (int i = 0; i < input.Count; i++)
            {
                //Create an array of lines representing the individual passport
                string[] lines = input[i].Replace(' ', '\n').Split('\n').ToArray();

                //Create a dictionary to store the data in
                var passportData = new Dictionary<string, string>();

                //Write the data to each key value pair in the passport
                foreach (var line in lines)
                {
                    string key = line.Split(':')[0];
                    string value = line.Split(':')[1];

                    passportData.Add(key, value);
                }
                
                //Input the passport in the passports array
                passports[i] = passportData;
            }

            return passports;
        }

        static int CountValidPassports(Dictionary<string, string>[] passports, string[] fields)
        {
            int count = 0;

            foreach (var passport in passports)
            {
                bool valid = false;

                if (!CheckValid(fields,passport))
                {
                    continue;
                }

                if (CheckByr(passport["byr"]) && CheckIyr(passport["iyr"]) && CheckEyr(passport["eyr"]) && CheckHgt(passport["hgt"]) && CheckHcl(passport["hcl"]) && CheckEcl(passport["ecl"]) && CheckPid(passport["pid"]))
                {
                    valid = true;
                }

                if (valid)
                {
                    count++;
                }
            }

            return count;
        }

        static bool CheckByr(string input)
        {
            bool valid = false;
            
            int num = Int32.Parse(input);

            if ((num >= 1920) && (num <= 2002))
            {
                valid = true;
            }

            return valid;
        }

        static bool CheckIyr(string input)
        {
            bool valid = false;

            int num = Int32.Parse(input);

            if ((num >= 2010) && (num <= 2020))
            {
                valid = true;
            }

            return valid;
        }

        static bool CheckEyr(string input)
        {
            bool valid = false;

            int num = Int32.Parse(input);

            if ((num >= 2020) && (num <= 2030))
            {
                valid = true;
            }

            return valid;
        }

        static bool CheckHgt(string input)
        {
            bool valid = false;

            if (input.Contains("cm"))
            {
                int num = Int32.Parse(input.Split(new string[] { "cm" },StringSplitOptions.None)[0]);

                if (num >= 150 && num <= 193)
                {
                    valid = true;
                }
                
                return valid;

            }
            else if (input.Contains("in"))
            {
                int num = Int32.Parse(input.Split(new string[] { "in" }, StringSplitOptions.None)[0]);

                if (num >= 59 && num <= 76)
                {
                    valid = true;
                }

                return valid;
            }
            else
            {
                return valid;
            }
        }

        static bool CheckHcl(string input)
        {
            string candidate = input.Split(new string[] { "\r" }, StringSplitOptions.None)[0];
            bool valid = System.Text.RegularExpressions.Regex.IsMatch(candidate, "^#[0-9a-f]{6}$");

            return valid;
        }

        static bool CheckEcl(string input)
        {

            string candidate = input.Split(new string[] { "\r" }, StringSplitOptions.None)[0];
            bool valid = System.Text.RegularExpressions.Regex.IsMatch(candidate, "^(amb|blu|brn|gry|grn|hzl|oth)$");

            return valid;
        }

        static bool CheckPid(string input)
        {
            string candidate = input.Split(new string[] { "\r" }, StringSplitOptions.None)[0];
            bool valid = System.Text.RegularExpressions.Regex.IsMatch(candidate, "^[0-9]{9}$");

            return valid;
        }

        #region Solution One
        static bool CheckValid(string[] fields, string candidate)
        {
            bool valid = true;

            foreach (string field in fields)
            {
                if (!candidate.Contains(field))
                {
                    valid = false;
                }
            }

            return valid;
        }

        static bool CheckValid(string[] fields, Dictionary<string,string> candidate)
        {
            bool valid = true;

            foreach (var field in fields)
            {
                if (!candidate.Keys.Contains(field))
                {
                    valid = false;
                }
            }

            return valid;
        }

        static int CountValid(List<string> input, string[] fields)
        {
            int count = 0;
            foreach (string candidate in input)
            {
                if (CheckValid(fields,candidate))
                {
                    count++;
                }
            }

            return count;
        }
        #endregion
    }
}