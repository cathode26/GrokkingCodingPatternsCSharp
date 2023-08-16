using System;
using System.Collections.Generic;

namespace EducativeGrokkingCodingPatterns
{

    /*
     * Interval List Intersections
     * 
     * For two lists of closed intervals given as input, intervalListA and intervalListB, where each interval has its own start and end time, write a function that 
     * returns the intersection of the two interval lists.

        For example, the intersection of 
        [3,8] and [5,10]  is [5,8]
     * 
     * 
     */

    public class _04MergeIntervals_03_IntervalListIntersections
    {
        static public Interval[] IntervalsIntersection(Interval[] inputIntervalListA, Interval[] inputIntervalListB)
        {
            List<Interval> intersections = new List<Interval>();
            int aIndex = 0;
            int bIndex = 0;

            Array.Sort(inputIntervalListA, (l, r) => l.begin.CompareTo(r.begin));
            while (aIndex < inputIntervalListA.Length && bIndex < inputIntervalListB.Length)
            {
                if (inputIntervalListA[aIndex].begin <= inputIntervalListB[bIndex].end && inputIntervalListA[aIndex].end >= inputIntervalListB[bIndex].begin)
                {
                    int end = Math.Min(inputIntervalListA[aIndex].end, inputIntervalListB[bIndex].end);
                    int begin = Math.Max(inputIntervalListA[aIndex].begin, inputIntervalListB[bIndex].begin);
                    intersections.Add(new Interval(begin, end));
                }
                if (inputIntervalListA[aIndex].begin < inputIntervalListB[bIndex].begin)
                    aIndex++;
                else
                    bIndex++;
            }
            return intersections.ToArray();
        }
        static public void Compute()
        {
            Interval[][] inputIntervalListA = new Interval[][]
            {
                new Interval[] { new Interval(1, 2) },
                new Interval[] { new Interval(1, 4), new Interval(5, 6), new Interval(9, 15) },
                new Interval[] { new Interval(3, 6), new Interval(8, 16), new Interval(17, 25) },
                new Interval[] { new Interval(4, 7), new Interval(9, 16), new Interval(17, 28), new Interval(39, 50), new Interval(55, 66), new Interval(70, 89) },
                new Interval[] { new Interval(1, 3), new Interval(5, 6), new Interval(7, 8), new Interval(12, 15) }
            };

            Interval[][] inputIntervalListB = new Interval[][]
            {
                new Interval[] { new Interval(1, 2)},
                new Interval[] { new Interval(2, 4), new Interval(5, 7), new Interval(9, 15) },
                new Interval[] { new Interval(2, 3), new Interval(10, 15), new Interval(18, 23) },
                new Interval[] { new Interval(3, 6),  new Interval(7, 8),  new Interval(9, 10), new Interval(14, 19),  new Interval(23, 33),  new Interval(35, 40), new Interval(45, 59),  new Interval(60, 64),  new Interval(68, 76)},
                new Interval[] { new Interval(2, 4),  new Interval(7, 10) }
            };

            for (int i = 0; i < inputIntervalListA.Length; i++)
            {
                Console.WriteLine((i + 1) + ".\t Interval List A: [" + string.Join<Interval>(", ", inputIntervalListA[i]) + "]");
                Console.WriteLine( "\t Interval List B: [" +  string.Join<Interval>(", ", inputIntervalListB[i]) + "]");
                Interval[] intersection = IntervalsIntersection(inputIntervalListA[i], inputIntervalListB[i]);
                Console.WriteLine("\t Intersecting intervals in 'A' and 'B' are: " + string.Join<Interval>(", ", intersection));
                Console.WriteLine(new string('-', 100));
            }
        }
    }
}
