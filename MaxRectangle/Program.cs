﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace MaxRectangle
{
    class Program
    {
        static void Main(string[] args)
        {
//            
            Console.WriteLine(new Solution().MaximalRectangle2(new[]
            {
                new[] {'1', '1', '1', '1', '1', '1', '1'},
                new[] {'1', '0', '1', '1', '1', '0', '0'},
                new[] {'1', '0', '1', '1', '1', '0', '0'}
            }));
            
            Console.WriteLine(new Solution().MaximalRectangle2(new[]
            {
                new[] {'1', '0', '1', '0', '0'},
                new[] {'1', '0', '1', '1', '1'},
                new[] {'1', '1', '1', '1', '1'},
                new[] {'1', '0', '0', '1', '0'}
            }));

            Console.WriteLine(new Solution().MaximalRectangle2(new[]
            {
                new[] {'1', '1', '1', '1', '1', '1', '1', '1'},
                new[] {'1', '1', '1', '1', '1', '1', '1', '0'},
                new[] {'1', '1', '1', '1', '1', '1', '1', '0'},
                new[] {'1', '1', '1', '1', '1', '0', '0', '0'},
                new[] {'0', '1', '1', '1', '1', '0', '0', '0'}
            }));

            Console.WriteLine(new Solution().MaximalRectangle2(new[]
            {
                new[] {'1', '1'},
                new[] {'1', '1'}
            }));

            Console.WriteLine(new Solution().MaximalRectangle2(new[]
            {
                new[] {'1'}
            }));

            Console.WriteLine(new Solution().MaximalRectangle2(new[]
            {
                new[]
                {
                    '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '0', '1', '0', '0', '1', '1',
                    '1', '1', '1', '1', '1', '1', '0', '0', '1', '1', '1', '0', '1', '1', '1', '1', '1', '1', '1', '1'
                },
                new[]
                {
                    '1', '1', '1', '1', '0', '1', '1', '0', '1', '1', '1', '1', '1', '1', '1', '1', '1', '0', '1', '1',
                    '0', '1', '1', '1', '1', '1', '0', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1'
                },
                new[]
                {
                    '0', '1', '1', '1', '1', '0', '1', '0', '1', '1', '1', '1', '1', '1', '0', '1', '1', '0', '1', '1',
                    '0', '1', '1', '0', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1'
                },
                new[]
                {
                    '0', '1', '0', '1', '1', '0', '1', '0', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1',
                    '0', '1', '1', '1', '1', '1', '1', '1', '0', '1', '0', '1', '1', '0', '1', '1', '1', '1', '1', '1'
                },
                new[]
                {
                    '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '0', '1', '1', '1', '1', '1', '0', '1',
                    '1', '0', '0', '1', '0', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1'
                },
                new[]
                {
                    '1', '1', '1', '1', '1', '1', '1', '1', '1', '0', '1', '1', '0', '1', '0', '1', '1', '1', '1', '1',
                    '1', '1', '1', '1', '1', '1', '0', '1', '0', '1', '1', '1', '1', '1', '1', '0', '1', '1', '1', '1'
                },
                new[]
                {
                    '0', '1', '1', '0', '1', '1', '0', '1', '0', '1', '1', '1', '0', '0', '1', '1', '1', '1', '1', '1',
                    '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '0', '1', '1', '1', '1', '1', '0', '1', '0', '1'
                },
                new[]
                {
                    '0', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '0', '0', '1', '1', '1', '1',
                    '1', '1', '1', '0', '0', '1', '1', '0', '0', '1', '1', '0', '1', '1', '0', '1', '0', '1', '0', '1'
                },
                new[]
                {
                    '1', '1', '1', '1', '0', '1', '1', '1', '1', '0', '1', '1', '1', '1', '1', '1', '1', '1', '1', '0',
                    '1', '1', '0', '1', '1', '0', '1', '1', '1', '1', '0', '1', '0', '1', '1', '0', '1', '0', '1', '1'
                },
                new[]
                {
                    '1', '1', '1', '1', '1', '1', '1', '1', '1', '0', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1',
                    '0', '1', '1', '0', '1', '1', '0', '1', '1', '1', '0', '1', '1', '1', '1', '0', '1', '1', '1', '1'
                },
                new[]
                {
                    '1', '1', '1', '0', '1', '1', '0', '0', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1',
                    '0', '0', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1'
                },
                new[]
                {
                    '1', '0', '1', '1', '1', '1', '1', '1', '1', '0', '1', '1', '1', '1', '0', '1', '1', '1', '1', '0',
                    '0', '1', '1', '1', '0', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1'
                },
                new[]
                {
                    '0', '1', '1', '0', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '0', '1', '1',
                    '1', '1', '1', '1', '0', '1', '1', '1', '0', '1', '1', '1', '1', '1', '0', '1', '1', '1', '1', '1'
                },
                new[]
                {
                    '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '0', '1', '1', '1',
                    '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '0', '1', '1', '1', '1', '1', '1', '0', '1', '1'
                },
                new[]
                {
                    '1', '1', '1', '1', '1', '0', '0', '1', '1', '1', '1', '1', '1', '1', '1', '0', '1', '0', '1', '1',
                    '0', '0', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '0', '1', '1', '1', '1'
                },
                new[]
                {
                    '1', '1', '1', '1', '1', '0', '1', '1', '1', '1', '1', '1', '1', '1', '1', '0', '1', '1', '1', '1',
                    '1', '1', '0', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '0', '1', '1', '1', '1', '1'
                },
                new[]
                {
                    '1', '1', '1', '1', '1', '0', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1',
                    '1', '1', '0', '1', '1', '0', '0', '1', '1', '1', '1', '1', '1', '0', '0', '1', '1', '1', '1', '1'
                },
                new[]
                {
                    '1', '1', '1', '1', '1', '1', '0', '1', '1', '1', '1', '1', '1', '1', '1', '1', '0', '1', '1', '1',
                    '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '0', '1', '1', '1', '1', '1', '0', '1', '1', '1'
                },
                new[]
                {
                    '1', '0', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '0', '1', '0', '1',
                    '1', '1', '1', '1', '0', '0', '1', '0', '1', '1', '1', '1', '1', '0', '1', '1', '1', '1', '1', '1'
                },
                new[]
                {
                    '1', '1', '1', '1', '1', '1', '0', '0', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1',
                    '1', '0', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '0', '1', '1'
                },
                new[]
                {
                    '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '0', '1',
                    '1', '1', '0', '1', '1', '1', '1', '1', '0', '1', '1', '1', '1', '1', '0', '1', '1', '0', '1', '1'
                },
                new[]
                {
                    '1', '1', '0', '0', '0', '1', '1', '0', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1',
                    '1', '1', '0', '1', '1', '1', '1', '1', '0', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1'
                },
                new[]
                {
                    '1', '1', '1', '1', '1', '0', '1', '0', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1',
                    '0', '1', '1', '0', '0', '1', '0', '1', '1', '1', '0', '0', '1', '1', '1', '1', '1', '1', '1', '1'
                },
                new[]
                {
                    '1', '1', '1', '0', '0', '1', '0', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '0',
                    '1', '1', '0', '1', '1', '1', '1', '0', '1', '1', '1', '1', '0', '1', '1', '1', '1', '1', '0', '1'
                },
                new[]
                {
                    '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '0', '1', '1', '0', '1', '1',
                    '1', '1', '1', '1', '1', '1', '1', '1', '1', '0', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1'
                },
                new[]
                {
                    '1', '1', '1', '1', '1', '1', '1', '0', '1', '1', '1', '1', '1', '1', '0', '1', '1', '1', '1', '0',
                    '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '0', '1', '1', '1', '1', '1', '1'
                },
                new[]
                {
                    '1', '1', '1', '0', '0', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '0', '1', '1', '1', '0',
                    '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '0', '1', '1', '1', '1', '1', '0', '1', '1', '1'
                },
                new[]
                {
                    '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '0', '0', '1', '1', '1', '1',
                    '1', '1', '0', '1', '0', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '0', '1', '1', '1'
                },
                new[]
                {
                    '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1',
                    '1', '1', '0', '0', '0', '1', '1', '1', '1', '1', '1', '1', '1', '1', '0', '1', '1', '1', '0', '1'
                },
                new[]
                {
                    '1', '1', '1', '1', '1', '1', '0', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1',
                    '1', '1', '1', '1', '1', '1', '0', '1', '1', '0', '0', '1', '1', '1', '0', '1', '1', '0', '1', '1'
                },
                new[]
                {
                    '1', '1', '1', '1', '0', '1', '1', '0', '1', '1', '1', '1', '1', '1', '0', '1', '1', '0', '1', '1',
                    '0', '1', '1', '1', '1', '1', '1', '0', '1', '1', '1', '1', '1', '1', '1', '0', '1', '1', '1', '1'
                },
                new[]
                {
                    '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '0', '1', '1', '1', '1', '1', '1', '1', '1', '1',
                    '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1'
                },
                new[]
                {
                    '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1',
                    '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1'
                },
                new[]
                {
                    '1', '1', '0', '0', '0', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '0', '1', '1', '1', '1',
                    '1', '1', '1', '1', '1', '1', '1', '1', '1', '0', '1', '1', '1', '1', '1', '1', '1', '0', '1', '1'
                },
                new[]
                {
                    '1', '1', '1', '1', '1', '0', '1', '1', '1', '1', '1', '1', '1', '1', '0', '1', '1', '1', '1', '0',
                    '1', '0', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1'
                },
                new[]
                {
                    '0', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '0', '0', '1', '1', '1', '1', '1', '1',
                    '1', '1', '1', '1', '0', '1', '0', '1', '0', '1', '1', '0', '1', '1', '1', '1', '1', '1', '1', '1'
                },
                new[]
                {
                    '1', '0', '1', '1', '0', '1', '1', '1', '1', '1', '1', '0', '1', '1', '1', '1', '1', '1', '1', '1',
                    '1', '1', '1', '0', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '0', '0', '1', '1'
                },
                new[]
                {
                    '1', '0', '1', '0', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1',
                    '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '0', '0', '1', '1', '1', '1', '1'
                },
                new[]
                {
                    '0', '1', '1', '1', '1', '0', '1', '1', '1', '1', '0', '1', '1', '1', '1', '1', '1', '1', '1', '1',
                    '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '0', '1', '1', '1', '1', '1', '1', '1', '1', '1'
                },
                new[]
                {
                    '0', '1', '1', '1', '1', '1', '1', '0', '1', '1', '1', '1', '1', '1', '1', '1', '0', '1', '1', '1',
                    '0', '1', '1', '1', '1', '0', '1', '1', '1', '0', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1'
                },
                new[]
                {
                    '0', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '0', '1', '0', '1', '1', '1', '1', '0',
                    '1', '1', '1', '1', '1', '1', '0', '1', '0', '1', '1', '0', '0', '1', '1', '1', '1', '0', '1', '1'
                },
                new[]
                {
                    '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '0', '1', '1', '1', '1', '0', '1',
                    '1', '1', '1', '1', '1', '1', '0', '1', '1', '1', '1', '1', '1', '1', '1', '0', '1', '1', '1', '0'
                },
                new[]
                {
                    '1', '1', '1', '1', '1', '0', '1', '1', '1', '1', '1', '1', '1', '1', '0', '0', '1', '1', '1', '1',
                    '1', '1', '1', '1', '1', '1', '1', '0', '1', '1', '1', '1', '1', '1', '0', '0', '1', '1', '1', '1'
                },
                new[]
                {
                    '1', '1', '0', '1', '1', '0', '1', '1', '1', '1', '1', '1', '0', '1', '0', '1', '1', '1', '1', '1',
                    '0', '1', '1', '1', '1', '1', '1', '1', '1', '0', '0', '1', '1', '1', '0', '1', '0', '1', '0', '0'
                },
                new[]
                {
                    '0', '1', '1', '0', '1', '1', '1', '1', '1', '1', '1', '0', '0', '1', '1', '1', '1', '1', '0', '0',
                    '1', '0', '1', '1', '1', '1', '1', '0', '1', '1', '1', '0', '1', '1', '0', '1', '1', '1', '0', '1'
                }
            }));
        }
    }

    public class Solution
    {
        public int MaximalRectangle2(char[][] matrix)
        {
            if (matrix.Length == 0 || matrix[0].Length == 0)
            {
                return 0;
            }

            var newXLen = matrix.Length;
            var newYLen = matrix[0].Length;

            var matrixX = new int[newYLen];

            var step = -1;
            var maxMaxVal = 0;

            const char zero = '0';
            const char one = '1';

            while (true)
            {
                var maxXVal = 0;
                var maxYVal = 0;
                step++;

                newXLen--;
                newYLen--;

                var nonZero = false;
                var oldXLen = newXLen + 1;
                var oldYLen = newYLen + 1;

                for (var i = 0; i < oldXLen; i++)
                {
                    var xCounter = 0;
                    for (var k = 0; k < oldYLen; k++)
                    {
                        var newX = 0;

                        if (i == 0)
                        {
                            newX = matrix[i][k] == zero ? 0 : 1;
                        }

                        if (matrix[i][k] == one)
                        {
                            xCounter++;
                        }
                        else
                        {
                            xCounter = 0;
                        }

                        if (i > 0 && matrix[i][k] != zero)
                        {
                            newX = matrixX[k] + 1;
                        }

                        matrixX[k] = newX;

                        maxYVal = Math.Max(maxYVal, xCounter);
                        maxXVal = Math.Max(maxXVal, newX);

                        //
                        if (i < newXLen && k < newYLen)
                        {
                            var isOne = matrix[i][k] == one;

                            if (isOne)
                            {
                                isOne = (k >= newYLen ? zero : matrix[i][k + 1]) == one;
                            }

                            if (isOne)
                            {
                                isOne = (i >= newXLen ? zero : matrix[i + 1][k]) == one;
                            }

                            if (isOne)
                            {
                                isOne = matrix[i + 1][k + 1] == one;
                            }

                            matrix[i][k] = isOne ? one : zero;
                            nonZero = nonZero || isOne;
                        }
                    }
                }

                var maxVal = Math.Max(maxXVal, maxYVal);
                var newMaxVal = (step + 1) * (maxVal + step);
                var maxPossibleVal = (maxXVal + step) * (maxYVal + step);

                if (maxPossibleVal < maxMaxVal)
                {
                    return maxMaxVal;
                }

                maxMaxVal = Math.Max(maxMaxVal, newMaxVal);

                if (!nonZero)
                {
                    break;
                }
            }

            return maxMaxVal;
        }

        public int MaximalRectangle(char[][] matrix)
        {
            if (matrix.Length == 0 || matrix[0].Length == 0)
            {
                return 0;
            }

            var zero = '0';
            var startRect = new Area(new Point(0, 0), new Point(matrix.Length - 1, matrix[0].Length - 1));
            var maxRects = new HashSet<Area> {startRect};

            for (var i = 0; i < matrix.Length; i++)
            {
                for (var k = 0; k < matrix[i].Length; k++)
                {
                    if (matrix[i][k] == zero)
                    {
                        var newRects = new HashSet<Area>();
                        foreach (var rect in maxRects)
                        {
                            // check if in max rect
                            if (i >= rect.start.x && i <= rect.finish.x && k >= rect.start.y && k <= rect.finish.y)
                            {
                                if (i - 1 >= rect.start.x)
                                {
                                    var rect1 = new Area(new Point(rect.start.x, rect.start.y),
                                        new Point(i - 1, rect.finish.y));
                                    if (!newRects.Contains(rect1))
                                    {
                                        newRects.Add(rect1);
                                    }
                                }

                                if (i + 1 <= rect.finish.x)
                                {
                                    var rect2 = new Area(new Point(i + 1, rect.start.y),
                                        new Point(rect.finish.x, rect.finish.y));
                                    if (!newRects.Contains(rect2))
                                    {
                                        newRects.Add(rect2);
                                    }
                                }

                                if (k - 1 >= rect.start.y)
                                {
                                    var rect3 = new Area(new Point(rect.start.x, rect.start.y),
                                        new Point(rect.finish.x, k - 1));
                                    if (!newRects.Contains(rect3))
                                    {
                                        newRects.Add(rect3);
                                    }
                                }

                                if (k + 1 <= rect.finish.y)
                                {
                                    var rect4 = new Area(new Point(rect.start.x, k + 1),
                                        new Point(rect.finish.x, rect.finish.y));
                                    if (!newRects.Contains(rect4))
                                    {
                                        newRects.Add(rect4);
                                    }
                                }
                            }
                            else
                            {
                                newRects.Add(rect);
                            }
                        }

                        maxRects = newRects;
                    }
                }
            }

            return maxRects.Count > 0 ? maxRects.Max(a => a.area) : 0;
        }

        private class Area : IComparable<Area>
        {
            private static int[] Primes =
            {
                2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97, 101,
                103, 107, 109, 113, 127, 131, 137, 139, 149, 151, 157, 163, 167, 173, 179, 181, 191, 193, 197, 199, 211,
                223, 227, 229, 233, 239, 241, 251, 257, 263, 269, 271, 277, 281, 283, 293, 307, 311, 313, 317, 331, 337,
                347, 349, 353, 359, 367, 373, 379, 383, 389, 397, 401, 409, 419, 421, 431, 433, 439, 443, 449, 457, 461,
                463, 467, 479, 487, 491, 499, 503, 509, 521, 523, 541, 547, 557, 563, 569, 571, 577, 587, 593, 599, 601,
                607, 613, 617, 619, 631, 641, 643, 647, 653, 659, 661, 673, 677, 683, 691, 701, 709, 719, 727, 733, 739,
                743, 751, 757, 761, 769, 773, 787, 797, 809, 811, 821, 823, 827, 829, 839, 853, 857, 859, 863, 877, 881,
                883, 887, 907, 911, 919, 929, 937, 941, 947, 953, 967, 971, 977, 983, 991, 997, 1009, 1013, 1019, 1021,
                1031, 1033, 1039, 1049, 1051, 1061, 1063, 1069, 1087, 1091, 1093, 1097, 1103, 1109, 1117, 1123, 1129,
                1151, 1153, 1163, 1171, 1181, 1187, 1193, 1201, 1213, 1217, 1223, 1229, 1231, 1237, 1249, 1259, 1277,
                1279, 1283, 1289, 1291, 1297, 1301, 1303, 1307, 1319, 1321, 1327, 1361, 1367, 1373, 1381, 1399, 1409,
                1423, 1427, 1429, 1433, 1439, 1447, 1451, 1453, 1459, 1471, 1481, 1483, 1487, 1489, 1493, 1499, 1511,
                1523, 1531, 1543, 1549, 1553, 1559, 1567, 1571, 1579
            };

            public Point start;
            public Point finish;
            public int area;

            private readonly int _hashcode;

            public Area(Point start, Point finish)
            {
                this.start = start;
                this.finish = finish;
                area = (finish.x - start.x + 1) * (finish.y - start.y + 1);
                var l = Primes.Length;
                _hashcode = Primes[start.x % l] * Primes[finish.x % l] * Primes[start.y % l] * Primes[finish.y % l];
            }

            public int CompareTo(Area other)
            {
                return other.area - area;
            }

            public override int GetHashCode()
            {
                return _hashcode;
            }
        }

        private class Point
        {
            public int x;
            public int y;

            public Point(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }
    }
}