using System;
using System.Collections.Generic;
using System.IO;

namespace HackerRank
{
    public class EvenTreeProblem
    {
        private Node[] _allNodes;

        private class Node
        {
            private int _id;

            public int Id
            {
                get => _id;
                set => _id = value;
            }

            private readonly List<Node> _nodes = new List<Node>();
            
            public  Node Parent { get; set; }
            public int ChildrenCount { get; set; }

            public Node(int id)
            {
                _id = id;
            }

            public void AddChild(Node child)
            {
                _nodes.Add(child);
                child.Parent = this;
                ChildrenCount += child.ChildrenCount + 1;
                var curParent = Parent;
                while (curParent != null)
                {
                    curParent.ChildrenCount += child.ChildrenCount + 1;
                    curParent = curParent.Parent;
                }
            }
        }
        
        public EvenTreeProblem()
        {
            var fs = File.OpenText("Assets/even_tree.txt");
            var fl = fs.ReadLine()?.Split(' ');
            int treeNodes = Convert.ToInt32(fl?[0]);
            int treeEdges = Convert.ToInt32(fl?[1]);

            _allNodes = new Node[treeNodes];
            
            for (int i = 0; i < treeEdges; i++)
            {
                var line = fs.ReadLine().Split(' ');
                var nodeId = Convert.ToInt32(line[0]) - 1;
                var secNodeId = Convert.ToInt32(line[1]) - 1;
                if (_allNodes[nodeId] == null)
                {
                    _allNodes[nodeId] = new Node(nodeId);
                }
                if (_allNodes[secNodeId] == null)
                {
                    _allNodes[secNodeId] = new Node(secNodeId);
                }
                _allNodes[secNodeId].AddChild(_allNodes[nodeId]);
            }

            Array.ForEach(_allNodes, n => Console.WriteLine($"{n.Id + 1} === {n.ChildrenCount}"));
        }
        
        public int CountRemovedEdges()
        {
            var res = 0;
            foreach (var node in _allNodes)
            {
                if (node.Parent != null && node.ChildrenCount % 2 == 1)
                {
                    res++;
                }
            }

            return res;
        }
    }
}