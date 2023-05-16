using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WorkingWithTextTest
{
    // 1- Write a method that accepts a string of positive integers separated by hyphens, if the input is incorrect, return false.
    // Work out if the numbers are consecutive. For example, if the input is "5-6-7-8-9" or
    // "20-19-18-17-16", return bool True; otherwise, return bool False. If the string
    // is badly formatted, also return false.
    // Do not use .Sort, it will cause the test to pass when it actually does not.
    [TestClass]
    public class IsConsecutiveTest
    {
        [TestMethod]
        public void IsInputHyphenated()
        {
            var actual = WorkingWithText.WorkingWithText.IsConsecutive("6-4 2,9");

            actual.Should().BeFalse(because: "the input (6-4 2,9) is not hyphenated");
        }

        [TestMethod]
        public void IsInputMultiHyphenated()
        {
            var actual = WorkingWithText.WorkingWithText.IsConsecutive("6--4-2---9");

            actual.Should().BeFalse(because: "the input (6--4-2---9) has more than one hyphen between numbers");
        }

        [TestMethod]
        public void IsInputConsecutiveAscending()
        {
            var actual = WorkingWithText.WorkingWithText.IsConsecutive("1-2-3-4");

            actual.Should().BeTrue(because: "the input (1-2-3-4) is in consecutive ascending order");
        }

        [TestMethod]
        public void IsInputConsecutiveDescending()
        {
            var actual = WorkingWithText.WorkingWithText.IsConsecutive("9-8-7-6");

            actual.Should().BeTrue(because: "the input (9-8-7-6) is in consecutive descending order");
        }

        [TestMethod]
        public void IsInputNotConsecutive()
        {
            var actual = WorkingWithText.WorkingWithText.IsConsecutive("2-2-2-2");

            actual.Should().BeFalse(because: "the input is not consecutive");
        }

        [TestMethod]
        public void IsEveryOtherInputNotConsecutive()
        {
            var actual = WorkingWithText.WorkingWithText.IsConsecutive("15-16-7-18-19");

            actual.Should().BeFalse(because: "the input (15-16-7-18-19) is NOT incrementally consecutive");
        }

        [TestMethod]
        public void NotConsecutive()
        {
            var result = WorkingWithText.WorkingWithText.IsConsecutive("1-2-4-3");

            result.Should().BeFalse(because: "the input (1-2-4-3) is not consecutive");
        }

        [TestMethod]
        public void AlternatingConsecutive()
        {
            var result = WorkingWithText.WorkingWithText.IsConsecutive("15-16-15-16-15-16");

            result.Should().BeFalse(because: "the input is alternating consecutive (15 - 16 - 15 - 16 - 15 - 16)");
        }
    }


    // 2- Write a method that accepts a few integers separated by a hyphen. If the input is incorrect, return false. Check
    // to see if there are duplicates. If so, return bool True; otherwise, return bool False.
    [TestClass]
    public class AreThereDuplicatesTest
    {
        [TestMethod]
        public void IsInputHyphenated()
        {
            var actual = WorkingWithText.WorkingWithText.AreThereDuplicates("6-4 2,9");

            actual.Should().BeFalse(because: "the input (6-4 2,9) is not separated properly by hyphens");
        }

        [TestMethod]
        public void IsInputMultiHyphenated()
        {
            var actual = WorkingWithText.WorkingWithText.AreThereDuplicates("6--4-2---9");

            actual.Should().BeFalse(because: "the input (6--4-2---9) has more than one hyphen between numbers");
        }

        [TestMethod]
        public void DoesInputHaveDuplicates()
        {
            var actual = WorkingWithText.WorkingWithText.AreThereDuplicates("6-4-6-1");

            actual.Should().BeTrue(because: "the input (6-4-6-1) has a duplicate");
        }

        [TestMethod]
        public void IsInputOnlyDuplicates()
        {
            var actual = WorkingWithText.WorkingWithText.AreThereDuplicates("7-7-7-7");

            actual.Should().BeTrue(because: "the input (7-7-7-7) is all the same number");
        }

        [TestMethod]
        public void DoesInputHaveMultipleDuplicates()
        {
            var actual = WorkingWithText.WorkingWithText.AreThereDuplicates("6-7-6-7-6-7");

            actual.Should().BeTrue(because: "the input (6-7-6-7-6-7) is alternating duplicate numbers");
        }

        [TestMethod]
        public void DoesInputHaveNoDuplicates()
        {
            var actual = WorkingWithText.WorkingWithText.AreThereDuplicates("1-24-6-48");

            actual.Should().BeFalse(because: "the input (1-24-6-48) has no duplicates");
        }
    }

    // 3- Write a method that accepts a string of a time in 24-hour time format
    // (e.g. "09:00"). A valid time should be between 00:00 and 23:59. If the time is valid,
    // return a bool True; otherwise, return a bool False. If the user doesn't provide any values,
    // consider it as False.
    [TestClass]
    public class IsValidTimeTest
    {
        [TestMethod]
        public void IsTimeEmpty()
        {
            var actual = WorkingWithText.WorkingWithText.IsValidTime(null);

            actual.Should().BeFalse(because: "input is null");
        }

        [TestMethod]
        public void DoesTimeHaveAColon()
        {
            var actual = WorkingWithText.WorkingWithText.IsValidTime("1200");

            actual.Should().BeFalse(because: "the input time (1200) does not have a colon");
        }

        [TestMethod]
        public void DoesTimeHaveNoSpace()
        {
            var actual = WorkingWithText.WorkingWithText.IsValidTime("12 13");

            actual.Should().BeFalse(because: "the input time (12 13) is separated by a space instead of a colon");
        }

        [TestMethod]
        public void TimeHasCorrectFormat()
        {
            var actual = WorkingWithText.WorkingWithText.IsValidTime("13:45");

            actual.Should().BeTrue(because: "the input (13:45) is in the correct time format");
        }

        [TestMethod]
        public void IsTimeStartOfDay()
        {
            var actual = WorkingWithText.WorkingWithText.IsValidTime("00:00");

            actual.Should().BeTrue(because: "the input time matches the start of new day");
        }

        [TestMethod]
        public void IsTimeEndOfDay()
        {
            var actual = WorkingWithText.WorkingWithText.IsValidTime("23:59");

            actual.Should().BeTrue(because: "the input time (23:59) matches the end of the day");
        }

        [TestMethod]
        public void AreMinutesBelow60()
        {
            var actual = WorkingWithText.WorkingWithText.IsValidTime("12:63");

            actual.Should().BeFalse(because: "the input (12:63) minutes time is above 60 minutes");
        }

        [TestMethod]
        public void AreHoursBelow24()
        {
            var actual = WorkingWithText.WorkingWithText.IsValidTime("25:05");

            actual.Should().BeFalse(because: "the input (25:05) hours time is above 24 hours");
        }

        [TestMethod]
        public void DoesTimeHaveLeading0()
        {
            var actual = WorkingWithText.WorkingWithText.IsValidTime("9:39");

            actual.Should().BeFalse(because: "the input (9:39) needs to lead with 0 if hour is singular");
        }

        [TestMethod]
        public void NoMultipleColons()
        {
            var actual = WorkingWithText.WorkingWithText.IsValidTime("09:39:0");

            actual.Should().BeFalse(because: "the input (09:39:0) has multiple semicolons");
        }

        [TestMethod]
        public void DontAcceptLetters()
        {
            var actual = WorkingWithText.WorkingWithText.IsValidTime("AB:CD");

            actual.Should().BeFalse(because: "the input (AB:CD) has invalid characters");
        }
    }

    // 4- Write a method that accepts a string of words separated by spaces with no special characters. Use the
    // words to create a variable name with PascalCase. For example, if the user types: "number
    // of students", return "NumberOfStudents". Make sure that the program is not dependent on
    // the input. So, if the user types "NUMBER OF STUDENTS", the program should still display "NumberOfStudents".
    // If string is empty, return the empty string.
    [TestClass]
    public class PascalConverterTest
    {
        [TestMethod]
        public void CorrectlyProcessesEmptyString()
        {
            var actual = WorkingWithText.WorkingWithText.PascalConverter(null);

            actual.Should().BeNullOrEmpty(because: "input is either null or empty");
        }

        [TestMethod]
        public void DoesStringChangeToOneWord()
        {
            var expected = "HouseForDogs";

            var actual = WorkingWithText.WorkingWithText.PascalConverter("House For Dogs");

            actual.Should().Be(expected, because: "the input is converted to one word");
        }

        [TestMethod]
        public void CorrectPascalCase()
        {
            var expected = "DoesItRain";

            var actual = WorkingWithText.WorkingWithText.PascalConverter("does it rain");

            actual.Should().Be(expected, because: "input is changed to one word with every starting letter capitalized");
        }

        [TestMethod]
        public void CorrectPascalCaseFromAllCaps()
        {
            var expected = "FunForAll";

            var actual = WorkingWithText.WorkingWithText.PascalConverter("FUN FOR ALL");

            actual.Should().Be(expected, because: "input is changed from all caps to correct Pascal case");
        }

        [TestMethod]
        public void CorrectPascalCaseFromAlternatingCaps()
        {
            var expected = "WhatIsMyNameJimmyBoi";

            var actual = WorkingWithText.WorkingWithText.PascalConverter("WHAT Is my NaMe JiMmY bOi");

            actual.Should().Be(expected, because: "input is changed from varied capitalization to correct Pascal Case");
        }

        [TestMethod]
        public void CorrectPascalCaseFromOneWord()
        {
            var expected = "Funforall";

            var actual = WorkingWithText.WorkingWithText.PascalConverter("FunForAll");

            actual.Should().Be(expected, because: "input is changed from singular word to correct Pascal Case");
        }

        [TestMethod]
        public void CorrectPascalCaseFromLetters()
        {
            var expected = "WHY";

            var actual = WorkingWithText.WorkingWithText.PascalConverter("w h y");

            actual.Should().Be(expected, because: "input is changed from separate letters into one capitalized word");
        }

        [TestMethod]
        public void DoesInputTrim()
        {
            var expected = "Yeet";

            var actual = WorkingWithText.WorkingWithText.PascalConverter("yeet ");

            actual.Should().Be(expected, because: "input has unnecessary spaces trimmed off");
        }
    }


    // 5- Write a method that accepts one string with no special characters. Count the number of vowels
    // (a, e, i, o, u) in the word. For this prompt "y" will not classify as a vowel. So, if the user enters "inadequate", the program should
    // return 6. If the user enters "InAdEqUaTe" it should still say 6. If string is empty, return 0.
    [TestClass]
    public class VowelCounterTest
    {
        [TestMethod]
        public void IsStringEmpty()
        {
            var expected = 0;

            var actual = WorkingWithText.WorkingWithText.VowelCounter("");

            actual.Should().Be(expected, because: "vowel count should be 0 if input is empty");
        }

        [TestMethod]
        public void NoVowelWord()
        {
            var expected = 0;

            var actual = WorkingWithText.WorkingWithText.VowelCounter("why");

            actual.Should().Be(expected, because: "vowel count should be 0 if input has no vowels");
        }

        [TestMethod]
        public void OnlyVowelWord()
        {
            var expected = 6;

            var actual = WorkingWithText.WorkingWithText.VowelCounter("Euouae");

            actual.Should().Be(expected, because: "vowel count should be the length of the input if the input is all vowels");
        }

        [TestMethod]
        public void CorrectVowelCount()
        {
            var expected = 3;

            var actual = WorkingWithText.WorkingWithText.VowelCounter("Pentagon");

            actual.Should().Be(expected, because: "vowel count should be the number of vowels in the input");
        }

        [TestMethod]
        public void VowelCounterIsNotCaseSensitive()
        {
            var expected = 5;

            var actual = WorkingWithText.WorkingWithText.VowelCounter("AeIoU");

            actual.Should().Be(expected, because: "vowel count should be the amount of vowels in the input regardless of capitalization");
        }

        [TestMethod]
        public void MoreThanOneWord()
        {
            var expected = 7;

            var actual = WorkingWithText.WorkingWithText.VowelCounter("the dog ate my homework");

            actual.Should().Be(expected, because: "vowel count should count the vowels even if input contains spaces");
        }

        [TestMethod]
        public void JustOneLetter()
        {
            var expected = 0;

            var actual = WorkingWithText.WorkingWithText.VowelCounter("B");

            actual.Should().Be(expected, because: "vowel count should be 0 if the input is not a vowel regardless of capitalization");
        }

        [TestMethod]
        public void JustOneVowel()
        {
            var expected = 1;

            var actual = WorkingWithText.WorkingWithText.VowelCounter("e");

            actual.Should().Be(expected, because: "vowel count should be 1 if the input is just one vowel");
        }
    }
}