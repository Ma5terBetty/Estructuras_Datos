using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Package : MonoBehaviour, ISortable
{
    [SerializeField] private bool canUse = true;
    
    private Rigidbody _rigidbody;
    private Collider _collider;

    public float SortValue { get; private set; }
    public PackageTypeSO Data { get; private set; }
    public GameObject GameObject => gameObject;
    public bool CanUse => canUse;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<Collider>();
    }

    public void SetData(PackageTypeSO newData)
    {
        if (newData == null)
        {
            Debug.LogWarning("Package Data is Null");
            return;
        }

        Data = newData;
        GetComponent<MeshRenderer>().material.color = Data.Color;
    }

    public void PickUp(Transform employee, Transform hand)
    {
        if (!CanUse) return;

        _rigidbody.isKinematic = true;
        canUse = false;
        transform.position = hand.position;
        transform.rotation = employee.rotation;
        transform.SetParent(employee);
    }

    public void Drop()
    {
        canUse = true;
        _rigidbody.isKinematic = false;
        transform.SetParent(null);
    }

    public void DropInPallet()
    {
        canUse = false;
        _rigidbody.isKinematic = true;
        transform.SetParent(transform);
    }

    public void DropInPallet(Transform place)
    {
        transform.SetParent(place);
        canUse = false;
        _collider.enabled = false;
        _rigidbody.isKinematic = true;
        transform.position = place.position;
        transform.rotation = place.rotation;
    }

    public void SetInShelf(Transform place)
    {
        _rigidbody.isKinematic = true;
        transform.position = place.position;
        transform.rotation = place.rotation;
        _collider.enabled = false;
        transform.SetParent(place);
        canUse = false;
    }

    public void TakeOutFromShelf()
    {
        _collider.enabled = true;
        canUse = true;
    }

    public void SetCanUse(bool input)
    {
        canUse = input;
    }

    private void OnMouseOver()
    {
        var name = Data.Id.ToString();
        UIManager.Instance.ShowName($"{name} package");
    }

    private void OnMouseExit()
    {
        UIManager.Instance.TurnOffName();
    }
    public void SetSortValue(float value)
    {
        SortValue = value;
    }
}
