using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackageShelf : MonoBehaviour
{
    [SerializeField] private Package package;
    [SerializeField] private PackageTypeSO type;
    [Range(1, 20)] [SerializeField] private int amount;
    [SerializeField] private Transform placesBox;


    private CustomQueue<Package> _packageQueue = new CustomQueue<Package>();

    private void Start()
    {
        InitShelf();
    }

    private void InitShelf()
    {
        if (placesBox.childCount < 1) return;
        
        FillShelf();
    }

    private void FillShelf()
    {
        for (int i = 0; i < amount; i++)
        {
            var currentPlace = placesBox.GetChild(i);
            if(currentPlace.childCount > 1) continue;
            var newPackage = Instantiate(package, currentPlace);
            newPackage.SetData(type);
            newPackage.SetInShelf(currentPlace);
            _packageQueue.Enqueue(newPackage);
        }
    }

    private bool CanReturnPackage(Package input)
    {
        return input.Data == type;
    }

    private bool IsShelfFull()
    {
        //TODO
        return false;
    }

    public void GivePackage(Transform input)
    {
        if(_packageQueue.IsQueueEmpty()) return;

        var packageToGive = _packageQueue.Dequeue();
        
        packageToGive.transform.position = input.position;
        packageToGive.TakeOutFromShelf();
    }

    public void ReturnPackage(PackageCollector collector)
    {

        if (!CanReturnPackage(collector.PackageInHand))
        {
            Debug.Log("Could not return");
            return;
        }

        var package = collector.ReturnToShelf();
        
        if(package.Data != type) return;
        
        for (int i = 0; i < placesBox.childCount; i++)
        {
            var currentPlace = placesBox.GetChild(i);
            
            if(currentPlace.childCount > 0) continue;
            
            package.SetInShelf(currentPlace);
            _packageQueue.Enqueue(package);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(!other.TryGetComponent(out PackageCollector collector)) return;

        if (!collector.HasPackageInHand)
        {
            GivePackage(collector.transform);
            return;
        }
        
        ReturnPackage(collector);
    }
}
