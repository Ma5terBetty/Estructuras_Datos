using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropPackage : MonoBehaviour
{
    [SerializeField] private Transform dropPosition;

    private IEnumerator CanUseAfter(Package package, float time)
    {
        yield return new WaitForSeconds(time);
        package.SetCanUse(true);
    }
    private void OnTriggerEnter(Collider other)
    {
        var packageCollector = other.GetComponent<PackageCollector>();
        if(!packageCollector) return;
        var package = packageCollector.PackageInHand;
        
        if(!package) return;
        packageCollector.Drop();
        package.gameObject.transform.position = dropPosition.position;
        StartCoroutine(CanUseAfter(package, 0.3f));
    }
}
