using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /*You are given an undirected weighted graph of n nodes (0-indexed), represented by an edge list where edges[i] = [a, b] 
     * is an undirected edge connecting the nodes a and b with a probability of success of traversing that edge succProb[i].

    Given two nodes start and end, find the path with the maximum probability of success to go from start to end and return its success probability.

    If there is no path from start to end, return 0. Your answer will be accepted if it differs from the correct answer by at most 1e-5.

    Constraints:

    2 <= n <= 10^4
    0 <= start, end < n
    start != end
    0 <= a, b < n
    a != b
    0 <= succProb.length == edges.length <= 2*10^4
    0 <= succProb[i] <= 1
    There is at most one edge between every two nodes.
     */
    internal static class MaximumProbability
    {
        public static double MaxProbability(int n, int[][] edges, double[] succProb, int start, int end)
        {
            if (n == 0) return 1;
            /*Implementing a variation of Dijkstra algorithm.
            The original one stores weights of each vertice - probabilities[i].
            Inn our case, it will be initialized with probabilities[i] = 0, and after 
            visiting each vertice, these values might be increased*/
            double[] verticeProbabilities = new double[n];

            // For each vertice, find it's adjacents
            HashSet<Tuple<int, double>>[] verticeAdjacents = new HashSet<Tuple<int, double>>[n];

            for (int i = 0; i < edges.Length; ++i)
            {
                if (verticeAdjacents[edges[i][0]] == null)
                {
                    verticeAdjacents[edges[i][0]] = new HashSet<Tuple<int, double>>();

                }
                if (verticeAdjacents[edges[i][1]] == null)
                    verticeAdjacents[edges[i][1]] = new HashSet<Tuple<int, double>>();

                verticeAdjacents[edges[i][1]].Add(new Tuple<int, double>(edges[i][0], succProb[i]));
                verticeAdjacents[edges[i][0]].Add(new Tuple<int, double>(edges[i][1], succProb[i]));
            }

            // Initialize starting point
            verticeProbabilities[start] = 1;
            int current = start;
            double unvisitedMax = verticeProbabilities[start];

            HashSet<int> unvisited = Enumerable.Range(0, n).ToHashSet();
            unvisited.Remove(start);
            while ((unvisited.Count > 0) && (unvisitedMax > 0))
            {
                VisitVertice(current, verticeProbabilities, unvisited, verticeAdjacents);
                unvisitedMax = 0;
                foreach (int i in unvisited)
                    if (verticeProbabilities[i] > unvisitedMax)
                    {
                        current = i;
                        unvisitedMax = verticeProbabilities[i];
                    }
            }
            return verticeProbabilities[end];
        }

        public static void VisitVertice(int current, double[] verticeProbabilities, HashSet<int> unvisited, HashSet<Tuple<int, double>>[] verticeAdjacents)
        {
            unvisited.Remove(current);
            if (verticeAdjacents[current] != null)
                foreach (Tuple<int, double> adjacent in verticeAdjacents[current])
                    if (verticeProbabilities[adjacent.Item1] < verticeProbabilities[current] * adjacent.Item2)
                        verticeProbabilities[adjacent.Item1] = verticeProbabilities[current] * adjacent.Item2;
        }
    }
}
