using System;
using System.Collections.Generic;

namespace EducativeGrokkingCodingPatterns
{
    /*
     *  Minimum Window Subsequence
     *  Given two strings, str1 and str2, find the shortest substring in str1 such that str2 is a subsequence of that substring.

        A substring is defined as a contiguous sequence of characters within a string. A subsequence is a sequence that can be derived 
        from another sequence by deleting zero or more elements without changing the order of the remaining elements.

        Let’s say you have the following two strings:

        str1 = “abbcb”

        str2 = “ac”

        In this example, “abbc” is a substring of str1, from which we can derive str2 simply by deleting both the instances of the character b. 
        Therefore, str2 is a subsequence of this substring. Since this substring is the shortest among all the substrings in which str2 is 
        present as a subsequence, the function should return this substring, that is, “abbc”.

        If there is no substring in str1 that covers all characters in str2, return an empty string.

        If there are multiple minimum-length substrings that meet the subsequence requirement, return the one with the left-most starting index.

        //"abcdedeaaqdadeeaqdeq"
        //"adeq"
        //"abcdedeaaqdadeeaqdeq"  
        // ^^^^^^^^^^                The forward pass, we find abcdedeaaq
        // ^^^^^^^^^^                The backtracking pass, we go in reverse and find abcdedeaaq
        //  ^^^^^^^^^^^^^^^^         The next forward pass, bcdedeaaqdadeeaq
        //            ^^^^^^         The backtracking pass, we go in reverse and find adeeaq
        //             ^^^^^^^       The next forward pass, deeaqdeq
        //                ^^^^       The backtracking pass, we go in reverse and find aqdeq
     * 
     */
    class _03SlidingWindow_03_MinimumWindowSubsequence
    {
        public static string MinWindow(string str1, string str2)
        {
            int beginMin = 0;
            int endMin = 0;
            int windowSize = int.MaxValue;
            int beginStr1 = 0;
            int beginStr2 = 0;
            int endStr2 = 0;
            for (int endStr1 = 0; endStr1 < str1.Length; ++endStr1)
            {
                //search fowards for matching characters
                // If the current character in str1 matches the current character in str2.
                if (str1[endStr1] == str2[endStr2])
                {
                    endStr2++;
                    if (str2.Length == endStr2)
                    {
                        //Use backtracking to match the characters in reverse
                        //Since we have matched all of the characters we know that there is only 1 character that matches the 
                        //last character in string2, what this means is that we can guarantee that if we go in the reverse direction
                        //by backtracking that the first subsequence we find will be as long or shorter than the one we have found
                        //and that there will not be a shorter subsequence with a different ending character
                        //because by finding the only matching last character in string2 we
                        //know that to have a matching subsequence in this window, that it must use the last character. 

                        beginStr2 = endStr2 - 1;
                        beginStr1 = endStr1;
                        while(beginStr2 >= 0 )
                        {
                            if (str1[beginStr1] == str2[beginStr2])
                                beginStr2--;
                            beginStr1--;
                        }

                        // After backtracking, adjust the start position.
                        beginStr1 += 1;
                        // If the current subsequence is smaller than the previously found one.
                        if (windowSize > endStr1 - beginStr1 + 1)
                        {
                            beginMin = beginStr1;
                            endMin = endStr1;
                            windowSize = endMin - beginMin + 1;
                        }

                        // Reset pointers and move str1's pointer to the start of the next subsequence search.
                        endStr1 = beginStr1 + 1;
                        endStr2 = 0;
                    }
                }
            }

            if (windowSize == int.MaxValue)
                return "";
            else
                return str1.Substring(beginMin, windowSize);
        }

        public static void Compute()
        {
            List<string> str1 = new List<string> { "abcdedeaaqdadeeaqdeq", "fgrqsqsnodwmxzkzxwqegkndaa", "zxcvnhss", "alpha", "beta"};
            List<string> str2 = new List<string> { "adeq", "kzed", "css", "la", "ab"};

            for (int i = 0; i < str1.Count; i++)
            {
                Console.WriteLine((i + 1) + ".\tInput strings: (" + str1[i] + ", " + str2[i] + ")");
                Console.WriteLine("\tSubsequence string: " + MinWindow(str1[i], str2[i]));
                Console.WriteLine(new string('-', 100) );
            }
        }
    }
}
