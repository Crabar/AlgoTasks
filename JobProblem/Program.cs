using System;
using System.Collections.Generic;

namespace JobProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            var sol = new Solution();
            var res = sol.MaxProfitAssignment(new[] {68,35,52,47,86}, new[] {67,17,1,81,3}, new[] {92,10,85,84,82});
            Console.WriteLine(res);
        }
    }

    public class Solution
    {
        class Job
        {
            public int difficulty;
            public int profit;

            public Job(int difficulty, int profit)
            {
                this.difficulty = difficulty;
                this.profit = profit;
            }
        }

        public int MaxProfitAssignment(int[] difficulty, int[] profit, int[] worker)
        {
            var worksCount = profit.Length;

            var jobs = MergeSort(0, worksCount, difficulty, profit);
            var totalProfit = 0;

            for (var i = 0; i < worker.Length; i++)
            {
                // find job for each worker
                var start = 0;
                var end = jobs.Count;
                var center = start + (end - start) / 2;
                while (true)
                {
                    if (jobs[center].difficulty == worker[i])
                    {
                        totalProfit += jobs[center].profit;
                        break;
                    }

                    if (jobs[center].difficulty < worker[i])
                    {
                        if (start == center)
                        {
                            totalProfit += jobs[center].profit;
                            break;
                        }
                        start = center;
                        center = start + (end - start) / 2;
                        continue;
                    }

                    if (jobs[center].difficulty > worker[i])
                    {
                        if (end == center)
                        {
                            break;
                        }
                        end = center;
                        center = start + (end - start) / 2;
                    }
                }
            }

            return totalProfit;
        }

        private void AddJobToList(Job job, List<Job> jobs)
        {
            if (jobs.Count == 0)
            {
                jobs.Add(job);
                return;
            }

            if (job.profit <= jobs[jobs.Count - 1].profit)
            {
                return;
            }
            
            if (job.difficulty == jobs[jobs.Count - 1].difficulty)
            {
                jobs[jobs.Count - 1] = job;
            }
            else
            {
                jobs.Add(job);
            }
        }

        private List<Job> MergeSort(int start, int end, int[] difficulty, int[] profit)
        {
            var jobsCount = end - start;
            List<Job> sortedArray1;
            List<Job> sortedArray2;
            if (jobsCount > 1)
            {
                var newStart = (int) jobsCount / 2;
                sortedArray1 = MergeSort(start, start + newStart, difficulty, profit);
                sortedArray2 = MergeSort(start + newStart, end, difficulty, profit);
            }
            else
            {
                return new List<Job>() {new Job(difficulty[start], profit[start])};
            }

            var i = 0;
            var j = 0;
            var res = new List<Job>();
            while (i < sortedArray1.Count || j < sortedArray2.Count)
            {
                if (i == sortedArray1.Count)
                {
                    AddJobToList(sortedArray2[j], res);
                    j++;
                    continue;
                }

                if (j == sortedArray2.Count)
                {
                    AddJobToList(sortedArray1[i], res);
                    i++;
                    continue;
                }
                
                if (sortedArray1[i].difficulty <= sortedArray2[j].difficulty)
                {
                    AddJobToList(sortedArray1[i], res);
                    i++;
                    continue;
                }

                if (sortedArray2[j].difficulty <= sortedArray1[i].difficulty)
                {
                    AddJobToList(sortedArray2[j], res);
                    j++;
                    continue;
                }
            }

            return res;
        }
    }
}