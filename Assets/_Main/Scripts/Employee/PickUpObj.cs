using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObj : MonoBehaviour
{
    private GameObject _tempObject = null;

    [SerializeField] private Transform _hand;
    public GameObject GrabbedObject { get; private set; }
    

    public void PickUp(Collider other)
    {
        if (GrabbedObject) return;
        GrabbedObject = other.gameObject;
        GrabbedObject.GetComponent<Rigidbody>().isKinematic = true;
        GrabbedObject.transform.position = _hand.position;
        GrabbedObject.transform.rotation = transform.rotation;
        GrabbedObject.transform.SetParent(transform);
        //ObjGrabbed = false;
    }

    public void Drop()
    {
        if (!GrabbedObject) return;
        //_grabbedObject.GetComponent<Rigidbody>().useGravity = true;
        GrabbedObject.GetComponent<Rigidbody>().isKinematic = false;
        //_grabbedObject.transform.SetParent(null);
        GrabbedObject = _tempObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Object"))
        {
            PickUp(other);
        }
    }
}
