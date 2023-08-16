using System;
using System.Collections.Generic;

namespace EducativeGrokkingCodingPatterns
{
    /*
     * Insert Interval
        Given a sorted list of nonoverlapping intervals and a new interval, your task is to insert the new interval into the 
        correct position while ensuring that the resulting list of intervals remains sorted and nonoverlapping. 
        Each interval is a pair of nonnegative numbers, the first being the start time and the second being the end time of the interval.

    Constraints:

         0 ≤ existing_intervals.length ≤10^4
         existing_intervals[i].length, new_interval.length == 2
         0 ≤ start time, end time ≤ 10^4
        
         The first number should always be less than the second number in each interval.
         The list of intervals is sorted in ascending order based on the first element in every interval.
    */

    public class _04MergeIntervals_02_InsertInterval
    {
        public static Interval[] InsertInterval(Interval[] intervals, Interval newInterval)
        {
            if (intervals.Length == 0)
            {
                return new Interval[] { newInterval };
            }

            //sort
            Array.Sort(intervals, (intervalA, IntervalB) => { return intervalA.begin.CompareTo(IntervalB.begin); });
            
            bool insertedInterval = false;
            List<Interval> newIntervals = new List<Interval>();
            for (int i = 0; i < intervals.Length; ++i)
            {
                if (newInterval.end < intervals[i].begin)    //the new interval is completely before this interval
                {
                    if (insertedInterval == false)
                    {
                        newIntervals.Add(newInterval);
                        insertedInterval = true;
                    }
                    newIntervals.Add(intervals[i]);
                }
                else if (newInterval.begin > intervals[i].end)
                {
                    newIntervals.Add(intervals[i]);
                }
                else  //they intersect, so merge the interval into the new interval
                {
                    newInterval.begin = Math.Min(newInterval.begin, intervals[i].begin);
                    newInterval.end = Math.Max(newInterval.end, intervals[i].end);
                }
            }

            if (insertedInterval == false)
                newIntervals.Add(newInterval);

            return newIntervals.ToArray();
        }

        public static void Compute()
        {
            Interval[] newIntervals = { new Interval(5, 7), new Interval(8, 9), new Interval(10, 12), new Interval(1, 3), new Interval(1, 10) };
            Interval[][] existingIntervals = {
                new Interval[] {new Interval(1, 2), new Interval(3, 5), new Interval(6, 8) },
                new Interval[] {new Interval(1, 3), new Interval(5, 7), new Interval(10, 12)},
                new Interval[] {new Interval(8, 10), new Interval(12, 15)},
                new Interval[] {new Interval(5, 7), new Interval(8, 9)},
                new Interval[] {new Interval(3, 5) }
            };

            for (int i = 0; i < newIntervals.Length; i++)
            {
                Console.WriteLine((i + 1) + ".\tExisting intervals: [" + string.Join<Interval>(", ", existingIntervals[i]) + "]");
                Console.WriteLine("\tNew interval: [" + newIntervals[i].begin + ", " + newIntervals[i].end + "]");
                Interval[] output = InsertInterval(existingIntervals[i], newIntervals[i]);
                Console.WriteLine("\tUpdated intervals: " + string.Join<Interval>(", ", output));
                Console.WriteLine(new string('-', 100));
            }
        }
    }
}
