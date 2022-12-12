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
    [SerializeField] bool isObstacle = false;

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
            //boxCollider.size = Vector3.one * 5;
            //Debug.Log($"El nodo {nodeName} tiene atachado el objeto {objectAttached.name}");
        }
        else if (isVisible)
        {
            isInteractable = true;
            //boxCollider.size = Vector3.one * 5;
        }
        else
        {
            isInteractable = false;
            //boxCollider.size = Vector3.one;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Collision");
        //Debug.Log(Dijkstra.nodes[Dijkstra.nodes.Length - 1]);
        var temp = other.GetComponent<Employee>();
        if (temp != null)
        {
            if (isObstacle)
            {
                if (temp.Role == EmployeeRole.GarbageCollector)
                {
                    Debug.Log("Soy Basurero");
                    /*isObstacle = false;
                    isVisible = false;
                    isInteractable = false;*/
                }
                else
                {
                    Debug.Log("Soy otro empleado");
                    other.GetComponent<TaskHandler>().Stopper();
                }
            }
            else
            {
                if (objectAttached != null && Dijkstra.destiny == nodeName && other.tag == "Employee")
                {
                    attached.Interact(other);
                }
            }
            /*
            if (isObstacle && temp.Role == EmployeeRole.GarbageCollector)
            {
                isObstacle = false;
                isVisible = false;
                isInteractable=false;

                Debug.Log("Llego el basurero");
            }
            else if (objectAttached != null && Dijkstra.destiny == nodeName && other.tag == "Employee")
            {
                attached.Interact(other);
            }
            else if ()
            {
                //other.GetComponent<TaskHandler>().OverrideTask();
            }*/
        }

        var temp2 = other.GetComponent<Garbage>();
        if (temp2 != null)
        {
            Debug.Log("Basura");
            isObstacle = true;
            isVisible = true;
            isInteractable = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var temp2 = other.GetComponent<Garbage>();
        if (temp2 != null)
        {
            Debug.Log("Basura");
            isObstacle = false;
            isVisible = false;
            isInteractable = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        var temp = other.GetComponent<Employee>();
        if (temp != null && isObstacle)
        {
            if (temp.Role != EmployeeRole.GarbageCollector)
            {
                other.GetComponent<TaskHandler>().Stopper();
            }
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

        if (objectAttached != null)
        {
            if (objectAttached.GetComponent<Outline>() != null)
            {
                objectAttached.GetComponent<Outline>().enabled = true;
            }
        }
    }

    private void OnMouseExit()
    {
        if (isInteractable)
        {
            UIManager.Instance.TurnOffName();
        }

        if (objectAttached != null)
        {
            if (objectAttached.GetComponent<Outline>() != null)
            {
                objectAttached.GetComponent<Outline>().enabled = false;
            }
        }
    }
}
