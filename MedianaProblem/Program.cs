using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace MedianaProblem
{
    [MemoryDiagnoser]
    public class Solution
    {
        [Benchmark]
        public void RunProgram()
        {
            var _arr1 = new [] {2, 4, 5, 6};
            var _arr2 = new[] {1, 3};

            FindMedianSortedArrays(_arr1, _arr2);
        }

        [Benchmark]
        public void RunProgramOld()
        {
            var _arr1 = new [] {2, 4, 5, 6};
            var _arr2 = new[] {1, 3};

            FindMedianSortedArrays_(_arr1, _arr2);
        }
        
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            double res;
            var len1 = nums1.Length;
            var len2 = nums2.Length;

            if (len1 == 0)
            {
                int medianIndex = (int) Math.Ceiling((decimal) len2 / 2) - 1;
                res = len2 % 2 == 0 ? ((double) nums2[medianIndex] + nums2[medianIndex + 1]) / 2 : nums2[medianIndex];
                return res;
            }

            if (len2 == 0)
            {
                int medianIndex = (int) Math.Ceiling((decimal) len1 / 2) - 1;
                res = len1 % 2 == 0 ? ((double) nums1[medianIndex] + nums1[medianIndex + 1]) / 2 : nums1[medianIndex];
                return res;
            }

            var isIntersected = !(nums1[len1 - 1] < nums2[0] || nums2[len2 - 1] < nums1[0]);
            res = isIntersected ? FindMedianCase2(nums1, nums2) : FindMedianCase1(nums1, nums2);

            return res;
        }


        private double FindMedianCase1(int[] nums1, int[] nums2)
        {
            double res;

            var firstArr = nums1;
            var secondArr = nums2;

            if (nums2[nums2.Length - 1] < nums1[0])
            {
                firstArr = nums2;
                secondArr = nums1;
            }

            var totalLen = firstArr.Length + secondArr.Length;
            int medianIndex = (int) Math.Ceiling((decimal) totalLen / 2) - 1;

            if (totalLen % 2 != 0)
            {
                res = medianIndex < firstArr.Length ? firstArr[medianIndex] : secondArr[medianIndex - firstArr.Length];
            }
            else
            {
                if (medianIndex == firstArr.Length - 1)
                {
                    res = ((double) firstArr[medianIndex] + secondArr[0]) / 2;
                }
                else
                {
                    res = medianIndex < firstArr.Length
                        ? ((double) firstArr[medianIndex] + firstArr[medianIndex + 1]) / 2
                        : ((double) secondArr[medianIndex - firstArr.Length] +
                           secondArr[medianIndex - firstArr.Length + 1]) / 2;
                }
            }

            return res;
        }

        private bool FindMedianInArray(int[] first,
            int[] second,
            int neededLeftElems,
            int neededRightElems,
            out double res)
        {
            var startIndex = Math.Max(0, neededLeftElems - second.Length);
            var finishIndex = first.Length - Math.Max(0, neededRightElems - second.Length) - 1;

            while (true)
            {
                var curIndex = (startIndex + finishIndex) / 2;
                double curMedian = first[curIndex];

                var leftIndex = neededLeftElems - curIndex - 1;
                var rightIndex = leftIndex + 1;

                if (leftIndex >= 0)
                {
                    var leftElem = second[leftIndex];
                    if (leftElem > curMedian)
                    {
                        startIndex = curIndex + 1;
                        if (startIndex > finishIndex)
                        {
                            curMedian = leftElem;
                        }
                        else
                        {
                            continue;
                        }
                    }
                }

                if (rightIndex < second.Length)
                {
                    var rightElem = second[rightIndex];
                    if (rightElem < curMedian)
                    {
                        finishIndex = curIndex - 1;
                        if (startIndex > finishIndex)
                        {
                            curMedian = rightElem;
                            curIndex -= 1;
                            rightIndex += 1;
                        }
                        else
                        {
                            continue;
                        }
                    }
                }

                if (neededLeftElems != neededRightElems)
                {
                    var val1 = first.Length > curIndex + 1 ? first[curIndex + 1] : Int32.MaxValue;
                    var val2 = rightIndex < second.Length ? second[rightIndex] : Int32.MaxValue;
                    curMedian = (curMedian + Math.Min(val1, val2)) / 2;
                }

                res = curMedian;
                return true;
            }
        }

        private double FindMedianCase2(int[] nums1, int[] nums2)
        {
            double res;
            int neededLeftElems = (int) (Math.Ceiling((decimal) (nums1.Length + nums2.Length) / 2) - 1);
            int neededRightElems = (nums1.Length + nums2.Length) / 2;

            FindMedianInArray(nums1, nums2, neededLeftElems, neededRightElems, out res);

            return res;
        }
        
        
        public double FindMedianSortedArrays_(int[] nums1, int[] nums2)
        {
            double res;
            var len1 = nums1.Length;
            var len2 = nums2.Length;

            if (len1 == 0)
            {
                int medianIndex = (int) Math.Ceiling((decimal) len2 / 2) - 1;
                res = len2 % 2 == 0 ? ((double) nums2[medianIndex] + nums2[medianIndex + 1]) / 2 : nums2[medianIndex];
                return res;
            }

            if (len2 == 0)
            {
                int medianIndex = (int) Math.Ceiling((decimal) len1 / 2) - 1;
                res = len1 % 2 == 0 ? ((double) nums1[medianIndex] + nums1[medianIndex + 1]) / 2 : nums1[medianIndex];
                return res;
            }

            var isIntersected = !(nums1[len1 - 1] < nums2[0] || nums2[len2 - 1] < nums1[0]);

            if (!isIntersected)
            {
                res = FindMedianCase1_(nums1, nums2);
            }
            else
            {
                res = FindMedianCase2_(nums1, nums2);
            }

            return res;
        }


        private double FindMedianCase1_(int[] nums1, int[] nums2)
        {
            double res;

            var firstArr = nums1;
            var secondArr = nums2;

            if (nums2[nums2.Length - 1] < nums1[0])
            {
                firstArr = nums2;
                secondArr = nums1;
            }

            var totalLen = firstArr.Length + secondArr.Length;
            int medianIndex = (int) Math.Ceiling((decimal) totalLen / 2) - 1;

            if (totalLen % 2 != 0)
            {
                res = medianIndex < firstArr.Length ? firstArr[medianIndex] : secondArr[medianIndex - firstArr.Length];
            }
            else
            {
                if (medianIndex == firstArr.Length - 1)
                {
                    res = ((double) firstArr[medianIndex] + secondArr[0]) / 2;
                }
                else
                {
                    res = medianIndex < firstArr.Length
                        ? ((double) firstArr[medianIndex] + firstArr[medianIndex + 1]) / 2
                        : ((double) secondArr[medianIndex - firstArr.Length] +
                           secondArr[medianIndex - firstArr.Length + 1]) / 2;
                }
            }

            return res;
        }

        private bool FindMedianInArray_(int[] first,
            int[] second,
            int neededLeftElems,
            int neededRightElems,
            out double res)
        {
            var startIndex = Math.Max(0, neededLeftElems - second.Length);
            var finishIndex = first.Length - Math.Max(0, neededRightElems - second.Length) - 1;

            while (true)
            {
                if (startIndex > finishIndex)
                {
                    res = 0;
                    return false;
                }

                var curIndex = (startIndex + finishIndex) / 2;
                var leftElemCount = curIndex;
                double curMedian = first[curIndex];

                var leftIndex = neededLeftElems - leftElemCount - 1;
                var rightIndex = leftIndex + 1;

                if (leftIndex >= 0)
                {
                    var leftElem = second[leftIndex];
                    if (leftElem > curMedian)
                    {
                        startIndex = curIndex + 1;
                        continue;
                    }
                }

                if (rightIndex < second.Length)
                {
                    var rightElem = second[rightIndex];
                    if (rightElem < curMedian)
                    {
                        finishIndex = curIndex - 1;
                        continue;
                    }
                }

                if (neededLeftElems != neededRightElems)
                {
                    var val1 = first.Length > curIndex + 1 ? first[curIndex + 1] : Int32.MaxValue;
                    var val2 = rightIndex < second.Length ? second[rightIndex] : Int32.MaxValue;
                    curMedian = (curMedian + Math.Min(val1, val2)) / 2;
                }

                res = curMedian;
                return true;
            }
        }

        private double FindMedianCase2_(int[] nums1, int[] nums2)
        {
            double res;
            int neededLeftElems = (int) (Math.Ceiling((decimal) (nums1.Length + nums2.Length) / 2) - 1);
            int neededRightElems = (int) Math.Floor((decimal) (nums1.Length + nums2.Length) / 2);

            var firstAttempt = FindMedianInArray_(nums1, nums2, neededLeftElems, neededRightElems, out res);
            if (!firstAttempt)
            {
                var secondAttempt = FindMedianInArray_(nums2, nums1, neededLeftElems, neededRightElems, out res);
            }

            return res;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var _arr1 = new [] {2, 4, 5, 6};
            var _arr2 = new[] {1, 3};
            var sol = new Solution();
            Console.WriteLine($"Median is {sol.FindMedianSortedArrays(_arr1, _arr2)}");
            BenchmarkRunner.Run<Solution>();
        }
    }
}