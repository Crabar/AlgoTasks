using System;
using System.Collections;

namespace PrisonCells
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new Solution().PrisonAfterNDays(new []{1,0,0,1,0,0,1,0}, 1000000000));
        }
        
        public class Solution {
            public int[] PrisonAfterNDays(int[] cells, int N)
            {
                byte cellByte = 0;

                for (var i = 0; i < 8; i++)
                {
                    cellByte = (byte) (cellByte | (cells[7 - i] << i));
                }

                N = N % 256;
                
                for (var j = 0; j < N; j++)
                {
                    byte leftShift =  (byte) ~ (cellByte ^ (cellByte << 2));
                    byte rightShift = (byte) ~ (cellByte ^ (cellByte >> 2));
                    leftShift = (byte) ((leftShift & 124) >> 2);
                    rightShift = (byte) (rightShift & 62);
                    cellByte = (byte) ((leftShift | rightShift) << 1);
                }

                var res = new int[8];
                for (var i = 0; i < 8; i++)
                {
                    res[i] = (cellByte & (1 << (7 - i))) >> (7 - i);
                }

                return res;
            }
        }
    }
}