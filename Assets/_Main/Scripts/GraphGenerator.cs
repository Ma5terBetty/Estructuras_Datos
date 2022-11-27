using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GraphGenerator : MonoBehaviour
{
    [SerializeField]
    List<Edge> edges = new List<Edge>();

    [SerializeField]
    GameObject[] verteces;

    [SerializeField]
    string levelName;

    public Dictionary<int, GameObject> graphDic = new Dictionary<int, GameObject>();
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
    public static CustomGraph LoadGraph(string path, string filename)
    { 
        string fullpath = Application.persistentDataPath + "/" + path + "/" + filename + ".json";
        if (File.Exists(fullpath))
        {
            string textJson = File.ReadAllText(fullpath);
            var obj = JsonUtility.FromJson<CustomGraph>(textJson);
            return obj;
        }
        else
        {
            Debug.Log("File, or data not found");
            return default;
        }
    }
    public static void SaveGraph(CustomGraph graph, string path, string filename)
    {
        string fullPath = Application.persistentDataPath + "/" + path + "/";
        bool checkFolderExit = Directory.Exists(fullPath);
        if (!checkFolderExit)
        { 
            Directory.CreateDirectory(fullPath);
        }
        string json = JsonUtility.ToJson(graph);
        File.WriteAllText(fullPath + filename + ".json", json);
        Debug.Log("Graph Saved");
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

        staticGraph.PlainAdMatrix();
        SaveGraph(staticGraph, "grafos", levelName);

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
                        Debug.Log($" Origen {origin.name} / Destino {destination.name} / Hit {hit.transform.name}");

                        if (hit.transform.tag == "Waypoint")
                        {
                            edges.Add(new Edge(invGraphDic[origin], invGraphDic[destination], (int)hit.distance));

                            //Debug.Log("Se agregó una Arista!");
                        }
                    };
                }
                else
                {
                    //Debug.Log("Mismo Objeto");
                }
            }
        }
    }
}
