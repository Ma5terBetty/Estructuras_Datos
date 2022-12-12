using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PackageCollector : MonoBehaviour
{
    private EmployeeSO _stats;
    private float _timeToInteract = .5f;
    [SerializeField] private Transform hand;
    public bool CanInteract { get; private set; }
    public Package PackageInHand { get; private set; }
    public bool HasPackageInHand => PackageInHand != null;
    public UnityAction<bool> OnPackageChange;

    private void Awake()
    {
        OnPackageChange += OnPackageChangeHandler;
        CanInteract = true;
        _stats = GetComponent<Employee>().GetData();
    }

    public void PickUpPackage(Package input)
    {
        if (!CanInteract) return;
        if (input.Data.Id == PackageId.garbage && _stats.Role != EmployeeRole.GarbageCollector) return;
        if (HasPackageInHand) return;

        StartCoroutine(DisableInteraction());
        PackageInHand = input;
        if(PackageInHand)
            PackageInHand.PickUp(transform,hand);
        OnPackageChange?.Invoke(true);
    }

    public void DropPackage()
    {
        if (!CanInteract) return;
        if (!HasPackageInHand) return;
        
        PackageInHand.Drop();
        PackageInHand = null;
        OnPackageChange?.Invoke(false);
    }

    public Package ReturnToShelf()
    {
        var packageToReturn = PackageInHand;
        PackageInHand = null;
        OnPackageChange?.Invoke(false);
        
        return packageToReturn;
    }

    public void DropInPallet()
    {
        if (!HasPackageInHand) return;
        
        //PackageInHand.DropInPallet();
        PackageInHand = null;
        OnPackageChange?.Invoke(false);
    }

    public void ClearHand()
    {
        PackageInHand = null;
        OnPackageChange?.Invoke(false);
    }

    private void OnPackageChangeHandler(bool hasPackage)
    {
        StartCoroutine(DisableInteraction());
    }

    private IEnumerator DisableInteraction()
    {
        CanInteract = false;
        yield return new WaitForSeconds(_timeToInteract);
        CanInteract = true;
        yield return null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent(out Package package)) return;

        if (package.CurrentState == Package.PackageState.InHand) return;
        
        if(!HasPackageInHand)
            PickUpPackage(package);
    }
}
