using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PickUpObj : MonoBehaviour
{
    private GameObject _tempObject = null;

    [SerializeField] private Transform _hand;
    public GameObject GrabbedObject { get; private set; }
    public UnityAction OnPackageChange;
    

    public void PickUp(Collider other)
    {
        if (GrabbedObject) return;
        if(!other.GetComponent<Package>().CanUse) return;
        GrabbedObject = other.gameObject;
        GrabbedObject.GetComponent<Package>().SetCanUse(false);
        GrabbedObject.GetComponent<Rigidbody>().isKinematic = true;
        GrabbedObject.transform.position = _hand.position;
        GrabbedObject.transform.rotation = transform.rotation;
        GrabbedObject.transform.SetParent(transform);
        //ObjGrabbed = false;
        OnPackageChange.Invoke();
    }
    
    /*public void PickUp(Collider other)
    {
        if (GrabbedObject) return;

        GrabbedObject = other.gameObject;
        GrabbedObject.GetComponent<Package>().PickUp(transform,_hand);
        OnPackageChange.Invoke();
    }
    
    public void Drop()
    {
        if (!GrabbedObject) return;
        
        GrabbedObject.GetComponent<Package>().Drop();
        GrabbedObject = _tempObject;
        OnPackageChange.Invoke();
    }*/

    public void Drop()
    {
        if (!GrabbedObject) return;
        
        //_grabbedObject.GetComponent<Rigidbody>().useGravity = true;
        GrabbedObject.GetComponent<Rigidbody>().isKinematic = false;
        //_grabbedObject.transform.SetParent(null);
        GrabbedObject = _tempObject;
        OnPackageChange.Invoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Object"))
        {
            PickUp(other);
        }
    }
}
