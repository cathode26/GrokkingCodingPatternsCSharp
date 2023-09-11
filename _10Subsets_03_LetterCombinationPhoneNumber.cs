using System;
using System.Collections.Generic;

namespace EducativeGrokkingCodingPatterns
{
    /*
     *  Statement:
        Given a string containing digits from 2 to 9 inclusive, return all possible letter combinations 
        that the number could represent. Return the answer in any order.

        1 -> {}
        2 -> {abc}
        3 -> {def}
        4 -> {ghi}
        5 -> {jkl}
        6 -> {mno}
        7 -> {pqrs}
        8 -> {tuv}
        9 -> {wxyz}

        Example: 23
        So we are looking for combinations
        ad ae af bd be bf cd ce cf

    */

    public class _10Subsets_03_LetterCombinationPhoneNumber
    {
        public static List<string> LetterCombinations(string phoneNumber)
        {
            Dictionary<char, string> telephone = new Dictionary<char, string>
            {
                { '0', "" }, { '1', "" }, { '2', "abc" }, { '3', "def" }, { '4', "ghi" }, { '5', "jkl" }, { '6', "mno" }, { '7', "pqrs" }, { '8', "tuv" }, { '9', "wxyz" }, 
            };

            List<string> combinations = new List<string> { "" };    //start with an empty set and we will build upon the empty set

            foreach (char num in phoneNumber)                       //for each number in the telephone number
            {
                List<string> curCombinations = new List<string>();
                if (telephone.TryGetValue(num, out string charMaps))        //Look up the number in the number to letter map
                {
                    foreach (char charMap in charMaps)                      //for all of the letterr in the number to letter map
                        foreach (string combination in combinations)        //For all of the combinations, this starts with an empty set
                            curCombinations.Add(combination + charMap);     //append the letter to the end of the current combination
                }
                combinations = curCombinations;
            }

            combinations.Sort();

            return combinations;
        }

        public static void Compute()
        {
            string[] digitsArray = new string[] { "23", "73", "426", "78", "925", "2345"};
            int counter = 1;
            for (int digits = 0; digits < digitsArray.Length; digits++)
            {
                Console.WriteLine(counter + ".\t All letter combinations for '" + digitsArray[digits] + "': "
                    + string.Join(", ", LetterCombinations(digitsArray[digits] ))) ;

                counter++;
                Console.WriteLine( new string('-', 100) );
            }
        }
    }
}
