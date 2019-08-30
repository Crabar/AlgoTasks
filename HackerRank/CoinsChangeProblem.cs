using System.Collections.Generic;
using System.Reflection;

namespace HackerRank
{
    public class CoinsChangeProblem
    {
        public long CountWays(int []S, int m, int n)
        {
            //Time complexity of this function: O(mn)
            //Space Complexity of this function: O(n)
 
            // table[i] will be storing the number of solutions
            // for value i. We need n+1 rows as the table is
            // constructed in bottom up manner using the base
            // case (n = 0)
            int[] table = new int[n+1];
 
            // Initialize all table values as 0
            for(int i = 0; i < table.Length; i++) 
            {
                table[i] = 0;
            }
 
            // Base case (If given value is 0)
            table[0] = 1;
 
            // Pick all coins one by one and update the table[]
            // values after the index greater than or equal to
            // the value of the picked coin
            for (int i = 0; i < m; i++)
            for (int j = S[i]; j <= n; j++)
                table[j] += table[j - S[i]];
 
            return table[n];
        }

        private Dictionary<(int,int), long> _cacheTable = new Dictionary<(int, int), long>();
        
        public long CountWays2(int[] S, int m, int n)
        {
            if (_cacheTable.ContainsKey((m, n)))
            {
                return _cacheTable[(m, n)];
            }
            // If n is 0 then there is 1 solution 
            // (do not include any coin)
            if (n == 0)
                return 1;
         
            // If n is less than 0 then no 
            // solution exists
            if (n < 0)
                return 0;
     
            // If there are no coins and n 
            // is greater than 0, then no
            // solution exist
            if (m <=0 && n >= 1)
                return 0;
     
            // count is sum of solutions (i) 
            // including S[m-1] (ii) excluding S[m-1]
            var count1 = CountWays2(S, m - 1, n);
            var count2 = CountWays2(S, m, n - S[m - 1]);
            _cacheTable[(m - 1, n)] = count1;
            _cacheTable[(m, n - S[m - 1])] = count2;
            return count1 + count2;
        }
    }
}