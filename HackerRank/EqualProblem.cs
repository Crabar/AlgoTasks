using System.Linq;

namespace HackerRank
{
    public class EqualProblem
    {
        private static int EqualTo(int minVal, int[] arr)
        {
            var opsCount = 0;
            for (var i = 0; i < arr.Length; i++)
            {
                var diff = arr[i] - minVal;
                opsCount += diff / 5;
                diff = diff % 5;
                opsCount += diff / 2 + diff % 2;
            }
            return opsCount;
        }
    
        public int Equal(int[] arr) {
            var minVal = arr.Min();
            var results = new int[5];
            var extraCost = 0;
            for (var i = 0; i < 5; i++)
            {        
                results[i] = EqualTo(minVal - i, arr) + extraCost;
            }
            return results.Min();
        }
    }
}