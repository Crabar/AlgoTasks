using System;

namespace HackerRank
{
    public class KangarooProblem
    {
        public string Kangaroo(int x1, int v1, int x2, int v2) {
            if (v1 == v2)
            {
                return x1 == x2 ? "YES" : "NO";
            }
            var res = (double) (x2 - x1) / (v1 - v2);
            return res >= 0 && Math.Abs(res % 1) <= double.Epsilon * 100 ? "YES" : "NO";
        }
    }
}