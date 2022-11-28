using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    IInteractable attached;
    [SerializeField]
    GameObject objectAttached;
    [SerializeField]
    string textToShow;
    [SerializeField]
    bool isVisible;
    string nodeName;
    bool isInteractable = false;

    BoxCollider boxCollider;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider>();
    }

    private void Start()
    {
        nodeName = gameObject.name;

        if (objectAttached != null)
        {
            attached = objectAttached.GetComponent<IInteractable>();
            isInteractable = true;
            boxCollider.size = Vector3.one * 5;
            //Debug.Log($"El nodo {nodeName} tiene atachado el objeto {objectAttached.name}");
        }
        else if (isVisible)
        {
            isInteractable = true;
            boxCollider.size = Vector3.one * 5;
        }
        else
        {
            isInteractable = false;
            boxCollider.size = Vector3.one;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Collision");
        //Debug.Log(Dijkstra.nodes[Dijkstra.nodes.Length - 1]);

        if (objectAttached != null && Dijkstra.destiny == nodeName && other.tag == "Employee")
        {
            attached.Interact(other);
            //Debug.Log("Dar Paquete");
        }
    }

    private void OnMouseOver()
    {
        if (isInteractable)
        {
            UIManager.Instance.ShowName(textToShow);
        }

        if (Input.GetMouseButtonDown(1))
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
