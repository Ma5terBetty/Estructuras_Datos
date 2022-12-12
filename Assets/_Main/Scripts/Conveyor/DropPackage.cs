using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropPackage : MonoBehaviour, IInteractable
{
    [SerializeField] private Transform dropPosition;

    public void Interact(Collider other)
    {
        var packageCollector = other.GetComponent<PackageCollector>();
        if (!packageCollector) return;
        if (!packageCollector.HasPackageInHand) return;
        
        var package = packageCollector.PackageInHand;

        packageCollector.DropInConveyor(dropPosition);
    }

    private IEnumerator CanUseAfter(Package package, float time)
    {
        yield return new WaitForSeconds(time);
        //package.SetCanInteract(true);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        
    }
}
