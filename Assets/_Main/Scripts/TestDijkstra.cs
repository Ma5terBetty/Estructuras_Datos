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
    
    CustomGraph graph = new CustomGraph();

    void Start()
    {
        graph = GraphGenerator.LoadGraph("grafos", "nivel1");
        graph.ComposeAdMatrix();

        if (graph == null)
        {
            Debug.Log("NULL");
        }
        else
        {
            Debug.Log("Grafo cargado correctamente");
            //graph.ComposeAdMatrix();
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
        //generator.GenerateGraph();

        //graph = generator.staticGraph;

        var ori = origen;
        var dest = destino;

        Dijkstra.Calculate(graph, ori);

        // obtener el camino
        var distancia = string.Empty;
        var nodos = string.Empty;

        for (int i = 0; i < graph.nodesQuantity; ++i)
        {
            if (Dijkstra.distance[i] == int.MaxValue)
            {
                distancia = "---";
            }
            else
            {
                distancia = Dijkstra.distance[i].ToString();
            }

            if (graph.tags[i] == dest)
            {
                nodos = Dijkstra.nodes[i];
                var mensaje = string.Format("Vertice: {0} --x-- Distancia: {1} --x-- Camino: {2}", graph.tags[i], distancia, Dijkstra.nodes[i]);
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
