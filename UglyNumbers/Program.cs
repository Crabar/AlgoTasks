using System;
using System.Reflection.Metadata;

namespace UglyNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new Solution().Run(10));
        }

        class Solution
        {
            public int Run(int n)
            {
                var numbs = new int[n + 1];
                numbs[0] = 1;
                int i2 = 0, i3 = 0, i5 = 0;
                var next2 = 2;
                var next3 = 3;
                var next5 = 5;
                var i = 1;

                while (i < n)
                {
                    numbs[i] = Math.Min(Math.Min(next2, next3), next5);

                    if (numbs[i] == next2)
                    {
                        i2++;
                        next2 = numbs[i2] * 2;
                    } 
                    if (numbs[i] == next3)
                    {
                        i3++;
                        next3 = numbs[i3] * 3;
                    }
                    if (numbs[i] == next5)
                    {
                        i5++;
                        next5 = numbs[i5] * 5;
                    }

                    i++;
                }

                return numbs[n - 1];
            }
        }
    }
}