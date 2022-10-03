using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Package : MonoBehaviour
{
    private Rigidbody _rigidbody;
    [SerializeField] private bool _canUse = true;

    public PackageTypeSO Data { get; private set; }
    public bool CanUse => _canUse;


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void SetData(PackageTypeSO newData)
    {
        if(newData == null) return;

        Data = newData;
        GetComponent<MeshRenderer>().material.color = Data.Color;
    }
    
    public void PickUp(Transform employee, Transform hand)
    {
        if(!_canUse) return;
        
        _rigidbody.isKinematic = true;
        transform.position = hand.position;
        transform.rotation = employee.rotation;
        transform.SetParent(employee);
    }

    public void Drop()
    {
        _rigidbody.isKinematic = false;
        _canUse = false;
    }

    public void SetInShelf(Transform place)
    {
        _rigidbody.isKinematic = true;
        transform.position = place.position;
        transform.rotation = place.rotation;
        transform.SetParent(place);
    }

    public void SetCanUse(bool input) => _canUse = input;

    private void OnMouseOver()
    {
        var name = Data.Id.ToString();
        UIManager.Instance.ShowName($"{name} package");
    }

    private void OnMouseExit()
    {
        UIManager.Instance.TurnOffName();
    }
}
