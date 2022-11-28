using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackageShelf : MonoBehaviour, IInteractable
{
    [SerializeField] private Package package;
    [SerializeField] private PackageTypeSO type;
    [Range(1, 20)] [SerializeField] private int amount;
    [SerializeField] private Transform placesBox;

    private List<ISortable> _packagesList;
    public PackageTypeSO ShelfType => type;

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
        _packagesList = new List<ISortable>(amount);
        
        for (int i = 0; i < amount; i++)
        {
            var currentPlace = placesBox.GetChild(i);
            if(currentPlace.childCount > 1) continue;
            var newPackage = Instantiate(package, currentPlace);
            newPackage.SetData(type);
            newPackage.SetInShelf(currentPlace);
            _packagesList.Add(newPackage);
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
        if(_packagesList.Count == 0) return;

        var packageToGive = (Package)_packagesList[0];
        _packagesList.RemoveAt(0);

        packageToGive.transform.position = input.position;
        packageToGive.TakeOutFromShelf();
    }

    public void ReturnPackage(Package package)
    {
        if(package.Data != type) return;
        
        for (int i = 0; i < placesBox.childCount; i++)
        {
            var currentPlace = placesBox.GetChild(i);
            
            if(currentPlace.childCount > 0) continue;
            
            package.SetInShelf(currentPlace);
            _packagesList.Add((ISortable)package);
        }
    }

    public void Interact(Collider other)
    {
        if (!other.TryGetComponent(out PackageCollector collector)) return;

        if (!collector.HasPackageInHand)
        {
            GivePackage(collector.transform);
            return;
        }

        //ReturnPackage(collector);
    }

    /*private void OnTriggerEnter(Collider other)
    {
        
        if(!other.TryGetComponent(out PackageCollector collector)) return;

        if (!collector.HasPackageInHand)
        {
            GivePackage(collector.transform);
            return;
        }
        
        //ReturnPackage(collector);
    }
    */
    private void OnMouseOver()
    {
        UIManager.Instance.ShowName(type.name);
    }

    private void OnMouseExit()
    {
        UIManager.Instance.TurnOffName();
    }
}
