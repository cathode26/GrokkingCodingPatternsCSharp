using System;
using System.Collections.Generic;
using System.Linq;

namespace EducativeGrokkingCodingPatterns
{
    /*
     * 
     * You’re given a list containing the schedules of multiple employees. 
     * Each person’s schedule is a list of non-overlapping intervals in sorted order. 
     * An interval is specified with the start and end time, both being positive integers. 
     * Your task is to find the list of intervals representing the free time for all the employees.

        Constraints:

            1 ≤ schedule.length , schedule[i].length ≤ 50
            0 ≤ interval.start < interval.end ≤10 ^8

        where interval is any interval in the list of schedules.
    */

    public class _04MergeIntervals_04_EmployeeFreeTime
    {
        public static Interval[] EmployeeFreeTime(Interval[][] schedule)
        {
            Interval[] mergedIntervals = new Interval[] { new Interval(0, 1), new Interval(50, 51) };

            for (int i = 0; i < schedule.Length; ++i)
                mergedIntervals = mergedIntervals.Concat(schedule[i]).ToArray();

            Array.Sort(mergedIntervals , (a, b) => a.begin.CompareTo(b.begin));

            List<Interval> unionedIntervals = new List<Interval>();
            Interval current = new Interval(mergedIntervals[0].begin, mergedIntervals[0].end);
            unionedIntervals.Add(current);

            for (int i = 1; i < mergedIntervals.Length; ++i)
            {
                if (current.end < mergedIntervals[i].begin)
                {
                    current = new Interval(mergedIntervals[i].begin, mergedIntervals[i].end);
                    unionedIntervals.Add(current);
                }
                else //they overlap so merge them
                {
                    current.begin = Math.Min(current.begin, mergedIntervals[i].begin);
                    current.end = Math.Max(current.end, mergedIntervals[i].end);
                }
            }
            //lets see if they are unioned properly
            //return unionedIntervals.ToArray();

            //Now look for free time between each interval
            List<Interval> freeIntervals = new List<Interval>();
            for (int i = 0; i < unionedIntervals.Count-1; ++i)
                freeIntervals.Add(new Interval(unionedIntervals[i].end, unionedIntervals[i + 1].begin));
            
            return freeIntervals.ToArray();
        }
        public static void Compute()
        {
            Interval[][][] inputs = new Interval[][][]
            {
                new Interval[][]{ new Interval[] { new Interval(1, 2), new Interval(5, 6)}, new Interval[] {new Interval(1, 3)}, new Interval[] { new Interval(4, 10)}},
                new Interval[][]{ new Interval[] { new Interval(1, 3), new Interval(6, 7)}, new Interval[] { new Interval(2, 4)}, new Interval[] { new Interval(2, 5), new Interval(9, 12)}},
                new Interval[][]{ new Interval[] { new Interval(2, 3), new Interval(7, 9)}, new Interval[] { new Interval(1, 4), new Interval(6, 7)}},
                new Interval[][]{ new Interval[] { new Interval(3, 5), new Interval(8, 10)}, new Interval[] { new Interval(4, 6), new Interval(9, 12)}, new Interval[] { new Interval(5, 6), new Interval(8, 10)}},
                new Interval[][]{ new Interval[] { new Interval(1, 3), new Interval(6, 9), new Interval(10, 11)}, new Interval[] { new Interval(3, 4), new Interval(7, 12)}, new Interval[] { new Interval(1, 3), new Interval(7, 10)}, new Interval[] { new Interval(1, 4)}, new Interval[] { new Interval(7, 10), new Interval(11, 12)}},
                new Interval[][]{ new Interval[] { new Interval(1, 2), new Interval(3, 4), new Interval(5, 6), new Interval(7, 8)}, new Interval[] { new Interval(2, 3), new Interval(4, 5), new Interval(6, 8)}},
                new Interval[][]{ new Interval[] { new Interval(1, 2), new Interval(3, 4), new Interval(5, 6), new Interval(7, 8), new Interval(9, 10), new Interval(11, 12)}, new Interval[] { new Interval(1, 2), new Interval(3, 4), new Interval(5, 6), new Interval(7, 8), new Interval(9, 10), new Interval(11, 12)}, new Interval[] { new Interval(1, 2), new Interval(3, 4), new Interval(5, 6), new Interval(7, 8), new Interval(9, 10), new Interval(11, 12)}, new Interval[] { new Interval(1, 2), new Interval(3, 4), new Interval(5, 6), new Interval(7, 8), new Interval(9, 10), new Interval(11, 12)}}
            };
            int i = 1;
            foreach (var schedule in inputs)
            {
                Console.WriteLine( i + ".\tEmployee Schedules:");
                foreach (var s in schedule)
                    Console.WriteLine( "\t\t" + string.Join<Interval>(", ", s) );
                Interval[]  freeTime = EmployeeFreeTime(schedule);
                Console.WriteLine("\tEmployees' free time: " + string.Join<Interval>(", ", freeTime));
                Console.WriteLine(new string('-', 100));
                i += 1;
            }
        }
    }
}
