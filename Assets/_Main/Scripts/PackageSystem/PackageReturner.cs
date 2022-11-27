using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class PackageReturner : MonoBehaviour
{
    [SerializeField] private PackageShelf[] shelves;
    [SerializeField] private float timeToReturn = 3;
    [SerializeField] private Transform place;
    
    private CustomQueue<Package> _returnedPackages;

    public UnityAction OnPackageReturned;

    private void Awake()
    {
        _returnedPackages = new CustomQueue<Package>();

        OnPackageReturned += OnPackageReturnedHandler;
    }

    private void ReturnPackage(Package package)
    {
        if (shelves.Length == 0) return;
        
        foreach (var shelf in shelves)
        {
            if(shelf.ShelfType != package.Data) continue;
            
            shelf.ReturnPackage(package);
        }
    }

    public void GetPackage(PackageCollector collector)
    {
        var package = collector.PackageInHand;
        collector.DropPackage();
        package.transform.position = place.position;
        _returnedPackages.Enqueue(package);
        OnPackageReturned?.Invoke();
    }

    private IEnumerator ReturnToShelf()
    {
        yield return new WaitForSeconds(timeToReturn);
        
        var packageToReturn = _returnedPackages.Dequeue();
        ReturnPackage(packageToReturn);

        yield return null;
    }

    private void OnPackageReturnedHandler()
    {
        StartCoroutine(ReturnToShelf());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent(out PackageCollector collector)) return;

        if (collector.HasPackageInHand)
        {
            GetPackage(collector);
        }
    }
}
