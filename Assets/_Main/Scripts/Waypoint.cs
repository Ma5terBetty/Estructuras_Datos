using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    IInteractable attached;
    [SerializeField] GameObject objectAttached;
    string nodeName;
    bool isInteractable = false;

    private void Start()
    {
        nodeName = gameObject.name;

        if (objectAttached != null)
        {
            attached = objectAttached.GetComponent<IInteractable>();
            isInteractable = true;
            //Debug.Log($"El nodo {nodeName} tiene atachado el objeto {objectAttached.name}");
        }
        else
        {
            isInteractable = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Collision");
        //Debug.Log(Dijkstra.nodes[Dijkstra.nodes.Length - 1]);

        if (objectAttached != null && Dijkstra.destiny == nodeName && other.tag == "Employee")
        {
            attached.Interact(other);
            Debug.Log("Dar Paquete");
        }
    }

    private void OnMouseOver()
    {
        if (isInteractable)
        {
            UIManager.Instance.ShowName("Hello There");
        }

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Me han clickeado");
            Supervisor.Instance.dijkstraTest.destino = int.Parse(gameObject.name);
            Supervisor.Instance.dijkstraTest.CalculateDestination();
            Supervisor.Instance.AssignTask();
        }
    }

    private void OnMouseExit()
    {
        if (isInteractable)
        {
            UIManager.Instance.TurnOffName();
        }
    }
}
