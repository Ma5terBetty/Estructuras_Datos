using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem.Controls;

public class PackageCollector : MonoBehaviour
{
    [SerializeField] private Transform hand;
    
    public Package PackageInHand { get; private set; }
    public bool HasPackageInHand => PackageInHand != null;
    public UnityAction OnPackageChange;
    
    public void TakeFromShelf(PackageShelfController shelf)
    {
        Debug.Log("Taking From Shelf");
        if (HasPackageInHand) return;

        PackageInHand = shelf.GivePackage();
        if(PackageInHand)
            PackageInHand.PickUp(transform, hand);
        OnPackageChange?.Invoke();
    }

    public void PickUp(Package package)
    {
        Debug.Log("Picking Up");
        if (HasPackageInHand) return;
        
        PackageInHand = package;
        if(PackageInHand)
            PackageInHand.PickUp(transform, hand);
        OnPackageChange?.Invoke();
    }

    public void Drop(bool canUse = true)
    {
        if(!HasPackageInHand) return;
        
        Debug.Log("Package Droped");

        PackageInHand.transform.SetParent(null);
        PackageInHand.Drop(canUse);
        PackageInHand = null;
        OnPackageChange?.Invoke();
    }

    public void SaveInShelf(PackageShelfController shelf)
    {
        if(!HasPackageInHand) return;

        if (!shelf.CanReturnPackage(PackageInHand)) return;
        Debug.Log("Saving");
        
        shelf.ReturnPackage(PackageInHand);
        PackageInHand = null;
        OnPackageChange?.Invoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Shelf"))
        {
            var shelf = other.transform.parent.GetComponent<PackageShelfController>();
            
            if(!HasPackageInHand)
                TakeFromShelf(shelf);
            else
                SaveInShelf(shelf);
        }
        else if (other.gameObject.CompareTag("Object"))
        {
            if(!HasPackageInHand)
                PickUp(other.GetComponent<Package>());
        }
    }
}
