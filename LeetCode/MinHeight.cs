using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public static class MinHeight
    {
        public static IList<int> FindMinHeightTrees(int n, int[][] edges)
        {
            HashSet<int>[] verticeAdjacents = new HashSet<int>[n];
            Queue<int> leaves = new Queue<int>();
            List<int> result = new List<int>();

            if (edges.Length == 0)
                return new List<int> {0};

            foreach (var edge in edges)
            {
                if (verticeAdjacents[edge[0]] == null)
                    verticeAdjacents[edge[0]] = new HashSet<int>();
                if (verticeAdjacents[edge[1]] == null)
                    verticeAdjacents[edge[1]] = new HashSet<int>();

                verticeAdjacents[edge[1]].Add(edge[0]);
                verticeAdjacents[edge[0]].Add(edge[1]);
            }

            int verticesCount = n;
            for (int i = 0; i < verticesCount; ++i)
                if (verticeAdjacents[i].Count == 1)
                    leaves.Enqueue(i);

            while (verticesCount > 2)
            {
                int leavesCount = leaves.Count;
                verticesCount -= leavesCount;

                for (int i = 0; i < leavesCount; ++i)
                {
                    int currentLeave = leaves.Dequeue();
                    foreach (int adjacent in verticeAdjacents[currentLeave])
                    {
                        verticeAdjacents[adjacent].Remove(currentLeave);
                        if (verticeAdjacents[adjacent].Count == 1)
                            leaves.Enqueue(adjacent);
                    }
                }
            }
            while (leaves.Count > 0)
                result.Add(leaves.Dequeue());   

            return result;
        }
    }
}
