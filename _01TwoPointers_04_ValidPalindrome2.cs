using System;

namespace EducativeGrokkingCodingPatterns
{
    /*
     * Write a function that takes a string as input and checks whether it can be a valid palindrome by removing at most one character from it.
     * 
     * To solve this problem you need to remember that if there are 2 characters that can be removed that means there are 2 possible solutions
     * When there are 2 possible solutions you need to check both because the first one you check might not be a palindrome but the 2nd solution
     * could be a palindrome.
     * 
     * This question is also like an introduction to recursion because there is branching in algorithm
     * 
     * This problem is an application of the Two Pointer technique, with a hint of recursion. You start with two pointers, one at the start of the string and the other at the end. 
     * You compare the characters at both pointers.
     * If they are the same, you move the pointers closer together and keep comparing.

    The recursion part comes in when the characters are not the same. In this case, you have two possible ways to potentially make the string into a palindrome:

    Remove the character at the start pointer and check if the remaining string is a palindrome.
    Remove the character at the end pointer and check if the remaining string is a palindrome.
    Since you don't know which character to remove, you need to check both possibilities. This is where the recursion comes in. For each possibility, you call a function that checks 
    if the resulting string is a palindrome.

    In your final solution, you used an auxiliary function, isPalindrome(), which itself used a two-pointer approach to check if a given range of the string is a palindrome. 
    So you're not actually using recursion in the sense of a function calling itself, but you are using a recursive-like concept by considering two possible 'branches' at each step.

    This problem is also interesting from an algorithmic perspective because it's not just about finding a palindrome (which would be a simple two-pointer problem), 
    but about finding a palindrome with an optional 'correction' of one character. This makes it more complex and introduces a branching factor in the solution. 
    So it's definitely a great problem for understanding both the two-pointer technique and the idea of branching in algorithms.
     */

    class _01TwoPointers_04_ValidPalindrome2
    {
        
        public static bool IsPalindrome2(int left, int right, string arr)
        {
            while(left < right)
            {
                if(arr[left] != arr[right])
                    return false;
                left++;
                right--;
            }
            return true;
        }
        public static bool ValidPalindrome2(string arr)
        {
            int left = 0;
            int right = arr.Length - 1;
            while(left < right)
            {

                if (arr[left] != arr[right])
                {
                    if (arr[left + 1] == arr[right] && IsPalindrome2(left + 2, right - 1, arr))
                        return true;
                    if (arr[left] == arr[right - 1] && IsPalindrome2(left + 1, right - 2, arr))
                        return true;
                    else
                        return false;
                }
                left++;
                right--;
            }
            return true;
        }
        
        //8/11/23 3:33 pm
        public static bool ValidPalindrome(string palindrome, int left, int right, bool swapped)
        {
            while (left < right)
            {
                if (palindrome[left] == palindrome[right])
                {
                    left++;
                    right--;
                }
                else if (swapped)
                {
                    return false;
                }
                else
                {
                    if (ValidPalindrome(palindrome, left+1, right, true))
                        return true;
                    else if (ValidPalindrome(palindrome, left, right-1, true))
                        return true;
                    else
                        return false;
                }
            }
            return true;
        }
        static public void Compute()
        {
            string[] inputStrings = { "abcdedadedecba", "abcbaa", "abca", "madame", "dead", "abca", "tebbem", "eeccccbebaeeabebccceea" };
            for (int i = 0; i < inputStrings.GetLength(0); i++)
            {
                Console.WriteLine("Test Case " + inputStrings[i]);
                if (ValidPalindrome(inputStrings[i], 0, inputStrings[i].Length - 1, false))
                    Console.WriteLine(inputStrings[i] + " is a valid palindrome");
                else
                    Console.WriteLine(inputStrings[i] + " is not a valid palindrome");

                Console.WriteLine("------------------------------------------------------------------------------------");
            }
        }
    }
}
