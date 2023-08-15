using System;
using System.Collections.Generic;

namespace EducativeGrokkingCodingPatterns
{
    /*
     * Write a function that takes a string as input and checks whether it can be a valid palindrome by removing at most k character from it.
     * This problem is not solved completely.
     * There is a stack problem, for large strings and large k, it will have a stack overflow.
     */

    class _01TwoPointers_05_ValidPalindrome3
    {

        public static bool ValidPalindrome(int left, int right, int k, string arr, HashSet<(int, int, int)> memo)
        {
            if (memo.Contains((left, right, k)))
                return false;

            while (left < right)
            {
                if (arr[left] != arr[right])
                {
                    if (k > 0)
                    {
                        if (ValidPalindrome(left + 1, right, k - 1, arr, memo))
                            return true;
                        if (ValidPalindrome(left, right - 1, k - 1, arr, memo))
                            return true;
                    }
                    memo.Add((left, right, k));
                    return false;
                }
                left++;
                right--;
            }
            return true;
        }
        
        public static bool ValidPalindromeSlow(int left, int right, int k, string arr)
        {
            while (left < right)
            {
                if (arr[left] != arr[right])
                {
                    if (k > 0)
                    {
                        if (ValidPalindromeSlow(left + 1, right, k - 1, arr))
                            return true;
                        if (ValidPalindromeSlow(left, right - 1, k - 1, arr))
                            return true;
                    }
                    return false;
                }
                left++;
                right--;
            }
            return true;
        }
        static public void Compute()
        {
            string[] inputStrings = { "ffffffffffffffffffffffffffffffffffffffjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjdshsdfsdfsdfddddddddddddddssssstttttttttttttttttttttttttttttttttttllllllllllllllllllfkljdfvkljdflvhkjfdklghfjdkhgkdflhgjkfdhgjkhdfgjkhfdljkghfljkghjkdlfhgljkdhfgljkhdfgjklhdfjkhgjkdfhgjkldhfgjkhdfgjkhdfjkglhdfjlkhgjkldfhgjkhdfgjlkhdfljkghjkfhgjklhflgjkhdlfjkghjldfkhgljhfdgjlkhdfgljkhdflkghljkdfhgjlkdfhgljkhdfgjklhdfjkghjdfkhgkljdfhgjkldhfgjklhdfgjklhfdkjghjkdfhgjkdhfgjkhdfgljkhldfgkjhfdljkghdfljkhgjkdfhgjkdfhsssssssssssssssssssssssssssssssssssaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaqqqqqqwqwksjdjdjdjdjdjdjdsawierrhvfjdddddddddsfdsfshhhhddgdgdgdghhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhsssssssssssssssssssssssssssssssssssssssssssssssssssssssslllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllliiuhhdddddddddddddddddddddddddddddddddddddddddhhhhhhhhhhhhhhffffffffffffffffffffffffffffjdjdhfhfhskdfklsdfjdsfefjfjggggggggggggggggggdfgvdfgdffaslabcdeddhdhdhdhssdfsdfdsfsdfdsfdsfdsfsdfsdffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjdshsdfsdfsdfddddddddddddddssssstttttttttttttttttttttttttttttttttttllllllllllllllllllfkljdfvkljdflvhkjfdklghfjdkhgkdflhgjkfdhgjkhdfgjkhfdljkghfljkghjkdlfhgljkdhfgljkhdfgjklhdfjkhgjkdfhgjkldhfgjkhdfgjkhdfjkglhdfjlkhgjkldfhgjkhdfgjlkhdfljkghjkfhgjklhflgjkhdlfjkghjldfkhgljhfdgjlkhdfgljkhdflkghljkdfhgjlkdfhgljkhdfgjklhdfjkghjdfkhgkljdfhgjkldhfgjklhdfgjklhfdkjghjkdfhgjkdhfgjkhdfgljkhldfgkjhfdljkghdfljkhgjkdfhgjkdfhsssssssssssssssssssssssssssssssssssaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaqqqqqqwqwksjdjdjdjdjdjdjdsawierrhvfjdddddddddsfdsfshhhhddgdgdgdghhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhsssssssssssssssssssssssssssssssssssssssssssssssssssssssslllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllliiuhhdddddddddddddddddddddddddddddddddddddddddhhhhhhhhhhhhhhffffffffffffffffffffffffffffjdjdhfhfhskdfklsdfjdsfefjfjggggggggggggggggggdfgvdfgdffasleoefjvfjvnvjdhjffsgfdgkdjfjhffffffffffffffkdkdkdkdsldkdksldkdksldkskddkskdkskdahakakdjsklfhkshfkwehfksdhfjsdkhfweukfhlkjdshfuwehadedecbaabcdeddhdhdhdhssdfsdfdsfsdfdsfdsfdsfsdfsdffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjdshsdfsdfsdfddddddddddddddssssstttttttttttttttttttttttttttttttttttllllllllllllllllllfkljdfvkljdflvhkjfdklghfjdkhgkdflhgjkfdhgjkhdfgjkhfdljkghfljkghjkdlfhgljkdhfgljkhdfgjklhdfjkhgjkdfhgjkldhfgjkhdfgjkhdfjkglhdfjlkhgjkldfhgjkhdfgjlkhdfljkghjkfhgjklhflgjkhdlfjkghjldfkhgljhfdgjlkhdfgljkhdflkghljkdfhgjlkdfhgljkhdfgjklhdfjkghjdfkhgkljdfhgjkldhfgjklhdfgjklhfdkjghjkdfhgjkdhfgjkhdfgljkhldfgkjhfdljkghdfljkhgjkdfhgjkdfhsssssssssssssssssssssssssssssssssssaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaqqqqqqwqwksjdjdjdjdjdjdjdsawierrhvfjdddddddddsfdsfshhhhddgdgdgdghhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhsssssssssssssssssssssssssssssssssssssssssssssssssssssssslllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllliiuhhdddddddddddddddddddddddddddddddddddddddddhhhhhhhhhhhhhhffffffffffffffffffffffffffffjdjdhfhfhskdfklsdfjdsfefjfjggggggggggggggggggdfgvdfgdffasleoefjvfjvnvjdhjffsgfdgkdjfjhffffffffffffffkdkdkdkdsldkdksldkdksldkskddkskdkskdahakakdjsklfhkshfkwehfksdhfjsdkhfweukfhlkjdshfuwehadedecbaabcdeddhdhdhdhssdfsdfdsfsdfdsfdsfdsfsdfsdffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjdshsdfsdfsdfddddddddddddddssssstttttttttttttttttttttttttttttttttttllllllllllllllllllfkljdfvkljdflvhkjfdklghfjdkhgkdflhgjkfdhgjkhdfgjkhfdljkghfljkghjkdlfhgljkdhfgljkhdfgjklhdfjkhgjkdfhgjkldhfgjkhdfgjkhdfjkglhdfjlkhgjkldfhgjkhdfgjlkhdfljkghjkfhgjklhflgjkhdlfjkghjldfkhgljhfdgjlkhdfgljkhdflkghljkdfhgjlkdfhgljkhdfgjklhdfjkghjdfkhgkljdfhgjkldhfgjklhdfgjklhfdkjghjkdfhgjkdhfgjkhdfgljkhldfgkjhfdljkghdfljkhgjkdfhgjkdfhsssssssssssssssssssssssssssssssssssaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaqqqqqqwqwksjdjdjdjdjdjdjdsawierrhvfjdddddddddsfdsfshhhhddgdgdgdghhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhsssssssssssssssssssssssssssssssssssssssssssssssssssssssslllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllliiuhhdddddddddddddddddddddddddddddddddddddddddhhhhhhhhhhhhhhffffffffffffffffffffffffffffjdjdhfhfhskdfklsdfjdsfefjfjggggggggggggggggggdfgvdfgdffasleoefjvfjvnvjdhjffsgfdgkdjfjhffffffffffffffkdkdkdkdsldkdksldkdksldkskddkskdkskdahakakdjsklfhkshfkwehfksdhfjsdkhfweukfhlkjdshfuwehadedecbaabcdeddhdhdhdhssdfsdfdsfsdfdsfdsfdsfsdfsdffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjdshsdfsdfsdfddddddddddddddssssstttttttttttttttttttttttttttttttttttllllllllllllllllllfkljdfvkljdflvhkjfdklghfjdkhgkdflhgjkfdhgjkhdfgjkhfdljkghfljkghjkdlfhgljkdhfgljkhdfgjklhdfjkhgjkdfhgjkldhfgjkhdfgjkhdfjkglhdfjlkhgjkldfhgjkhdfgjlkhdfljkghjkfhgjklhflgjkhdlfjkghjldfkhgljhfdgjlkhdfgljkhdflkghljkdfhgjlkdfhgljkhdfgjklhdfjkghjdfkhgkljdfhgjkldhfgjklhdfgjklhfdkjghjkdfhgjkdhfgjkhdfgljkhldfgkjhfdljkghdfljkhgjkdfhgjkdfhsssssssssssssssssssssssssssssssssssaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaqqqqqqwqwksjdjdjdjdjdjdjdsawierrhvfjdddddddddsfdsfshhhhddgdgdgdghhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhsssssssssssssssssssssssssssssssssssssssssssssssssssssssslllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllliiuhhdddddddddddddddddddddddddddddddddddddddddhhhhhhhhhhhhhhffffffffffffffffffffffffffffjdjdhfhfhskdfklsdfjdsfefjfjggggggggggggggggggdfgvdfgdffasleoefjvfjvnvjdhjffsgfdgkdjfjhffffffffffffffkdkdkdkdsldkdksldkdksldkskddkskdkskdahakakdjsklfhkshfkwehfksdhfjsdkhfweukfhlkjdshfuwehadedecbaeoefjvfjvnvjdhjffsgfdgkdjfjhffffffffffffffkdkdkdkdsldkdksldkdksldkskddkskdkskdahakakdjsklfhkshfkwehfksdhfjsdkhfweukfhlkjdshfuwehadedecbaeoefjvfjvnvjdhjffsgfdgkdjfjhffffffffffffffkdkdkdkdsldkdksldkdksldkskddkskdkskdahakakdjsklfhkshfkwehfksdhfjsdkhfweukfhlkjdshfuwehadedecba", "abcbaa", "abca", "madame", "dead", "abca", "tebbem", "eeccccbebaeabcdefgeabebccceea" };
            for (int i = 0; i < inputStrings.GetLength(0); i++)
            {
                Console.WriteLine("Test Case ");// + inputStrings[i]);
                if (ValidPalindrome(0, inputStrings[i].Length - 1, 10000, inputStrings[i], new HashSet<(int, int, int)>()))
                    Console.WriteLine(i.ToString() /*inputStrings[i]*/ + " is a valid palindrome");
                else
                    Console.WriteLine(i.ToString() /*inputStrings[i]*/ + " is not a valid palindrome");

                Console.WriteLine("------------------------------------------------------------------------------------");
                
            }


            for (int i = 0; i < inputStrings.GetLength(0); i++)
            {
                if (ValidPalindromeSlow(0, inputStrings[i].Length - 1, 10000, inputStrings[i]))
                    Console.WriteLine(i.ToString() /*inputStrings[i]*/ + " is a valid palindrome");
                else
                    Console.WriteLine(i.ToString() /*inputStrings[i]*/ + " is not a valid palindrome");

                Console.WriteLine("------------------------------------------------------------------------------------");

            }
        }
    }
}
