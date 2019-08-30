using System;
using System.Collections.Generic;
using System.Linq;

namespace MergeLinkedLists
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new Solution().MergeKLists3(new ListNode[]
            {
                null,
                new ListNode(1) {next = new ListNode(4) {next = new ListNode(5)}},
                null,
                //new ListNode(1) {next = new ListNode(3) {next = new ListNode(4)}},
                new ListNode(2) {next = new ListNode(6)}
            }));
        }
    }


    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int x)
        {
            val = x;
        }
    }

    public class Solution
    {
        public ListNode MergeKLists3(ListNode[] lists)
        {
            var k = lists.Length;

            var interval = 1;
            while (interval < k)
            {
                for (var i = 0; i < k - interval; i += interval * 2)
                {
                    lists[i] = MergeLists(lists[i], lists[i + interval]);
                }
                
                interval *= 2;
            }

            return lists[0];
        }


        public ListNode MergeLists(ListNode node1, ListNode node2)
        {
            ListNode lastNode = new ListNode(0);
            var rootNode = lastNode;
            
            
            while (node1 != null || node2 != null)
            {
                if (node1 == null)
                {
                    lastNode.next = node2;
                    break;
                }

                if (node2 == null)
                {
                    lastNode.next = node1;
                    break;
                }
                
                if (node1.val < node2.val)
                {
                    lastNode.next = node1;
                    node1 = node1.next;
                    lastNode = lastNode.next;
                    continue;
                }

                if (node2.val <= node1.val)
                {
                    lastNode.next = node2;
                    node2 = node2.next;
                    lastNode = lastNode.next;
                }
            }

            return rootNode.next;
        }
        
        public ListNode MergeKLists2(ListNode[] lists)
        {
            var random = new Random();
            ListNode newRoot = null;
            ListNode startNode = null;
            var priorityQueue = new SortedDictionary<double, ListNode>();

            foreach (var node in lists)
            {
                if (node != null)
                {
                    priorityQueue.Add(random.NextDouble() + node.val, node);
                }
            }

            while (priorityQueue.Count > 0)
            {
                var kv = priorityQueue.First();
                if (startNode == null)
                {
                    newRoot = kv.Value;
                    startNode = newRoot;
                }
                else
                {
                    newRoot.next = kv.Value;
                    newRoot = newRoot.next;
                }
                priorityQueue.Remove(kv.Key);
                if (kv.Value.next != null)
                {
                    priorityQueue.Add(random.NextDouble() + kv.Value.next.val, kv.Value.next);
                }
            }

            return startNode;
        }

        public ListNode MergeKLists(ListNode[] lists)
        {
            ListNode newRoot = null;
            ListNode startRoot = null;
            var lastValue = int.MinValue;

            while (true)
            {
                var hasValues = false;
                var minValue = int.MaxValue;

                for (var i = 0; i < lists.Length; i++)
                {
                    if (lists[i] == null)
                    {
                        continue;
                    }

                    if (lists[i].val == lastValue)
                    {
                        lists[i] = lists[i].next;
                        lastValue = int.MinValue;
                        if (lists[i] == null)
                        {
                            continue;
                        }
                    }

                    hasValues = true;

                    if (lists[i].val < minValue)
                    {
                        minValue = lists[i].val;
                    }
                }

                if (!hasValues)
                {
                    break;
                }

                lastValue = minValue;

                if (newRoot == null)
                {
                    newRoot = new ListNode(minValue);
                    startRoot = newRoot;
                }
                else
                {
                    newRoot.next = new ListNode(minValue);
                    newRoot = newRoot.next;
                }
            }

            return startRoot;
        }
    }
}