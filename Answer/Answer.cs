using System;
using System.Collections.Generic;

namespace Answer
{
    /*
    Given a reference of a node in a connected undirected graph,
    return a deep copy (clone) of the graph. Each node in the graph
    contains a val (int) and a list (List[Node]) of its neighbors.
     */

    // Definition for a Node.
    public class Node
    {
        public int val;
        public IList<Node> neighbors;

        public Node() { }
        public Node(int _val, IList<Node> _neighbors)
        {
            val = _val;
            neighbors = _neighbors;
        }
    }

    public class Solution
    {
        public Node CloneGraph(Node node)
        {
            return GetOrCopy(node);
        }

        private Node GetOrCopy(Node node, Dictionary<Node, Node> mapOfCopies = null)
        {
            if (mapOfCopies == null)
            {
                mapOfCopies = new Dictionary<Node, Node>();
            }
            if (mapOfCopies.ContainsKey(node))
            {
                return mapOfCopies[node];
            }
            Node copy = new Node()
            {
                val = node.val,
                neighbors = new List<Node>()
            };
            mapOfCopies.Add(node, copy);
            foreach (var neighbour in node.neighbors)
            {
                copy.neighbors.Add(GetOrCopy(neighbour, mapOfCopies));
            }
            return copy;
        }
    }
}