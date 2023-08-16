using System;
using System.Collections.Generic;

namespace EducativeGrokkingCodingPatterns
{

    /*
     * We are given an array of closed intervals,

    A closed interval includes its start and end points and can be expressed as 
    x∈[a,b]or as a ≤ x ≤ b, while an open interval does not include either its start or 
    its end point, and can be expressed as x∈(a,b) or as a<x<b.

    where each interval has a start time and an end time. The input array is sorted with 
    respect to the start times of each interval. For example, intervals = [ [1,4], [3,6], [7,9] ]
    is sorted in terms of start times 1, 3, and 7.

    Your task is to merge the overlapping intervals and return a new output array consisting of only 
    the non-overlapping intervals.

    Constraints:
    
    1 ≤ intervals.length ≤ 10^4
    intervals[i].length = 2
    0 ≤ start time ≤ end time ≤ 10^4

    Input Intervals array [1, 5], [3, 7], [4, 6], [6, 8]
    Ouput [1, 8]

    Intervals [1, 5], [3, 7], [4, 6], [6, 8] are overlapping.
    Merge them to one interval [1, 8].
    */

    public class _04MergeIntervals_01_MergeIntervals
    {
        public static Interval[] MergeIntervals1st(Interval[] intervals)
        {
            //Sort the intervals by begin
            Array.Sort(intervals, (intervalA, IntervalB) => { return intervalA.begin.CompareTo(IntervalB.begin); } ); 
            List<Interval> newIntervals = new List<Interval>();
            Interval curInterval = intervals[0];
            for (int i = 1; i < intervals.Length; ++i)
            {
                if (curInterval.end >= intervals[i].begin)
                {
                    if(curInterval.end < intervals[i].end)
                        curInterval.end = intervals[i].end;
                }
                else
                {
                    newIntervals.Add(curInterval);
                    curInterval = intervals[i];
                }
            }
            newIntervals.Add(curInterval);

            return newIntervals.ToArray();
        }
        public static Interval[] MergeIntervals(Interval[] intervals)
        {
            if(intervals == null || intervals.Length == 0)
                return null;

            //Sort the intervals by begin
            Array.Sort(intervals, (intervalA, IntervalB) => { return intervalA.begin.CompareTo(IntervalB.begin); });

            Interval curInterval = new Interval(intervals[0].begin, intervals[0].end);
            List<Interval> newIntervals = new List<Interval> { curInterval };

            for (int i = 1; i < intervals.Length; ++i)
            {
                if (curInterval.end >= intervals[i].begin)
                {
                    if (curInterval.end < intervals[i].end)
                        curInterval.end = intervals[i].end;
                }
                else
                {
                    curInterval = new Interval(intervals[i].begin, intervals[i].end);
                    newIntervals.Add(curInterval);
                }
            }

            return newIntervals.ToArray();
        }
        public static void Compute()
        {
            Interval[] v1 = new Interval[] { new Interval(1, 5), new Interval(3, 7), new Interval(4, 6) };
            Interval[] v2 = new Interval[] { new Interval(1, 5), new Interval(4, 6), new Interval(6, 8), new Interval(11, 15) };
            Interval[] v3 = new Interval[] { new Interval(3, 7), new Interval(6, 8), new Interval(10, 12), new Interval(11, 15) };
            Interval[] v4 = new Interval[] { new Interval(1, 5) };
            Interval[] v6 = new Interval[] { new Interval(1, 9), new Interval(3, 8), new Interval(4, 4) };
            Interval[] v7 = new Interval[] { new Interval(1, 2), new Interval(3, 4), new Interval(8, 8) };
            Interval[] v8 = new Interval[] { new Interval(1, 5), new Interval(1, 3) };
            Interval[] v9 = new Interval[] { new Interval(1, 5), new Interval(6, 9) };
            Interval[] v10 = new Interval[] { new Interval(0, 0), new Interval(1, 18), new Interval(1, 3) };

            Interval[][] vArray = new Interval[][] { v1, v2, v3, v4, v6, v7, v8, v9, v10 };

            for (int i = 0; i < vArray.Length; i++)
            {
                Console.WriteLine( i + 1 + ".\tIntervals to merge: [" + string.Join(", ", (IEnumerable<Interval>)vArray[i]) + "]");
                Interval[] result = MergeIntervals(vArray[i]);
                Console.WriteLine("\tMerged intervals: [" + string.Join(", ", (IEnumerable<Interval>)result) + "]");
                Console.WriteLine(new string('-', 100));
            }
        }
    }
}