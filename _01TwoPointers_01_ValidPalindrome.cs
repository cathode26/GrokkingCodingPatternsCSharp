using System;

namespace EducativeGrokkingCodingPatterns
{
    
    class _01TwoPointers_01_ValidPalindrome
    {
        static public void IsPalindrome2(string input)
        {
            int begin = 0;
            int end = input.Length - 1;

            bool isPalindrome = true;
            while (begin < end)
            {
                if (input[begin] != input[end])
                {
                    isPalindrome = false;
                    break;
                }
                begin++;
                end--;
            }
            Console.WriteLine(isPalindrome.ToString());
        }

        //8/11/23
        //10:57am - 11:00am
        public static void IsPalindrome(string inputString)
        {
            
            int left = 0;
            int right = inputString.Length - 1;
            while (left < right && inputString[left] == inputString[right])
            {
                left++;
                right--;
            }
            if (right <= left)
                Console.WriteLine(inputString + " is a Palindrome");
            else
                Console.WriteLine(inputString + " is NOT a Palindrome");

        }
        static public void Compute()
        {
            string[] inputStrings = { "RACEACAR", "A", "ABCDEFGFEDCBA", "ABC", "ABCBA", "ABBA", "RACEACAR" };
            for (int i = 0; i < inputStrings.GetLength(0); i++)
            {
                Console.WriteLine("Test Case " + inputStrings[i]);
                IsPalindrome(inputStrings[i]);
                Console.WriteLine("------------------------------------------------------------------------------------");
            }
        }

    }
}
