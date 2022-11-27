using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestDijkstra : MonoBehaviour
{
    [SerializeField]
    int origen;
    [SerializeField]
    int destino;
    [SerializeField]
    string levelName;

    string textNodes;
    public string[] travelNodes = new string[100];

    public GameObject[] waypoints;
    public Dictionary<string, GameObject> waypointsDic = new Dictionary<string, GameObject>();
    
    CustomGraph graph = new CustomGraph();

    void Start()
    {
        graph = GraphGenerator.LoadGraph("grafos", SceneManager.GetActiveScene().name);
        graph.ComposeAdMatrix();

        if (graph == null)
        {
            Debug.LogError("El grafo es Nulo");
        }
        else
        {
            Debug.Log("Grafo cargado correctamente");
        }

        for (int i = 0; i < waypoints.Length; i++)
        { 
            waypointsDic.Add(waypoints[i].name, waypoints[i]);
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
        var ori = origen;
        var dest = destino;

        Dijkstra.destiny = destino.ToString();
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
                //Debug.Log(mensaje);
                textNodes = Dijkstra.nodes[i];

                //Debug.Log(textNodes);

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
