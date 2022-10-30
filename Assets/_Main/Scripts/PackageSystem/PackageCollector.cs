using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PackageCollector : MonoBehaviour
{
    [SerializeField] private Transform hand;

    public Package PackageInHand { get; private set; }
    public bool HasPackageInHand => PackageInHand != null;
    public UnityAction OnPackageChange;

    public void PickUpPackage(Package input)
    {
        if (HasPackageInHand) return;

        PackageInHand = input;
        if(PackageInHand)
            PackageInHand.PickUp(transform,hand);
        OnPackageChange?.Invoke();
    }

    public void DropPackage()
    {
        if (!HasPackageInHand) return;
        
        PackageInHand.Drop();
        PackageInHand = null;
        OnPackageChange?.Invoke();
    }

    public Package ReturnToShelf()
    {
        var packageToReturn = PackageInHand;
        PackageInHand = null;
        OnPackageChange?.Invoke();
        
        return packageToReturn;
    }

    public void DropInPallet()
    {
        if (!HasPackageInHand) return;
        
        //PackageInHand.DropInPallet();
        PackageInHand = null;
        OnPackageChange?.Invoke();
    }

    public void ClearHand()
    {
        PackageInHand = null;
        OnPackageChange?.Invoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent(out Package package)) return;
        
        if(!HasPackageInHand)
            PickUpPackage(package);
    }
}
