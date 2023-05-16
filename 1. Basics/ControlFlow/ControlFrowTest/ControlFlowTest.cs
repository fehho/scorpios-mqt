using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using FluentAssertions;

namespace ControlFrowTest
{
    [TestClass]
    public class AreYouValidTest
    {
        // 1.1 - Write a method that accepts an integer. The integer should be more than 1 but less
        // than 10. If the user enters a valid integer, return "Valid". Otherwise, return "Invalid".
        // (This logic is used a lot in applications where values entered into input boxes need to
        // be validated).  Negative numbers should return "Invalid".
        [TestMethod]
        public void ShouldBeValid()
        {
            var result = ControlFlow.ControlFlow.AreYouValid(5);

            const string expected = "Valid";

            result.Should().Be(expected, because: "5 should be a valid number");
        }

        [TestMethod]
        public void DoesNotAccept1or10()
        {
            var results = new[]
                         {
                             ControlFlow.ControlFlow.AreYouValid(10),
                             ControlFlow.ControlFlow.AreYouValid(1)
                         };

            results.Should().NotContain("Valid", because: "1 and 10 should not be acceptable values");
        }

        [TestMethod]
        public void ShouldNotBeAboveRange()
        {
            var result = ControlFlow.ControlFlow.AreYouValid(11);

            const string expected = "Invalid";

            result.Should().Be(expected, because: "11 is more than 10 and a number more than 10 is invalid");
        }

        [TestMethod]
        public void ShouldNotBeBelowRange()
        {
            var result = ControlFlow.ControlFlow.AreYouValid(0);

            const string expected = "Invalid";

            result.Should().Be(expected, because: "0 is less than 1 and a number less than 1 is invalid");
        }
    }

    // 1.2 - Write a method which takes two integers and returns the maximum of the two. If they
    // are the same, return either one. Don't Worry about input validation.
    [TestClass]
    public class MaximumTest
    {
        [TestMethod]
        public void FirstNumberShouldBeMax()
        {
            var result = ControlFlow.ControlFlow.Maximum(10, 5);

            const int expected = 10;

            result.Should().Be(expected, because: "10 should be more than 5");
        }

        [TestMethod]
        public void SecondNumberShouldBeMax()
        {
            var result = ControlFlow.ControlFlow.Maximum(11, 99);

            const int expected = 99;

            result.Should().Be(expected, because: "99 should be more than 11");
        }

        [TestMethod]
        public void BothNumbersAreMax()
        {
            var result = ControlFlow.ControlFlow.Maximum(7, 7);

            var expected = 7;

            result.Should().Be(expected, because: "it should return either number if they are equal");
        }

        [TestMethod]
        public void NegativeNumbers()
        {
            var result = ControlFlow.ControlFlow.Maximum(-3, -2);

            var expected = -2;

            result.Should().Be(expected, because: "it should return the 'highest' negative");
        }
    }

    // 1.3 - Write a method which takes two integers, the width and height of an image. Then
    // return a string to tell if the image is "Landscape" or "Portrait". Return "Square" if
    // they are equal. Assume non-negative values. Don't Worry about input validation.
    [TestClass]
    public class LandscapeOrPortraitTest
    {
        [TestMethod]
        public void ShouldBeLandscape()
        {
            var result = ControlFlow.ControlFlow.LandscapeOrPortrait(10, 5);

            var expected = "Landscape";

            result.Should().Be(expected, because: "10x5 should be Landscape");
        }

        [TestMethod]
        public void ShouldBePortrait()
        {
            var result = ControlFlow.ControlFlow.LandscapeOrPortrait(55, 1000);

            var expected = "Portrait";

            result.Should().Be(expected, because: "1000x55 should be Portrait");
        }

        [TestMethod]
        public void ShouldBeSquare()
        {
            var result = ControlFlow.ControlFlow.LandscapeOrPortrait(55, 55);

            var expected = "Square";

            result.Should().Be(expected, because: "55x55 should be Square");
        }
    }

    // 1.4 - Your job is to write a program for a speed camera. For simplicity, ignore the details
    // such as camera, sensors, etc and focus purely on the logic.
    //
    // Write a method that asks for a speed limit and for the speed of a car. Assume non-negative numbers.
    //
    // If the speed of the car is a value less than the speed limit, method should return "Okay".
    //
    // If the value is above the speed limit, the program should calculate the number of demerit
    // points. For every 5 above the speed limit, 1 demerit points should be incurred and
    // returned as a string.
    //
    // If the number of demerit points is above 12, the program should display "License
    // Suspended" instead. Don't Worry about input validation            result.Should().Be(expected, because: "55x55 should be Square");

    [TestClass]
    public class SpeedTrapTest
    {
        [TestMethod]
        public void ShouldBeOkay()
        {
            var result = ControlFlow.ControlFlow.SpeedTrap(speedLimit: 10, speedCar: 5);

            var expected = "Okay";

            result.Should().Be(expected, because: "the speed of a car is less than the speed limit");
        }

        /// <summary>
        /// Did they check whether or not driving at the speed limit was okay?
        /// </summary>
        [TestMethod]
        public void DrivingAtLimitOkay()
        {
            var result = ControlFlow.ControlFlow.SpeedTrap(speedLimit: 10, speedCar: 10);

            var expected = "Okay";

            result.Should().Be(expected, because: "the speed of a car is at the speed limit");
        }

