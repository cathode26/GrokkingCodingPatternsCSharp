using System;
using System.Text;

namespace EducativeGrokkingCodingPatterns
{
    /*Statement
        Given a sentence, reverse the order of its words without affecting the order of letters within a given word.
        The order of the letters within a word is not to be reversed.
        Sample example 1
        Input String
        "Hello Friend"
        Reversed String
        "Friend Hello"
     */

    class _01TwoPointers_03_ReverseWordsInString
    {
        static public char[] Reverse2(string str)
        {
            int left = 0;
            int right = str.Length - 1;
            char[] charArr = str.ToCharArray();

            while (left < right)
            {
                char temp = charArr[left];
                charArr[left] = charArr[right];
                charArr[right] = temp;
                left++;
                right--;
            }
            return charArr;
        }
        static public string ReverseWords2(string str)
        {
            char[] reversed = Reverse2(str);
            int begin = 0;
            int end = 0;
            while(begin < reversed.Length)
            {
                while (begin < reversed.Length && reversed[begin] == ' ')
                    begin++;
                end = begin;

                while (end+1 < reversed.Length && reversed[end+1] != ' ')
                    end++;

                if(end > begin)
                {
                    int left = begin;
                    int right = end;
                    while (left < right)
                    {
                        char temp = reversed[left];
                        reversed[left] = reversed[right];
                        reversed[right] = temp;
                        left++;
                        right--;
                    }
                }
                begin = end + 1;
            }
            return new string(reversed);
        }

        //8/11/2023
        public static string Reverse(string sentence, int left, int right)
        {
            StringBuilder builder = new StringBuilder(sentence);
            while (left < right)
            {
                char temp = builder[left];
                builder[left] = builder[right];
                builder[right] = temp;
                left++;
                right--;
            }
            return builder.ToString();
        }
        public static string ReverseWords(string sentence)
        {
            sentence = Reverse(sentence, 0, sentence.Length - 1);
            int begin = 0;
            int end = 0;
            int size = sentence.Length;
            while ( begin < size )
            {
                while (begin < size && sentence[begin] == ' ')
                    begin++;
                end = begin;
                while (end + 1 < size && sentence[end + 1] != ' ')
                    end++;

                sentence = Reverse(sentence, begin, end);

                begin = end+1;
            }

            return sentence;
        }
        
        static public string Print(int[] list)
        {
            string output = "";
            for (int i = 0; i < list.Length; i++)
                output += list[i].ToString() + " ";
            return output;
        }
        static public void Compute()
        {
            string[] stringsToReverse = {
                new string( " Hello    World " ),
                new string("We love Python"),
                new string("The quick brown fox jumped over the lazy dog"),
                new string("Hey"),
                new string("To be, or not to be"),
                new string("AAAAA"),
                new string(" Hello     World ")
            };
            for (int i = 0; i < stringsToReverse.Length; i++)
            {
                Console.WriteLine( (i + 1) + ".\tActual string:\t\t" + stringsToReverse[i] );
                string result = ReverseWords(stringsToReverse[i]);
                Console.WriteLine("\tReversed string:\t" + result );
                Console.WriteLine("--------------------------------------------------------------------");
            }
        }

    }
}
