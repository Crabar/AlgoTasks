using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace GroupAnagrams
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<Solution>();
        }
    }

    public class Solution
    {
        [Benchmark]
        public void TestSolution()
        {
            new Solution().GroupAnagrams(new[]
            {
                "eat", "tea", "tan", "ate", "nat", "bat",
                "eat", "tea", "tan", "ate", "nat", "bat",
                "eatf", "ftea", "ftan", "fate", "fnat", "fbat",
                "a", "b", "ccc", "ddddd", "ewrwfw", "werfds"
            });
        }

        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            var stringMap = new Dictionary<int, int>();
            var stringList = new List<IList<string>>();
            int offset = 'a';
            var primes = new byte[]
                {2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97, 101};
            
            foreach (var str in strs)
            {
                var hashcode = 1;
                foreach (var c in str)
                {
                    hashcode = primes[c - offset];
                }
               
                if (stringMap.ContainsKey(hashcode))
                {
                    stringList[stringMap[hashcode]].Add(str);
                }
                else
                {
                    stringMap.Add(hashcode, stringList.Count);
                    stringList.Add(new List<string> { str });
                }
            }

            return stringList;
        }

        private int GetCode(int[] value)
        {
            int result = 17;
            for (int i = 0; i < value.Length; i++)
            {
                unchecked
                {
                    result = result * 31 + value[i];
                }
            }
            return result;
        }
    }
}