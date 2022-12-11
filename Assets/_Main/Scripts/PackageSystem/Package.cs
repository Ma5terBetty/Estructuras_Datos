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

    private const float ChangeStateTime = 0.75f;

    public float SortValue { get; private set; }
    public GameObject GameObject => gameObject;

    public PackageTypeSO Data { get; private set; }

    //Test
    public enum PackageState
    {
        InHand,
        Placed,
        Dropped
    }

    public PackageState CurrentState { get; private set; }


    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<Collider>();

        CurrentState = PackageState.Dropped;
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

    public virtual void PickUp(Transform employee, Transform hand)
    {
        if (CurrentState == PackageState.InHand) return;
        
        _rigidbody.isKinematic = true;
        transform.position = hand.position;
        transform.rotation = employee.rotation;
        transform.SetParent(employee);
        StartCoroutine(ChangeState(PackageState.InHand));
    }

    public void Drop()
    {
        if (CurrentState != PackageState.InHand) return;
        
        _rigidbody.isKinematic = false;
        transform.SetParent(null);
        StartCoroutine(ChangeState(PackageState.Dropped));
    }

    public void DropInPallet(Transform place)
    {
        if (CurrentState != PackageState.InHand) return;
        
        transform.SetParent(place);
        _collider.enabled = false;
        _rigidbody.isKinematic = true;
        transform.position = place.position;
        transform.rotation = place.rotation;
        StartCoroutine(ChangeState(PackageState.Placed));

    }

    public void SetInShelf(Transform place)
    {
        if (CurrentState == PackageState.Placed) return;
        
        _rigidbody.isKinematic = true;
        transform.position = place.position;
        transform.rotation = place.rotation;
        _collider.enabled = false;
        transform.SetParent(place);
        StartCoroutine(ChangeState(PackageState.Placed));
    }
    

    public void TakeOutFromShelf()
    {
        _collider.enabled = true;
    }

    public void SetSortValue(float value)
    {
        SortValue = value;
    }
    
    private void SetState(PackageState newState)
    {
        CurrentState = newState;
        Debug.Log($"Package State: {CurrentState}");
    }
    
    private IEnumerator ChangeState(PackageState newState)
    {
        yield return new WaitForSeconds(ChangeStateTime);
        SetState(newState);
        yield return null;
    }

    protected virtual void OnMouseOver()
    {
        var name = Data.Id.ToString();
        UIManager.Instance.ShowName($"{name} package");
    }

    private void OnMouseExit()
    {
        UIManager.Instance.TurnOffName();
    }
}
