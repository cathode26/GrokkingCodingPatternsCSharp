using System;
using System.Collections.Generic;

namespace EducativeGrokkingCodingPatterns
{
    public class _10Subsets_02_Permutations
    {
        /*
         *  Statement
            Given an input string, return all possible permutations of the string.

            Note: The order of permutations does not matter. 
            All characters in the input string are unique.

            1 ≤ word.length ≤ 6

            Example:
                                                                    ABCD
              ABCD                                 BACD                             CBAD                             DBCA
         ABCD ACBD ADCB                       BACD BCAD BDCA                    CBAD CABD CDAD                  DBCA DCBA  DACB
ABCD ABDC   ACBD ACDB   ADCB ADBC     BACD BADC  BCAD BCDA BDCA BDAC      CBAD CBDA CABD CADB CDAD CDDA    DBCA DBAC DCBA DCAB DACB DABC

        During each iteration, it generates permutations by swapping the `i`th character with every character from `i` 
        to the end of the string, it creates a new permutation for each swap.

        We create an entirely new set from the starting set.
        The starting set it ABCD and we create ABCD BACD CBAD DBCA, and we replace the old set with the new set.
        This continues iteratively and we create next 
        ABCD ACBD ADCB BACD BCAD BDCA CBAD CABD CDAD DBCA DCBA DACB
        the set of permutations keeps growing because for every swap in a character we create a new string
        */

        /// <summary>
        /// Swaps two characters in a string at the specified indices.
        /// </summary>
        public static string SwapCharacters(string str, int index1, int index2)
        {
            // Convert string to character array
            char[] charArray = str.ToCharArray();

            // Swap characters
            char temp = charArray[index1];
            charArray[index1] = charArray[index2];
            charArray[index2] = temp;

            // Convert character array back to string
            return new string(charArray);
        }
        /// <summary>
        /// Generates all permutations of the given word.
        /// </summary>
        static public string[] PermuteWord(string word)
        {
            // Initialize the permutations list with the original word.
            List<string> permutations = new List<string> { word };
            // Outer loop iterates through each character of the word.
            for (int i = 0; i < word.Length - 1; ++i)
            {
                // Temporary list to hold the permutations generated in the current iteration.
                List<string> curPermutations = new List<string>();
                
                // Inner loop iterates from the current character to the end of the word.
                for (int j = i; j < word.Length; ++j)
                {
                    // For each permutation generated so far, swap the 'i'th character with the 'j'th character 
                    // and add the new permutation to the temporary list.
                    foreach (string cur in permutations)
                        curPermutations.Add(SwapCharacters(cur, i, j));
                }
                // Update the main permutations list with the permutations generated in the current iteration.
                permutations = curPermutations;
            }
            // Return the final list of permutations as an array.
            return permutations.ToArray();
        }
        /// <summary>
        /// Test function to display permutations for a set of words.
        /// </summary>
        static public void Compute()
        {
            string[] inputWord = new string[] { "ab", "bad", "abcd" };
            for (int index = 0; index < inputWord.Length; index++)
            {
                string[] permutedWords = PermuteWord(inputWord[index]);
                Console.WriteLine((index + 1) + ".\t Input string: '" + inputWord[index] + "'");
                Console.WriteLine("\t All possible permutations are: ");
                Console.WriteLine(string.Join(", ", permutedWords));
                Console.WriteLine(new string('-', 100));
            }
        }
    }
}
