using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CustomGraph : IGraph
{
    static int N = 100;
    public int[,] adMatrix;
    public int[] plainAdMatrix;
    public int[] tags;
    public int nodesQuantity;
    public int edgesQuantity;
    public string graphName = "Default";

    public void AddEdge(int inputA, int inputB, int weight)
    {
        int o = Vert2Index(inputA);
        int d = Vert2Index(inputB);
        adMatrix[o, d] = weight;
        edgesQuantity++;
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
        edgesQuantity--;
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
        plainAdMatrix = new int[N*N];
        tags = new int[N];
        nodesQuantity = 0;
        edgesQuantity = 0;

        //Debug.Log(adMatrix.Length);
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

    public int Vert2Index(int input)
    {
        int i = nodesQuantity - 1;
        while (i >= 0 && tags[i] != input)
        {
            i--;
        }
        return i;
    }

    public void PlainAdMatrix()
    {
        for (int xAxis = 0; xAxis < N; xAxis++)
        {
            for (int yAxis = 0; yAxis < N; yAxis++)
            {
                plainAdMatrix[yAxis*N + xAxis] = adMatrix[xAxis, yAxis];
            }
        }
    }
    public void ComposeAdMatrix()
    {
        adMatrix = new int[N, N];
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                adMatrix[i,j] = plainAdMatrix[i*N+j];
                //if (adMatrix[i,j] != 0) Debug.Log($"Para la posición {i} , {j} se tomó el dato de {i*N+j} que es {adMatrix[i,j]}");
            }
        }
    }
   }