        [TestMethod]
        public void DrivingTooFastYouGetAPoint()
        {
            var result = ControlFlow.ControlFlow.SpeedTrap(speedLimit: 15, speedCar: 20);

            var expected = "1";

            result.Should().Be(expected, because: "the speed of a car is 5 above the speed limit, which should return 1");
        }

        [TestMethod]
        public void DrivingFast4Points()
        {
            var result = ControlFlow.ControlFlow.SpeedTrap(15, 35);

            var expected = "4";

            result.Should().Be(expected, because: "the speed of a car is 20 above the speed limit, which should return 4");
        }

        [TestMethod]
        public void ReachingPointLimit()
        {
            var result = ControlFlow.ControlFlow.SpeedTrap(20, 80);

            var expected = "12";

            result.Should().Be(expected, because: "the speed of a car is 60 above the speed limit, which should return 12");
        }

        [TestMethod]
        public void LicenseSuspendedHere()
        {
            var result = ControlFlow.ControlFlow.SpeedTrap(20, 85);

            var expected = "License Suspended";

            result.Should().Be(expected, because: "the speed of a car is 65 above the speed limit, which should return 13 (License Suspended)");
        }

        [TestMethod]
        public void WayTooFastAmigo()
        {
            var result = ControlFlow.ControlFlow.SpeedTrap(15, 120);

            var expected = "License Suspended";

            result.Should().Be(expected, because: "the speed of a car is 115 above the speed limit, which is way too fast amigo");
        }
    }

    // 2.1 - Write a method to count how many integers in a range of two numbers are divisible by a
    // divider with no remainder. Return the count. For example, if minNumber
    // = 1 and maxNumber = 6, and the divider is 3 then output should be 2.
    [TestClass]
    public class DivisibleByNumberTest
    {
        [TestMethod]
        public void CorrectCount()
        {
            var result = ControlFlow.ControlFlow.DivisibleByNumber(10, 50, 5);

            var expected = 9;

            result.Should().Be(expected, because: "there are 9 numbers from x = 10 to x = 50 that are divisible by 9.");
        }

        [TestMethod]
        public void SameNumberForMinMax()
        {
            var result = ControlFlow.ControlFlow.DivisibleByNumber(14, 14, 7);

            var expected = 1;

            result.Should().Be(expected, because: "there is 1 number from x = 14 to x = 14 that are divisible by 9.");
        }

        [TestMethod]
        public void NotDivisibleByDivider()
        {
            var result = ControlFlow.ControlFlow.DivisibleByNumber(13, 15, 6);

            var expected = 0;

            result.Should().Be(expected, because: "there is no number from x = 13 to x = 15 that are divisible by 6.");
        }
    }

    // 2.2 - Write a method to calculate the sum of all the integers and return it. For example if
    // the program enters (2, 3, 5, 1) then the return should be 11. Don't Worry about input validation.
    [TestClass]
    public class SumIntegersTest
    {
        [TestMethod]
        public void CorrectSum()
        {
            var expected = 5;

            var result = ControlFlow.ControlFlow.SumIntegers(3, 2);

            result.Should().Be(expected, because: "3 + 2 = 5");
        }

        [TestMethod]
        public void NegativeNumbers()
        {
            var expected = -7;

            var result = ControlFlow.ControlFlow.SumIntegers(-4, -3);

            result.Should().Be(expected, because: "-3 + -4 = -7");
        }
    }

    // 2.3 - Write a method to compute the factorial of an integer return it. For example, if the
    // user enters 5, the program should calculate 5 x 4 x 3 x 2 x 1 and return it as 120. Make sure
    // that 0! = 1;
    [TestClass]
    public class FindFactorial
    {
        [TestMethod]
        public void CorrectFactorial()
        {
            var expected = 3628800;

            var result = ControlFlow.ControlFlow.FindFactorial(10);

            result.Should().Be(expected, because: "10! is equal to 3628800");
        }

        [TestMethod]
        public void SingleFactorial()
        {
            var expected = 1;

            var result = ControlFlow.ControlFlow.FindFactorial(1);

            result.Should().Be(expected, because: "1! is equal to 1");
        }

        [TestMethod]
        public void ZeroFactorial()
        {
            var expected = 1;

            var result = ControlFlow.ControlFlow.FindFactorial(0);

            result.Should().Be(expected, because: "0! is equal to 1");
        }
    }

    // 2.4 - Write a method that takes a series of integers separated by commas. Then find the
    // maximum of the numbers and return it. For example, if the numbers are 5, 3, 8, 1, 4", the program should return 8.
    // Don't Worry about input validation.
    [TestClass]
    public class MaximumNumberTest
    {
        [TestMethod]
        public void CorrectMaxNumber()
        {
            var expected = 12;

            var result = ControlFlow.ControlFlow.MaximumNumber(1, 7, 5, 12, 4);

            result.Should().Be(expected, because: "12 is the largest number in 1, 7, 5, 12, 4");
        }

        [TestMethod]
        public void OnlyNumber()
        {
            var expected = 14;

            var result = ControlFlow.ControlFlow.MaximumNumber(14);

            result.Should().Be(expected, because: "a number in a list of itself is also the max");
        }

        [TestMethod]
        public void MultipleOfSameMax()
        {
            var expected = 3;

            var result = ControlFlow.ControlFlow.MaximumNumber(1, 3, 3, 3);

            result.Should().Be(expected, because: "when there are duplicates of the same max number, it should still be the same max");
        }
    }
}
