using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PackageCollector : MonoBehaviour
{
    [SerializeField] private Transform hand;

    Animator _anim;

    private float _timeToInteract = .5f;
    
    public bool CanInteract { get; private set; }
    public Package PackageInHand { get; private set; }
    public bool HasPackageInHand => PackageInHand != null;
    public UnityAction OnPackageChange;

    private void Awake()
    {
        OnPackageChange += OnPackageChangeHandler;
        _anim = GetComponent<Animator>();
        CanInteract = true;
    }

    public void PickUpPackage(Package input)
    {
        if (!CanInteract) return;
        if (HasPackageInHand) return;

        StartCoroutine(DisableInteraction());
        PackageInHand = input;
        if(PackageInHand)
            PackageInHand.PickUp(transform,hand);
        OnPackageChange?.Invoke();
        _anim.SetBool("IsBoxed", true);
    }

    public void DropPackage()
    {
        if (!CanInteract) return;
        if (!HasPackageInHand) return;
        
        PackageInHand.Drop();
        PackageInHand = null;
        OnPackageChange?.Invoke();
        _anim.SetBool("IsBoxed", false);
    }

    public Package ReturnToShelf()
    {
        var packageToReturn = PackageInHand;
        PackageInHand = null;
        OnPackageChange?.Invoke();
        _anim.SetBool("IsBoxed", false);
        return packageToReturn;
    }

    public void DropInPallet()
    {
        if (!HasPackageInHand) return;
        _anim.SetBool("IsBoxed", false);
        //PackageInHand.DropInPallet();
        PackageInHand = null;
        OnPackageChange?.Invoke();
    }

    public void ClearHand()
    {
        PackageInHand = null;
        _anim.SetBool("IsBoxed", false);
        OnPackageChange?.Invoke();
    }

    private void OnPackageChangeHandler()
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

        if (!HasPackageInHand)
        {
            _anim.SetBool("IsBoxed", true);
            PickUpPackage(package);
        }
        
    }
}
