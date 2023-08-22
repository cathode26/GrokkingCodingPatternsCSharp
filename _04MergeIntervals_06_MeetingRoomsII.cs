using System;
using System.Collections.Generic;

/*
 * Meeting Rooms II

    Statement
    We are given an input array of meeting time intervals, intervals, where each interval has a start time and an end time. 
    Your task is to find the minimum number of meeting rooms required to hold these meetings.

    An important thing to note here is that the specified end time for each meeting is exclusive.

    Constraints
    1 <= intervals.length <= 10 
    0 ≤ starti < endi ≤ 10^6 

    2,3,3, 5, 8,11
    4,8,9,11,15,20
   
    |
    2,3,3, 5, 8,11     2<4 Add a room       Since 2 is less than 4, we have this hypothetical interval 
    4,8,9,11,15,20     room = 1             this is also the earlyiest possible interval from [2,4]
    |                                       [2,4] may not be a pair so it is really [2,?] and [?,4]
                                            What we can say is we need a room

      |
    2,3,3, 5, 8,11     3<4 Add a room       [3,?] will overlap with [2,?]  because [2,?] either goes to [2,4] or [2,k+4]
    4,8,9,11,15,20     room = 2
    |

        |
    2,3,3, 5, 8,11     3<4 Add a room       [3,?] will overlap with both [3,?], and [2,?] 
    4,8,9,11,15,20     room = 3
    |

           |
    2,3,3, 5, 8,11     5>4                  since 5 comes after 4, it means that this meeting can happen after
    4,8,9,11,15,20     room = 3             [3,?], [3,?], [2,?]
    |                                                            [5,?]      //but we dont know which room it will be in, but we can see it occurs after

              |
    2,3,3, 5, 8,11     8>=8                 [3,?], [3,?], [2,?]             //since 8 >= 8, we can reuse the room because begin 8 happens after end 8 
    4,8,9,11,15,20     room = 3                                 [5,?]  [8,?]
      |

                |
    2,3,3, 5, 8,11     11>=9                [3,?], [3,?], [2,?]                 //since 11 >= 9, 11 begin happens after end time 9 so you can reuse a room
    4,8,9,11,15,20     room = 3                                 [5,?]  [8,?] [11,?]
        |

                   |
    2,3,3, 5, 8,11     loop ends  
    4,8,9,11,15,20     room = 3
           |

                                            [2, 4]     [3, 9]   [3,8]
    2,3,3, 5, 8,11                          [5,20]         [8, 11]   
    4,8,9,11,15,20                                         [11,15]
 */

namespace EducativeGrokkingCodingPatterns
{
    public class _04MergeIntervals_06_MeetingRoomsII
    {
        //2 pointer solution
        /*
         * This algorithn sorts the begin times and the end time
         * They are sorted in increasing order
         * The algorithm compares the begin and the end, and if the begin occurs before the end it means you need a room
         * So increment the room count and increment the begin pointer, we dont increment the end pointer because we are 
         * looking to see if the next interval is going to allow us to reuse that room or need to add a new room
         * If the next room also has a begin time that is less than the end time, we know there is an overlap and we need a new room
         * If the next rooms begin time comes after or equal to the end time, it means we can reuse the room
         * Since we can reuse the room, it means we should increment both the begin and the end pointer because when you reuse the room, 
         * it gets a new end time.
         * */

        public static int GetMeetingRoomCount2Pointer(Interval[] intervals)
        {
            List<int> startTimes = new List<int>();
            List<int> endTimes = new List<int>();
            foreach (Interval interval in intervals)
            {
                startTimes.Add(interval.begin);
                endTimes.Add(interval.end);
            }

            startTimes.Sort();
            endTimes.Sort();

            int roomCount = 0;
            int endPtr = 0;
            for (int startPtr = 0; startPtr < startTimes.Count; startPtr++)
            {
                if (startTimes[startPtr] < endTimes[endPtr])
                {
                    roomCount++;
                }
                else
                {
                    endPtr++;
                }
            }
            return roomCount;
        }

        //priority_queue solution1, more complicated condition because of checking for when to enqueue 
        public static int GetMeetingRoomCount1(Interval[] intervals)
        {
            PriorityQueue<Interval, int> rooms = new PriorityQueue<Interval, int>();
            Array.Sort(intervals, (a,b) => {return a.begin.CompareTo(b.begin);});

            foreach (Interval interval in intervals)
            {
                Interval curInterval = rooms.Count > 0 ? rooms.Peek() : null ;
                if (rooms.Count == 0 || interval.end > curInterval.begin && interval.begin < curInterval.end)
                {
                    rooms.Enqueue(interval, interval.end);
                }
                else
                {
                    rooms.Dequeue();
                    rooms.Enqueue(interval, interval.end);
                }
            }
            return rooms.Count;
        }

        //priority_queue solution2, optimized solution so that it is checking for when to dequeu
        public static int GetMeetingRoomCount2(Interval[] intervals)
        {
            PriorityQueue<Interval, int> rooms = new PriorityQueue<Interval, int>();
            Array.Sort(intervals, (a, b) => { return a.begin.CompareTo(b.begin); });

            foreach (Interval interval in intervals)
            {
                Interval curInterval = rooms.Count > 0 ? rooms.Peek() : null;
                if (curInterval != null || interval.begin >= curInterval.end)
                    rooms.Dequeue();
                rooms.Enqueue(interval, interval.end);
            }
            return rooms.Count;
        }
        static public void Compute()
        {
            Interval[][] inputs = new Interval[][]
            {
                new Interval[]{ new Interval(2, 8), new Interval(3, 4), new Interval(3, 9), new Interval(5, 11), new Interval(8, 20), new Interval(11, 15) },
                new Interval[]{ new Interval(1, 3), new Interval(2, 6), new Interval(8, 10), new Interval(9, 15), new Interval(12, 14) },
                new Interval[]{ new Interval(1, 2), new Interval(4, 6), new Interval(3, 4), new Interval(7, 8) },
                new Interval[]{ new Interval(1, 7), new Interval(2, 6), new Interval(3, 7), new Interval(4, 8), new Interval(5, 8) },
                new Interval[]{ new Interval(1, 2), new Interval(1, 2), new Interval(1, 2) }
            };

            Console.WriteLine("Priority Queue");
            int i = 0;
            foreach (var meetingTimes in inputs)
            {
                Console.WriteLine(i + ".\tMeeting Times:");
                Console.WriteLine("\t\t" + string.Join<Interval>(", ", meetingTimes));
                Console.WriteLine("\tMeeting rooms needed: " + GetMeetingRoomCount1(meetingTimes));
                Console.WriteLine(new string('-', 100));
                i += 1;
            }

            Console.WriteLine("GetMeetingRoomCount2Pointer");
            i = 0;
            foreach (var meetingTimes in inputs)
            {
                Console.WriteLine(i + ".\tMeeting Times:");
                Console.WriteLine("\t\t" + string.Join<Interval>(", ", meetingTimes));
                Console.WriteLine("\tMeeting rooms needed: " + GetMeetingRoomCount2Pointer(meetingTimes));
                Console.WriteLine(new string('-', 100));
                i += 1;
            }
        }
    }
}
