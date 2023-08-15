using System;
using System.Collections.Generic;

namespace EducativeGrokkingCodingPatterns
{
	public class _03SlidingWindow_05_MinimumWindowSubstring
	{
		/*
		 * 
		 * Statement:
		 * 
			We are given two strings, s and t, find the minimum window substring of t in s.

			The minimum window substring of t in s is defined as follows:

			It is the shortest substring of s that includes all of the characters present in t.

			The frequency of each character in this substring that belongs to t should be equal to or greater than its frequency in t.

			The order of the characters does not matter here.

			Constraints:

			Strings s and t consist of uppercase and lowercase English characters.

			1 ≤ s.length, t.length ≤ 10^3

			What is the output if the following strings are given as input?

			s = “cabwefgewcwaefgcf”

			t = “cae”

			solution: cwae

			
			What is the output if the following strings are given as input?

			s = “bbaac”

			t = “aba”

			solution:“baa”

			The solution is based on the sliding window technique. Here's how it works step by step:

			Initialize Frequency Maps: The algorithm starts with two frequency maps:

			freqB for string t to keep track of the required characters and their frequencies.
			freqWindow to keep track of the characters and their frequencies in the current window of string s.
			Expand the Window: The algorithm begins at the start of string s and expands the window to the right (using the end pointer). 
			As the window expands, the algorithm updates the frequency of the character at the end pointer in freqWindow.

			Check for Required Characters: As the window expands, the algorithm checks if all the required characters from string t are present 
			in the current window with the required frequency. This is done using the curCharSetSize variable.

			Shrink the Window: Once all the required characters are found in the current window, the algorithm attempts to shrink the window from 
			the left (using the begin pointer) to find the minimum window that still contains all the characters of t. During the shrinking process, 
			the algorithm updates the freqWindow and checks if the window can be shrunk further without losing any required characters.

			Track the Minimum Window: Throughout the expanding and shrinking process, the algorithm keeps track of the minimum window size that contains 
			all the characters of t. This is done using the minWindowSize variable.

			Return the Result: Once the end pointer has traversed the entire string s, the algorithm returns the minWindowSize.

			The key insight here is the efficient use of the sliding window technique combined with frequency maps. The window expands to find all 
			required characters and then shrinks to find the minimum window, all while traversing the string only once, leading to an 
			O(n) solution.
		*/


		public static int MinWindow(string a, string b)
		{
			Dictionary<char, int> freqB = new Dictionary<char, int>();
			Dictionary<char, int> freqWindow = new Dictionary<char, int>();
			int charSetSize = 0;
			int curCharSetSize = 0;
			int minWindowSize = int.MaxValue;

			//Store b in its frequency map
			foreach (char c in b)
			{
				if (freqB.TryGetValue(c, out int value))
					freqB[c] = value + 1;
				else
					freqB[c] = 1;
			}

			charSetSize = freqB.Count;
			int begin = 0;
			for (int end = 0; end < a.Length; ++end)
			{
				char c = a[end];
				if (freqB.ContainsKey(c))
				{
					if (freqWindow.TryGetValue(c, out int value))
						freqWindow[c] = value + 1;
					else
						freqWindow[c] = 1;

					if (freqWindow[c] == freqB[c])
					{
						curCharSetSize++;
						while (curCharSetSize == charSetSize)
						{
							if (minWindowSize > end - begin + 1)
								minWindowSize = end - begin + 1;
							//Now remove a character from the set
							char beginChar = a[begin++];
							if (freqB.ContainsKey(beginChar))
							{
								freqWindow[beginChar]--;
								if (freqWindow[beginChar] < freqB[beginChar])
									curCharSetSize--;
							}
						}
					}
				}
			}

			return minWindowSize;
		}
		public static void Compute()
		{
			List<string> s = new List<string>{ "PATTERN", "LIFE", "ABRACADABRA", "STRIKER", "DFFDFDFVD"};
			List<string> t = new List<string> { "TN", "I", "ABC", "RK", "VDD"};
			for (int i = 0; i < s.Count; i++)
			{
				Console.Write((i + 1) + ".\ts: " + s[i] + "\n\tt: " + t[i]);
				Console.WriteLine( "\n\tThe minimum substring containing " +  t[i] + " is: " + MinWindow(s[i], t[i]) );
				Console.WriteLine(new string('-', 100));
			}
		}
	}
	
}