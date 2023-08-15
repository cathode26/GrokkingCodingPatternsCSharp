using System;
using System.Collections.Generic;

namespace EducativeGrokkingCodingPatterns
{
    /*
        Write an algorithm to determine if a number n is happy.
        A happy number is a number defined by the following process:

        Starting with any positive integer, replace the number by the sum of the squares of its digits.
        Example: 34
                 3^2 + 4^2 = 9+16          = 25
                 2^2 + 5^2 = 4+25          = 29
                 2^2 + 9^2                 = 85
                 8^2 + 5^2                 = 89
                 8^2 + 9^2 = 64 + 81       = 145
                 1^2 + 4^2 + 5^2 = 1+16+25 = 42
                 4^2 + 2^2                 = 20
                 2^2                       = 4
                 4^2                       = 16
                 1^2 + 6^2                 = 37
                 3^2 + 7^2                 = 58
                 5^2 + 8^2                 = 89
            We have a loop, since we got 89 again, so it is not a happy number
                 
        Repeat the process until the number equals 1 (where it will stay), or it loops endlessly in a cycle which does not include 1.
        Those numbers for which this process ends in 1 are happy.
        Return TRUE if n is a happy number, and FALSE if not.

        If we have two loops we will eventually enter a cycle and the fast and slow calculation will overlap
        when this happens we will know it is not a happy number, or it will reach 1

     */

    class _02FastSlowPointer_01_HappyNumber
    {
        static public int SumOfSquares2(int number)
        {
            int sumOfSquares = 0;
            while (number > 0)
            {
                int remainder = number % 10;
                sumOfSquares += remainder * remainder;
                number = number / 10;
            }
            return sumOfSquares;
        }
        static public bool IsHappyNumber2(int number)
        {
            //take the modulus by 10
            //99%10 = 9
            //then divide by 10
            //99/10 = 9
            int fast = number;
            int slow = number;

            do
            {
                fast = SumOfSquares2(fast);
                fast = SumOfSquares2(fast);
                slow = SumOfSquares2(slow);
            } while (fast != 1 && slow != fast);

            if (fast == 1)
                return true;
            else
                return false;
        }

        //8/11/23  3:40pm
        static public long SumOfSquares(long number)
        {
            long total = 0;
            while (number > 0)
            {
                long leastSignificantDigit = number % 10;
                number /= 10;
                total += leastSignificantDigit * leastSignificantDigit;
            }
            return total;
        }
        static public bool IsHappyNumber(int isHappy)
        {
            long fast = isHappy;
            long slow = isHappy;
            do
            {
                fast = SumOfSquares(fast);
                fast = SumOfSquares(fast);
                slow = SumOfSquares(slow);
            } while (fast != 1 && fast != slow);

            if (fast == 1)
                return true;
            else
                return false;
        }

        static public void Compute()
        {
            List<int> inputs = new List<int> { 1, 5, 19, 25, 7, 8, 44488 };
            for (int i = 0; i < inputs.Count; i++)
            {
                Console.WriteLine(i + 1 + ".\tInput Number: " + inputs[i]);
                bool result = IsHappyNumber(inputs[i]);
                Console.WriteLine("\tIs it a happy number? " + result.ToString());
                Console.WriteLine("--------------------------------------------------------------------------");
            }
        }
    }
}
