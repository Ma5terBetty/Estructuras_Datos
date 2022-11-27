using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGraph
{
    void Initialize();
    void AddVertex(int input);
    void DeleteVertex(int input);
    ISet Vertices();
    void AddEdge(int inputA, int inputB, int weight);
    void DeleteEdge(int inputA, int inputB);
    bool EdgeBelongs(int inputA, int inputB);
    int EdgeWeight(int inputA, int inputB);
}
