using System;

namespace HackerRank
{
    class Program
    {
        static void Main(string[] args)
        {
            var ep = new EqualProblem();
            var res = ep.Equal(new[]
            {
                512, 125, 928, 381, 890, 90, 512, 789, 469, 473, 908, 990, 195, 763, 102, 643, 458, 366, 684, 857, 126, 534, 974, 875, 459, 892, 686, 373, 127, 297, 576, 991, 774, 856, 372, 664, 946, 237, 806, 767, 62, 714, 758, 258, 477, 860, 253, 287, 579, 289, 496
            });
            
            Console.WriteLine(res);
//            var kangaroo = new KangarooProblem();
//            Console.WriteLine(kangaroo.Kangaroo(112, 9563, 8625, 244));
//            var etp = new EvenTreeProblem();
//            Console.WriteLine(etp.CountRemovedEdges());

//            var ccp = new CoinsChangeProblem();
//            var curTime = DateTime.Now.Ticks;
//            var res = ccp.CountWays(new[] {1, 2, 3, 5}, 4, 100);
//            Console.WriteLine(res);
//            Console.WriteLine(DateTime.Now.Ticks - curTime);
//            var sorted = BigSort(new[] {"123", "23", "321", "10", "99999", "99999", "10", "6", "124379346764375643867", "444", "1", "1"});
//            Console.WriteLine("[{0}]", string.Join(", ", sorted));
        }

        static bool IsSmaller(string int1, string int2)
        {
            if (int1.Length < int2.Length)
            {
                return true;
            }

            if (int1.Length > int2.Length)
            {
                return false;
            }

            for (var i = 0; i < int1.Length; i++)
            {
                if (int1[i] < int2[i])
                {
                    return true;
                }

                if (int1[i] > int2[i])
                {
                    return false;
                }
            }

            return false;
        }

        static string[] BigSort(string[] unsorted)
        {
            if (unsorted.Length == 1)
            {
                return unsorted;
            }

            var middle = (int) Math.Floor((double) (unsorted.Length / 2));
            string[] leftSorted = new string[middle], rightSorted = new string[unsorted.Length - middle];
            Array.Copy(unsorted, 0, leftSorted, 0, middle);
            Array.Copy(unsorted, middle, rightSorted, 0, unsorted.Length - middle);

            leftSorted = BigSort(leftSorted);
            rightSorted = BigSort(rightSorted);

            var res = new string[unsorted.Length];

            for (int l = 0, r = 0, i = 0; l < leftSorted.Length || r < rightSorted.Length;)
            {
                if (l == leftSorted.Length)
                {
                    for (; r < rightSorted.Length; r++, i++)
                    {
                        res[i] = rightSorted[r];
                    }

                    break;
                }

                if (r == rightSorted.Length)
                {
                    for (; l < leftSorted.Length; l++, i++)
                    {
                        res[i] = leftSorted[l];
                    }

                    break;
                }

                if (IsSmaller(leftSorted[l], rightSorted[r]))
                {
                    res[i] = leftSorted[l];
                    l++;
                    i++;
                }
                else
                {
                    res[i] = rightSorted[r];
                    r++;
                    i++;
                }
            }

            return res;
        }
    }
}