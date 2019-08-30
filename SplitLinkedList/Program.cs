using System;
using System.Collections.Generic;

namespace SplitLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            var root = new ListNode(1) {next = new ListNode(2) {next = new ListNode(3) {next = new ListNode(4)}}};

            Console.WriteLine(new Solution().SplitListToParts2(root, 3));
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
        public ListNode[] SplitListToParts2(ListNode root, int k) {
            var res = new ListNode[k];
            if (root == null) return res;
            var temp_res = new ListNode[k];
            int count = 0;
            var ptr = root;
            var r = root;

            while (r != null)
            {
                count++;
                r = r.next;
            }

            int num_Extra = count % k;
            int filler = count / k;
            int counter = 0;

            while (ptr != null)
            {
                int i = 0;
                int j = filler;

                if (counter < num_Extra) j++;

                while (i < j && ptr != null)
                {
                    if (i == 0)
                    {
                        res[counter] = new ListNode(ptr.val);
                        temp_res[counter] = res[counter];
                    }
                    else
                    {
                        temp_res[counter].next = new ListNode(ptr.val);
                        temp_res[counter] = temp_res[counter].next;
                    }

                    ptr = ptr.next;
                    i++;
                }

                counter++;
            }

            return res;
        }
        
        public ListNode[] SplitListToParts(ListNode root, int k)
        {
            var nextNode = root;
            var nodes = new List<ListNode>();
            while (nextNode != null)
            {
                nodes.Add(nextNode);
                nextNode = nextNode.next;
            }

            var totalLen = nodes.Count;
            var nextIndex = 0;
            var i = 0;
            var splittedNodes = new ListNode[k];
            while (k > 0 && totalLen > 0)
            {
                splittedNodes[i] = nodes[nextIndex];
                var partSize = DivideRoundingUp(totalLen, k);
                nextIndex += partSize;
                nodes[nextIndex - 1].next = null;
                totalLen -= partSize;
                k--;
                i++;
            }

            while (k > 0)
            {
                splittedNodes[i] = null;
                i++;
                k--;
            }

            return splittedNodes;
        }

        public static int DivideRoundingUp(int x, int y)
        {
            int remainder;
            int quotient = Math.DivRem(x, y, out remainder);
            return remainder == 0 ? quotient : quotient + 1;
        }
    }
}