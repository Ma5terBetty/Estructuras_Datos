using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Package : MonoBehaviour, ISortable
{
    [SerializeField] private bool canUse = true;
    
    private Rigidbody _rigidbody;
    private Collider _collider;
    private ISortable _sortableImplementation;
    
    private const float TimeDisable = 0.75f;

    public float SortValue { get; private set; }
    public GameObject GameObject => gameObject;

    public PackageTypeSO Data { get; private set; }
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

        StartCoroutine(DisablePackage());
        _rigidbody.isKinematic = true;
        transform.position = hand.position;
        transform.rotation = employee.rotation;
        transform.SetParent(employee);
    }

    public void Drop()
    {
        if (!CanUse) return;
        
        StartCoroutine(DisablePackage());
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
        if (!CanUse) return;
        
        StartCoroutine(DisablePackage());
        transform.SetParent(place);
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
        StartCoroutine(DisablePackage());
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
    
    public void SetSortValue(float value)
    {
        SortValue = value;
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

    private IEnumerator DisablePackage()
    {
        canUse = false;
        yield return new WaitForSeconds(TimeDisable);
        canUse = true;
        yield return null;
    }
}
