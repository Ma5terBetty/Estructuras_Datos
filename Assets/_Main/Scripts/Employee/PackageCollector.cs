using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem.Controls;

public class PackageCollector : MonoBehaviour
{
    [SerializeField] private Transform hand;
    
    public Package PackageInHand { get; private set; }
    public bool HasPackageInHand => PackageInHand != null;
    public UnityAction OnPackageChange;

    public void PickUp(PackageShelfController shelf)
    {
        if (HasPackageInHand || shelf == null) return;

        PackageInHand = shelf.GivePackage();
        if(PackageInHand)
            PackageInHand.PickUp(transform, hand);
        OnPackageChange?.Invoke();
    }

    public void PickUp(Package package)
    {
        if (HasPackageInHand || package == null) return;
        
        PackageInHand = package;
        if(PackageInHand)
            PackageInHand.PickUp(transform, hand);
        OnPackageChange?.Invoke();
    }

    public void Drop(bool canUse = true)
    {
        if(!HasPackageInHand) return;
        
        PackageInHand.Drop(canUse);
        PackageInHand = null;
        OnPackageChange?.Invoke();
    }

    public void Save(Collider other)
    {
        if(!HasPackageInHand) return;
        
        other.transform.parent.GetComponent<PackageShelfController>().ReturnPackage(PackageInHand);
        PackageInHand = null;
        
        OnPackageChange?.Invoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Shelf"))
        {
            if(!HasPackageInHand)
                PickUp(other.GetComponent<PackageShelfController>());
            else
                Save(other);
        }
        else if (other.gameObject.CompareTag("Object"))
        {
            if(!HasPackageInHand)
                PickUp(other.GetComponent<Package>());
        }
    }
}
