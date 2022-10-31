using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using UnityEngine;

public static class Dijkstra
{
    public static int[] distance;
    public static string[] nodes;
    public static string[] nodesArray = new string[100];

    private static int MinimumDistance(int[] distance, bool[] shortestPathTreeSet, int verticesCount)
    {
        int min = int.MaxValue;
        int minIndex = 0;

        for (int v = 0; v < verticesCount; ++v)
        {
            if (shortestPathTreeSet[v] == false && distance[v] <= min)
            {
                min = distance[v];
                minIndex = v;
            }
        }
        return minIndex;
    }

    public static void Calculate(CustomGraph graph, int origin)
    {
        int[,] auxGraph = graph.adMatrix;

        int verticesCount = graph.nodesQuantity;

        origin = graph.Vert2Index(origin);

        distance = new int[verticesCount];

        bool[] shortestPathTreeSet = new bool[verticesCount];

        int[] nodesA = new int[verticesCount];
        int[] nodesB = new int[verticesCount];

        for (int i = 0; i < verticesCount; ++i)
        {
            distance[i] = int.MaxValue;

            shortestPathTreeSet[i] = false;

            nodesA[i] = nodesB[i] = -1;
        }

        distance[origin] = 0;
        nodesA[origin] = nodesB[origin] = graph.tags[origin];

        for (int count = 0; count < verticesCount - 1; ++count)
        {
            int u = MinimumDistance(distance, shortestPathTreeSet, verticesCount);
            shortestPathTreeSet[u] = true;

            for (int v = 0; v < verticesCount; ++v)
            {
                if (!shortestPathTreeSet[v] && Convert.ToBoolean(auxGraph[u, v]) && distance[u] != int.MaxValue && distance[u] + auxGraph[u, v] < distance[v])
                {
                    distance[v] = distance[u] + auxGraph[u, v];
                    nodesA[v] = graph.tags[u];
                    nodesB[v] = graph.tags[v];
                }
            }
        }

        nodes = new string[verticesCount];
        int nodOrig = graph.tags[origin];
        for (int i = 0; i < verticesCount; i++)
        {
            if (nodesA[i] != -1)
            {
                List<int> l1 = new List<int>();
                l1.Add(nodesA[i]);
                l1.Add(nodesB[i]);
                while (l1[0] != nodOrig)
                {
                    for (int j = 0; j < verticesCount; j++)
                    {
                        if (j != origin && l1[0] == nodesB[j])
                        {
                            l1.Insert(0, nodesA[j]);
                            break;
                        }
                    }
                }

                for (int j = 0; j < l1.Count; j++)
                {
                    if (j == 0)
                    {
                        nodes[i] = l1[j].ToString();
                    }
                    else
                    {
                        nodes[i] += "," + l1[j].ToString();
                    }

                    nodesArray[j] = l1[j].ToString();
                }
            }
        }
    }
}
