using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    IInreractable attached;
    [SerializeField] GameObject objectAttached;
    string nodeName;

    private void Start()
    {
        nodeName = gameObject.name;

        if (objectAttached != null)
        {
            attached = objectAttached.GetComponent<IInreractable>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision");
        //Debug.Log(Dijkstra.nodes[Dijkstra.nodes.Length - 1]);

        if (objectAttached != null && Dijkstra.destiny == nodeName && other.tag == "Employee")
        {
            attached.Interact(other);
            Debug.Log("Dar Paquete");
        }
    }
}
