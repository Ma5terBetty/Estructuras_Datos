using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edge
{
    int _origin;
    int _destination;
    int _weight;

    public int Origin => _origin;
    public int Destination => _destination;
    public int Weight => _weight;

    public Edge(int origin, int destination, int weight)
    { 
        _origin = origin;
        _destination = destination;
        _weight = weight;
    }
}
