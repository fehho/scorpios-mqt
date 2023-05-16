using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Xml.Linq;
using System.Net.Http.Headers;
using System.Globalization;

namespace ArraysAndLists
{
    public static class ArraysAndLists
    {
        // 1- When you post a message on Facebook, depending on the number of people who like your
        // post, Facebook returns different information.

        // Write a method that accepts any number of names.
        // Return a string based on the below pattern.
        // If no one likes your post, it returns an empty string.
        // If only one person likes your post, it returns: "[Friend's Name] liked your post."
        // If two people like your post, it returns: "[Friend 1] and [Friend 2] liked your post."
        // If more than two people like your post, it returns: "[Friend 1], [Friend 2] and [Number of Other People] others liked your post."
        public static string FacebookLikes(params string[] names)
        {
            string strLikeMessage = "";

            if (names.Length == 1)
                strLikeMessage = string.Format("{0} liked your post.", names[0]);
            else if (names.Length == 2)
                strLikeMessage = string.Format("{0} and {1} liked your post.", names[0], names[1]);
            else if (names.Length > 2)
                strLikeMessage = string.Format("{0}, {1} and {2} others liked your post.", names[0], names[1], names.Length - 2);

            return strLikeMessage;
        }

        // 2 - Add to the method below that accepts any number of integers (minimum of two integers). If an
        // integer is a duplicate, return "Error". If all integers are unique, then order them in
        // ascending order and return the sorted result as a string of integers separated by spaces.
        public static string NumberSorter(params int[] numbers)
        {
            string strOrder = "Error";

            if (numbers.Length == numbers.Distinct().Count())
            {
                Array.Sort(numbers);
                strOrder = string.Join(' ', numbers);
            }

            return strOrder;
        }

        // 3 - Add to the method below that accepts a string for a name. Use an array to reverse the characters
        // then return the result as a string. "I like trains" should return "sniart ekil I". Return
        // "Error" if no text is inputted.
        public static string ReverseName(string name)
        {
            string strReverse = "Error";

            if (!string.IsNullOrEmpty(name))
            {
                char[] chars = name.ToCharArray();
                Array.Reverse(chars);
                strReverse = String.Join("", chars);
            }

            return strReverse;
        }

        // 4 - Add to the method below that accepts any number of integers. If none or less than 5 numbers,
        // return "Invalid Array"; otherwise, return the 3 smallest numbers as a string separated by
        // spaces, sorted in ascending order. Treat duplicate numbers normally.
        public static string SmallestNumbers(params int[] numbers)
        {
            int AmmountOfNumbers = 3;
            string strSmallest = "Invalid Array";
            int[] SmallNumber = new int[AmmountOfNumbers];

            if (numbers.Length >= 5)
            {
                Array.Sort(numbers);
                Array.Copy(numbers, SmallNumber, AmmountOfNumbers);
                strSmallest = string.Join(" ", SmallNumber);
            }

            return strSmallest;

        }

        // 5 - Add to the method below that accepts any number of numbers (assume at least two numbers). The numbers
        // may include duplicates. Return the distinct numbers as an array sorted by ascending order.
        // So for example, an array consisting of [2, 2, 1, 3] should return an integer array of [1, 2, 3]. 
        public static int[] UniqueNumbers(params int[] numbers)
        {
            int[] distictNumbers = numbers.Distinct().ToArray();
            Array.Sort(distictNumbers);

            return distictNumbers;
        }

        private static class Program
        {
            private static void Main()
            {
                // Use this section to test code should you feel the need.
                // Console.WriteLine(whatever);        
            }
        }
    }
}
