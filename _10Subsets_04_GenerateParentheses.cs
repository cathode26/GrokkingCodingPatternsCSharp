using System;
using System.Collections.Generic;
using System.Linq;

/*
 * Statement
For a given number, n, generate all combinations of balanced parentheses.

Constraints:   1 ≤ n ≤14

Example n = 3
    ((())), (()()), (())(), ()(()), ()()()
 */
namespace EducativeGrokkingCodingPatterns
{

    public class _10Subsets_04_GenerateParentheses
    {
        /// <summary>
        /// Generates all possible combinations of balanced parentheses for the given number n.
        /// </summary>
        /// <param name="n">Number of pairs of parentheses.</param>
        /// <returns>List of all combinations of balanced parentheses.</returns>
        public static List<string> GenerateCombinations(int n)
        {
            // Initialize a list with an empty combination having 0 open and closed parentheses.
            List<(string value, int open, int closed)> combinations = new List<(string value, int open, int closed)> { ("",0,0) };
                                                                                                                                     
            // Iterate for 2n times because for each open bracket, we must have a corresponding close bracket.
            for (int i = 0; i < n*2; ++i)       
            {
                // List to store the combinations generated in the current iteration.
                List<(string value, int open, int closed)> curCombinations = new List<(string value, int open, int closed)>();
                // Iterate through the existing combinations.
                foreach ((string value, int open, int closed) combination in combinations)
                {
                    // If we haven't reached the limit of open brackets, add an open bracket to the current combination.
                    if (combination.open < n)
                        curCombinations.Add((value: combination.value + "{", open: combination.open + 1, closed: combination.closed));
                    // If the number of closed brackets is less than open brackets, add a closed bracket to the current combination.
                    if (combination.closed < combination.open)
                        curCombinations.Add((value: combination.value + "}", open: combination.open, closed: combination.closed + 1));
                }
                // Update our main combinations list with the combinations generated in the current iteration.
                combinations = curCombinations;
            }
            // Extract the string values from our tuples and return as a list.
            return combinations.Select(a => a.value).ToList();
        }

        public static void Compute()
        {
            List<int> n = new List<int> { 1, 2, 3, 4, 5 };

            for (int i = 0; i < n.Count; i++)
            {
                Console.Write( (i + 1) + ".\tn = " + n[i] );
                List<string> result = GenerateCombinations(n[i]);
                Console.WriteLine ("\tAll combinations of valid balanced parentheses:");
                Console.WriteLine ( string.Join(", ", result));
                Console.WriteLine(new string('-', 100));
            }
        }
    }
}
