using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//["0201","0101","0102","1212","2002"]
//"0202"

//s.OpenLock(new [] {"1131","1303","3113","0132","1301","1303","2200","0232","0020","2223"}, "3312");
namespace Lock
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var s = new Solution();
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var res = s.OpenLock(new [] {"0201","0101","0102","1212","2002"}, "0202");
            watch.Stop();
            Console.WriteLine($"Result: {res}, ElapsedMs: {watch.ElapsedMilliseconds}");
        }

        public class Solution
        {
            class Node
            {
                public int Id;
                public Node Parent;
                public byte DistanceToTarget;
                public int Cost;

                public int F
                {
                    get
                    {
                        if (DistanceToTarget != -1 && Cost != -1)
                            return DistanceToTarget + Cost;
                        return -1;
                    }
                }
            }

            private int[] GetDigits(int value, int digitsCount = 4)
            {
                var curNum = value;
                var res = new int[digitsCount];
                for (int i = digitsCount - 1; i > 0; i--)
                {
                    res[digitsCount - i - 1] = curNum / (int)Math.Pow(10, i);
                    curNum = curNum % (int)Math.Pow(10, i);
                }

                res[digitsCount - 1] = curNum;

                return res;
            }

            private byte GetDistance(int fromN, int toN)
            {
                var totalDist = 0;
                var digits1 = GetDigits(fromN);
                var digits2 = GetDigits(toN);
                for (var i = 0; i < 4; i++)
                {
                    var minN = Math.Min(digits1[i], digits2[i]);
                    var maxN = Math.Max(digits1[i], digits2[i]);

                    totalDist += Math.Min(maxN - minN, minN + 10 - maxN);
                }

                return (byte)totalDist;
            }

            private int SearchPath(int start, int target, string[] deadends)
            {
                var closedList = new HashSet<int>();
                foreach (var deadend in deadends)
                {
                    closedList.Add(int.Parse(deadend));
                }
                
                if (closedList.Contains(start) || closedList.Contains(target))
                {
                    return -1;
                }
               
                var openList = new SortedDictionary<double, Node>();
                var openListSet = new HashSet<int>();
                var random = new Random();
                
                openList.Add(0, new Node { Id = start } );
                openListSet.Add(start);
                
                Node current = openList.First().Value;

                while (openList.Count != 0 && !closedList.Contains(target))
                {
                    var elem = openList.First();
                    current = elem.Value;
                    openList.Remove(elem.Key);
                    openListSet.Remove(elem.Value.Id);
                    closedList.Add(current.Id);

                    var neighbors = GetNeighbors(current.Id);
                    foreach (var n in neighbors)
                    {
                        var node = new Node { Id = n };

                        if (closedList.Contains(n) || openListSet.Contains(n))
                        {
                            continue;
                        }

                        node.Parent = current;
                        node.DistanceToTarget = GetDistance(n, target);
                        node.Cost = 1 + node.Parent.Cost;
                        openList.Add(node.F + random.NextDouble(), node);
                        openListSet.Add(n);
                    }
                }

                // construct path, if end was not closed return null
                if (!closedList.Contains(target))
                {
                    return -1;
                }

                return current.Cost;
            }

            private int[] GetNeighbors(int id)
            {
                var res = new int[8];
                var digits = GetDigits(id);
                
                for (var i = 0; i < 4; i++)
                {
                    int n1 = digits[i] == 0 ? 9 : digits[i] - 1;
                    int n2 = digits[i] == 9 ? 0 : digits[i] + 1;

                    int num1 = 0;
                    int num2 = 0;
                    for (var j = 3; j >= 0; j--)
                    {
                        if (3 - j == i)
                        {
                            num1 += n1 * (int)Math.Pow(10, j);
                            num2 += n2 * (int)Math.Pow(10, j);
                        }
                        else
                        {
                            num1 += digits[3 - j] * (int)Math.Pow(10, j);
                            num2 += digits[3 - j] * (int)Math.Pow(10, j);
                        }
                    }
                    
                    res[i * 2] = num1;
                    res[i * 2 + 1] = num2;
                }

                return res;
            }

            public int OpenLock(string[] deadends, string target)
            {
                var targetId = int.Parse(target);
               
//                var watch = System.Diagnostics.Stopwatch.StartNew();
                var r = SearchPath(0, targetId, deadends);
//                watch.Stop();
//                Console.WriteLine($"Search takes {watch.ElapsedMilliseconds} ms");
                return r;
            }
        }
    }
}