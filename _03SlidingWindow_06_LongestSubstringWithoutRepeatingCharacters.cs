using System;
using System.Collections.Generic;

namespace EducativeGrokkingCodingPatterns
{
    class _03SlidingWindow_06_LongestSubstringWithoutRepeatingCharacters
    {

        /*
         * 
         * Longest Substring without Repeating Characters

        Statement
        Given a string, str, return the length of the longest substring without repeating characters.

        Constraints:

        1 ≤ str.length ≤ 5×10^4
      
        str consists of English letters, digits, symbols, and spaces.

        */

        public static int FindLongestSubstring(string s)
        {
            Dictionary<char, int> charFreq = new Dictionary<char, int>();
            int begin = 0;
            int maximumLength = int.MinValue;
            for (int end = 0; end < s.Length; ++end)
            {
                char c = s[end];
                if (charFreq.TryGetValue(c, out int value) && value == 1)
                {
                    //we found a repeating character, keep moving begin until the duplicate is gone
                    do
                    {
                        charFreq[c]--;
                    } while (s[begin++] != c);
                    //now begin is after c and we can add to our charFreq
                }
                charFreq[c] = 1;
                if (maximumLength < end - begin + 1)
                    maximumLength = end - begin + 1;
            }
            if (maximumLength == int.MinValue)
                return 0;
            else
                return maximumLength;
        }
        public static void Compute()
        {
            List <string> str = new List<string>{
                "abcabcbb",
                "pwwkew",
                "bbbbb",
                "ababababa",
                "",
                "ABCDEFGHI",
                "ABCDEDCBA",
                "AAAABBBBCCCCDDDD"};

            for (int i = 0; i < str.Count; i++)
            {
                Console.WriteLine( (i + 1) + ". \tInput string: " + str[i] );
                Console.WriteLine("\tLength of longest substring: " + FindLongestSubstring(str[i]) );
                Console.WriteLine( new string('-', 100) );
            }
        }
    }
}
