using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackageShelfController : MonoBehaviour
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
        var places = placesBox.childCount;
        
        if(placesBox.childCount < 1) return;

        FillShelf(amount);
    }

    public void FillShelf(int amountToFill)
    {
        for (int i = 0; i < amountToFill; i++)
        {
            var currentPlace = placesBox.GetChild(i);
            if(currentPlace.childCount > 1) continue;
            var newPackage = Instantiate(package, currentPlace);
            newPackage.SetData(type);
            newPackage.SetInShelf(currentPlace);
            _packageQueue.Enqueue(newPackage);
        }
    }

    public Package GivePackage()
    {
        if (_packageQueue.IsQueueEmpty()) return null;

        var packageToGive = _packageQueue.Dequeue();
        packageToGive.transform.SetParent(null);
        
        return packageToGive;
    }

    public bool CanReturnPackage(Package input)
    {
        return input.Data == type;
    }

    public void ReturnPackage(Package input)
    {
        if(input.Data != type) return;
        
        for (int i = 0; i < placesBox.childCount; i++)
        {
            var currentPlace = placesBox.GetChild(i);
            
            if(currentPlace.childCount > 0) continue;
            
            input.SetInShelf(currentPlace);
            _packageQueue.Enqueue(input);
        }
    }
}
