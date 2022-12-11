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

    private void Start()
    {
        GenerateGraph();
    }

    public void GenerateGraph()
    { 
        verteces.Initialize();
        graphDic.Clear();
        invGraphDic.Clear();

        GetVerteces();
        GenerateEdgesList();
        InitializeGraph();
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
        graphDic.Clear();
        invGraphDic.Clear();

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
        //SaveGraph(staticGraph, "grafos", levelName);

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
                    if (Physics.Raycast(ray, out hit) && hit.transform.CompareTag("Waypoint") && hit.transform.name == destination.name)
                    {
                        Debug.Log($" Origen {origin.name} / Destino {destination.name} / Hit {hit.transform.name}");

                        //Debug.Log("Encontré una arista!");
                        edges.Add(new Edge(invGraphDic[origin], invGraphDic[destination], Mathf.RoundToInt(Vector3.Distance(origin.transform.position, destination.transform.position))));

                        //Debug.Log("Se agregó una Arista!");
                    }
                    else
                    {
                        Debug.Log("Encontré una caja!");
                    }
                }
                else
                {
                    //Debug.Log("Mismo Objeto");
                }
            }
        }
        /*
        foreach (var destination in graphDic.Values)
        {
            foreach (var origin in graphDic.Values)
            {
                if (destination.transform.position != origin.transform.position)
                {
                    Vector3 dir = destination.transform.position - origin.transform.position;
                    Ray ray = new Ray(destination.transform.position, -dir);
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit, 12f) && hit.transform.tag == "Waypoint")
                    {
                        //Debug.Log($" Origen {origin.name} / Destino {destination.name} / Hit {hit.transform.name}");

                        //Debug.Log("Encontré una arista!");
                        edges.Add(new Edge(invGraphDic[destination], invGraphDic[origin], Mathf.RoundToInt(Vector3.Distance(destination.transform.position, origin.transform.position))));

                        //Debug.Log("Se agregó una Arista!");
                    }
                    else
                    {
                        Debug.Log("Encontré una caja!");
                    }
                }
                else
                {
                    //Debug.Log("Mismo Objeto");
                }
            }
        }*/
    }
}
