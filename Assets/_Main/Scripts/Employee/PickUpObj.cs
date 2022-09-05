using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObj : MonoBehaviour
{
    private GameObject _grabbedObject;
    private GameObject _tempObject = null;

    [SerializeField] private Transform _hand;

    [SerializeField] private float _radius = 1f;
    [SerializeField] private float _offsetY = .7f;

    [SerializeField] private LayerMask _layerIndex;

    [SerializeField] protected Collider[] _hitColliders;

    public void PickUp(Collider other)
    {
        if (_grabbedObject != null) return;
        _grabbedObject = other.gameObject;
        _grabbedObject.GetComponent<Rigidbody>().isKinematic = true;
        _grabbedObject.transform.position = _hand.position;
        _grabbedObject.transform.rotation = transform.rotation;
        _grabbedObject.transform.SetParent(transform);
    }

    public void Drop()
    {
        if (_grabbedObject == null) return;
        //_grabbedObject.GetComponent<Rigidbody>().useGravity = true;
        _grabbedObject.GetComponent<Rigidbody>().isKinematic = false;
        //_grabbedObject.transform.SetParent(null);
        _grabbedObject = _tempObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Object"))
        {
            PickUp(other);
        }
    }
}
