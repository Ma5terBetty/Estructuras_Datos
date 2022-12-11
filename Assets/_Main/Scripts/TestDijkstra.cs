using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestDijkstra : MonoBehaviour
{
    [SerializeField]
    public int origen;
    [SerializeField]
    public int destino;
    [SerializeField]
    string levelName;
    [SerializeField]
    GraphGenerator generator;

    string textNodes = string.Empty;
    public string[] travelNodes = new string[100];

    public GameObject[] waypoints;
    public Dictionary<string, GameObject> waypointsDic = new Dictionary<string, GameObject>();
    
    CustomGraph graph = new CustomGraph();

    void Start()
    {
        waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
        //graph = GraphGenerator.LoadGraph("grafos", SceneManager.GetActiveScene().name);
        //graph.ComposeAdMatrix();

        //graph = generator.staticGraph;

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
            //Debug.Log($"{waypoints[i]}");
        }

        /*if (waypointsDic.ContainsKey("0"))
        {
            Debug.Log("Algo hay");
        }*/
    }

    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.G))
        {
            CalculateDestination();
        }*/
    }

    public void CalculateDestination()
    {
        textNodes = string.Empty;
        var ori = origen;
        var dest = destino;

        Dijkstra.destiny = destino.ToString();
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

                if (textNodes == null) Debug.Log("EHHHH2");

                Debug.Log(textNodes);

                char delimiter = ',';

                
                travelNodes = textNodes.Split(delimiter);

                foreach (string node in travelNodes)
                {
                    //Debug.Log($"{node}");
                }
            }
        }

        origen = destino;
        destino = 0;

        for (int i = 0; i < Dijkstra.nodesArray.Length; i++)
        {
            //Debug.Log($"{Dijkstra.nodesArray[i]}");
        }
    }
}
