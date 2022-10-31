using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GraphGenerator : MonoBehaviour
{
    [SerializeField]
    List<Edge> edges = new List<Edge>();

    [SerializeField]
    GameObject[] verteces;

    Dictionary<int, GameObject> graphDic = new Dictionary<int, GameObject>();
    Dictionary<GameObject, int> invGraphDic = new Dictionary<GameObject, int>();

    [SerializeField]
    public CustomGraph staticGraph;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void GenerateGraph()
    { 
        verteces.Initialize();
        graphDic.Clear();
        invGraphDic.Clear();

        GetVerteces();
        GenerateEdgesList();
        InitializeGraph();

        if (staticGraph == null)
        {
            Debug.Log("Aca?");
        }
    }
    void GetVerteces()
    {
        verteces = GameObject.FindGameObjectsWithTag("Waypoint");

        for (int i = 0; i < verteces.Length; i++)
        {
            verteces[i].name = $"{i}";
            graphDic.Add(i, verteces[i]);
            invGraphDic.Add(verteces[i], i);
        }
    }
    void InitializeGraph()
    { 
        staticGraph = new CustomGraph();

        staticGraph.Initialize();

        for (int i = 0; i < verteces.Length; i++)
        {
            staticGraph.AddVertex(invGraphDic[graphDic[i]]);
        }

        for (int i = 0; i < edges.Count; i++)
        {
            staticGraph.AddEdge(edges[i].Origin, edges[i].Destination, edges[i].Weight);
        }

        //Debug.Log($"Se han cargado {staticGraph.edgesQuantity} de {edges.Count}");
        //Debug.Log($"Hay {staticGraph.nodesQuantity}");
    }
    void GenerateEdgesList()
    {
        foreach (var origin in graphDic.Values)
        {
            foreach (var destination in graphDic.Values)
            {
                if (origin.transform.position != destination.transform.position)
                {
                    Vector3 dir = origin.transform.position - destination.transform.position;
                    Ray ray = new Ray(origin.transform.position, -dir);
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit))
                    {
                        //Debug.Log($" Origen {origin.name} / Destino {destination.name} / Hit {hit.transform.name}");

                        if (hit.transform.tag == "Waypoint")
                        {
                            edges.Add(new Edge(invGraphDic[origin], invGraphDic[destination], (int)hit.distance));

                            Debug.Log("Se agregó una Arista!");
                        }
                    };
                }
                else
                {
                    Debug.Log("Mismo Objeto");
                }
            }
        }
    }
}
