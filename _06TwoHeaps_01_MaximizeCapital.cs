using System;
using System.Collections.Generic;

namespace EducativeGrokkingCodingPatterns
{
    /*
     *  Maximize Capital
        Statement
        A busy investor with an initial capital, c, needs an automated investment program. 
        They can select k distinct projects from a list of n projects with corresponding capitals requirements and expected profits. 
        For a given project i, its capital requirement is capitals[i], and the profit it yields is 
        profits[i].

        The goal is to maximize their cumulative capital by selecting a maximum of k distinct projects to invest in, 
        subject to the constraint that the investor’s current capital must be greater than or equal to the capital 
        requirement of all selected projects.

        When a selected project from the identified ones is finished, the pure profit from the project, along with the starting 
        capital of that project is returned to the investor. This amount will be added to the total capital held by the investor. 
        Now, the investor can invest in more projects with the new total capital. It is important to note that each project can 
        only be invested once.

        As a basic risk-mitigation measure, the investor wants to limit the number of projects they invest in. For example, if k is 
        2, the program should identify the two projects that maximize the investor’s profits while ensuring that the investor’s 
        capital is sufficient to invest in the projects.

        Overall, the program should help the investor to make informed investment decisions by picking a list of a maximum of 
        k distinct projects to maximize the final profit while mitigating the risk.
    */

    internal class _06TwoHeaps_01_MaximizeCapital
    {
        static public int MaximumCapital(int initialCapital, int projects, int[] projectCapitals, int[] projectProfits)
        {
            PriorityQueue<(int index, int capital), int> minimumCapital = new PriorityQueue<(int index, int capital), int>();
            PriorityQueue<int, int> maximumProfit = new PriorityQueue<int, int>(Comparer<int>.Create((a,b)=>b.CompareTo(a)));

            for (int i = 0; i < projectCapitals.Length; ++i)
                minimumCapital.Enqueue((i, projectCapitals[i]),  projectCapitals[i]);

            for (int i = 0; i < projects; ++i)
            {
                while (minimumCapital.Count > 0 && minimumCapital.Peek().Item2 <= initialCapital)
                {
                    (int index, int capital) indexCapitalPair = minimumCapital.Dequeue();
                    maximumProfit.Enqueue(projectProfits[indexCapitalPair.index], projectProfits[indexCapitalPair.index] + indexCapitalPair.capital);
                }
                if (maximumProfit.Count > 0)
                    initialCapital += maximumProfit.Dequeue();
                else
                    break;
            }

            return initialCapital;
        }
        static public void Compute()
        {
            int[][][] input = new int[][][]
            {
                new int[][] { new int[] { 0}, new int[] { 1}, new int[] { 1, 1, 2}, new int[] { 1 ,2, 3}},
                new int[][] { new int[] { 1}, new int[] { 2}, new int[] { 1, 2, 2, 3}, new int[] { 2, 4, 6, 8}},
                new int[][] { new int[] { 2}, new int[] { 3}, new int[] { 1, 3, 4, 5, 6}, new int[] { 1, 2, 3, 4, 5}},
                new int[][] { new int[] { 1}, new int[] { 3}, new int[] { 1, 2, 3, 4}, new int[] { 1, 3, 5, 7}},
                new int[][] { new int[] { 7}, new int[] { 2}, new int[] { 2, 7, 8, 10}, new int[] { 4, 8, 12, 14}},
                new int[][] { new int[] { 2}, new int[] { 4}, new int[] { 2, 3, 5, 6, 8, 12}, new int[] { 1, 2, 5, 6, 8, 9}}
            };
            int num = 1;
            foreach (int[][] i in input)
            {
                Console.WriteLine( num + "." + "\tProject capital requirements:  " + String.Join(", ", i[2]));
                Console.WriteLine("\tProject expected profits:      " + String.Join(", ", i[3]));
                Console.WriteLine("\tNumber of projects:            " + i[1][0]);
                Console.WriteLine("\tStart-up capital:              " + i[0][0]);
                int result = MaximumCapital(i[0][0], i[1][0], i[2], i[3]);
                Console.WriteLine("\n\tMaximum capital earned: " + result );
                Console.WriteLine(new string('-', 100));
                num++;
            }
        }
    }
}
