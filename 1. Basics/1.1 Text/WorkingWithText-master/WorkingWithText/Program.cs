using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

namespace WorkingWithText
{
    public static class WorkingWithText
    {
        // 1- Write a method that accepts a few numbers separated by a hyphen. Check
        // to see if there are duplicates. If so, return bool True; otherwise, return bool False.
        public static bool AreThereDuplicates(string hyphenNum)
        {
            bool Duplicates = false;
<<<<<<< HEAD
            List<string> numbers = hyphenNum.Split("-").ToList();
            numbers.RemoveAll(str => string.IsNullOrEmpty(str));
            if (numbers.Distinct().Count() != numbers.Count())
=======
            string[] words = hyphenNum.Split("-");
            words = words.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            if (words.Count() != words.Distinct().Count())
>>>>>>> 1a84a03f938c250d19677b5008551e00f923df49
                Duplicates = true;

            return Duplicates;
        }
        
        // 2- Write a method that accepts a string of numbers separated by a hyphen. If the input 
        // is NOT in the correct format OR is NOT consecutive then return bool False. If the format 
        // is correct AND the numbers are consecutive, return bool True. For
        // example, if the input is "5-6-7-8-9" or "20-19-18-17-16", return bool True.
        // Do not use .Sort, it will cause the test to pass when it actually does not.
        public static bool IsConsecutive(string hyphenNum)
        {
            bool Consecutive = false;
            try
            {
                int[] ConsecutiveNumbers = Array.ConvertAll(hyphenNum.Split("-"), int.Parse);
                for (int i = 0; i < ConsecutiveNumbers.Length - 1; i++)
                {
                    if (ConsecutiveNumbers[i] == ConsecutiveNumbers[i + 1] - 1)
                    {
                        Consecutive = true;
                    }
                    else
                    {
                        Consecutive = false;
                        break;
                    }
                }
                if (!Consecutive)
                {
                    for (int i = 0; i < ConsecutiveNumbers.Length - 1; i++)
                    {
                        if (ConsecutiveNumbers[i] == ConsecutiveNumbers[i + 1] + 1)
                            Consecutive = true;
                        else
                        {
                            Consecutive = false;
                            break;
                        }
                    }
                }
            }
            catch
            {
                string ErrorMessage = "String Improperly formated";
            }

            return Consecutive;
        }

        // 3- Write a method that accepts a string of a time 24-hour time format
        // (e.g. "09:00"). A valid time should be between 00:00 and 23:59. If the time is valid,
        // return a bool True; otherwise, return a bool False. If the user doesn't provide any values,
        // consider it as False. Make sure that its returns false if any letters are passed.
        public static bool IsValidTime(string hyphenNum)
        {
            bool IsValidTime = false;
            try
            {
                DateTime.ParseExact(hyphenNum, "HH:mm", System.Globalization.CultureInfo.InvariantCulture);
                IsValidTime = true;
            }
            catch
            {
                string Invalid = "Invalid Time";
            }
 			return IsValidTime;
        }

        // 4- Write a method that accepts a string of a few words separated by a space. Use the
        // words to create a variable name with PascalCase. For example, if the user types: "number
        // of students", return "NumberOfStudents". Make sure that the program is not dependent on
        // the input. So, if the user types "NUMBER OF STUDENTS", the program should still return "NumberOfStudents".
        // Trim off unneeded spaces.
        public static string PascalConverter(string aFewWords)
        {
            string PascalWords = "";
            string WordHolder = "";

            if (!string.IsNullOrEmpty(aFewWords))
            {
                foreach (string word in aFewWords.Trim().Split(" "))
                {
                    WordHolder = word.Substring(0, 1).ToUpper() + word.Substring(1).ToLower();
                    PascalWords += WordHolder;
                }
            }

        	return PascalWords;
        }

        // 5- Write a method that accepts an English word. Count the number of vowels
        // (a, e, i, o, u) in the word. So, if the user enters "inadequate", the program should
        // return 6.
        public static int VowelCounter(string aWord)
        {
            int Vowels = 0;

            char[] chars = aWord.ToLower().ToCharArray();
            foreach (char v in chars)
            {
                if (v is 'a' or 'e' or 'i' or 'o' or 'u')
                    Vowels++;
            }

            return Vowels;
        }
    }


    internal static class Program
    {
        private static void Main()
        {

        }
    }
}
