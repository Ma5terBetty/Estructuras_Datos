using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorDropper : MonoBehaviour
{
    [SerializeField]
    GameObject dropPoint;
    Vector3 _dropPosition;

    private void Start()
    {
        _dropPosition = dropPoint.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        /*if (other.GetComponent<PickUpObj>() != null && other.GetComponent<PickUpObj>().GrabbedObject != null)
        {
            other.GetComponent<PickUpObj>().GrabbedObject.transform.position = _dropPosition;
            other.GetComponent<PickUpObj>().Drop();
        }*/
    }
}
