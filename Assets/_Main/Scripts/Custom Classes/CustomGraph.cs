using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomGraph : IGraph
{
    static int N = 100;
    public int[,] adMatrix;
    public int[] tags;
    public int nodesQuantity;

    public void AddEdge(int inputA, int inputB, int weight)
    {
        int o = Vert2Index(inputA);
        int d = Vert2Index(inputB);
        adMatrix[o, d] = weight;
    }

    public void AddVertex(int input)
    {
        tags[nodesQuantity] = input;
        for (int i = 0; i <= nodesQuantity; i++)
        {
            adMatrix[nodesQuantity, i] = 0;
            adMatrix[i, nodesQuantity] = 0;
        }
        nodesQuantity++;
    }

    public void DeleteEdge(int inputA, int inputB)
    {
        int o = Vert2Index(inputA);
        int d = Vert2Index(inputB);
        adMatrix[o, d] = 0;
    }

    public void DeleteVertex(int input)
    {
        int ind = Vert2Index(input);

        for (int i = 0; i < nodesQuantity; i++)
        {
            adMatrix[i, ind] = adMatrix[i, nodesQuantity - 1];
        }
        for (int i = 0; i < nodesQuantity; i++)
        {
            adMatrix[ind, i] = adMatrix[nodesQuantity - 1, i];
        }
        tags[ind] = tags[nodesQuantity - 1];
        nodesQuantity--;
    }

    public bool EdgeBelongs(int inputA, int inputB)
    {
        int o = Vert2Index(inputA);
        int d = Vert2Index(inputB);
        return adMatrix[o, d] != 0;
    }

    public int EdgeWeight(int inputA, int inputB)
    {
        int o = Vert2Index(inputA);
        int d = Vert2Index(inputB);
        return adMatrix[o, d];
    }

    public void Initialize()
    {
        adMatrix = new int[N,N];
        tags = new int[N];
        nodesQuantity = 0;
    }

    public ISet Vertices()
    {
        CustomSet vert = new CustomSet();
        vert.InitializeSet();
        for (int i = 0; i < nodesQuantity; i++)
        { 
            vert.Add(tags[i]);
        }
        return vert;
    }

    private int Vert2Index(int input)
    {
        int i = nodesQuantity - 1;
        while (i >= 0 && tags[i] != input)
        {
            i--;
        }
        return i;
    }
   }
