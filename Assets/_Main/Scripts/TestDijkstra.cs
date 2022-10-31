using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDijkstra : MonoBehaviour
{
    [SerializeField]
    int origen;
    [SerializeField]
    int destino;

    string textNodes;
    public string[] travelNodes = new string[100];

    [SerializeField]
    GraphGenerator generator;
    CustomGraph graph;

    void Start()
    {
        graph = generator.staticGraph;

        if (graph == null)
        {
            Debug.Log("NULL");
        }
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            CalculateDestination();
        }
    }

    public void CalculateDestination()
    {
        generator.GenerateGraph();

        graph = generator.staticGraph;

        var ori = origen;
        var dest = destino;

        Dijkstra.Calculate(generator.staticGraph, ori);

        // obtener el camino
        var distancia = string.Empty;
        var nodos = string.Empty;

        for (int i = 0; i < generator.staticGraph.nodesQuantity; ++i)
        {
            if (Dijkstra.distance[i] == int.MaxValue)
            {
                distancia = "---";
            }
            else
            {
                distancia = Dijkstra.distance[i].ToString();
            }

            if (generator.staticGraph.tags[i] == dest)
            {
                nodos = Dijkstra.nodes[i];
                var mensaje = string.Format("Vertice: {0} --x-- Distancia: {1} --x-- Camino: {2}", generator.staticGraph.tags[i], distancia, Dijkstra.nodes[i]);
                Debug.Log(mensaje);
                textNodes = Dijkstra.nodes[i];

                Debug.Log(textNodes);

                char delimiter = ',';
                travelNodes = textNodes.Split(delimiter);
                foreach (string node in travelNodes)
                {
                    //Debug.Log($"{node}");
                }
            }
        }
    }
}
