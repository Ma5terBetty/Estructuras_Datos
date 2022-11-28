using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Pallet : MonoBehaviour, IInteractable
{
    private readonly PackageId _stacksColor;
    private Dictionary<PackageId, PalletStack> _palletStacks = new Dictionary<PackageId, PalletStack>();
    private int _index = 0;
    private GameObject[] _stacksTest;
    private readonly CustomStack<PackageId> _lastIDStack = new CustomStack<PackageId>();
    public Order CurrentOrder { get; private set; }

    public UnityAction<PalletStack> OnStackChange;
    
    private void Start()
    {
        Suscribe();
        InitPalletStack();
    }

    private bool CheckStack(Package input)
    {
        var packageColor = input.Data.Id;

        if (!_palletStacks.TryGetValue(packageColor, out var stack)) return false;

        if (stack.StackAmount == 4) return false;
        
        stack.ReceiveItem(input);
        _lastIDStack.Push(input.Data.Id);
        OnStackChange?.Invoke(stack);

        return true;
    }

    public void Reset()
    {
        foreach (var stacks in _palletStacks.Values)
        {
            stacks.ClearStack();
        }
        
        _lastIDStack.Initialize();
        _index = 0;
        CurrentOrder = new Order();

        //Debug.Log("stacks reseteados");
    }

    private Transform FindChildWithTag(Transform parent, string tag)
    {
        Transform tempParent = parent;
        foreach (Transform tr in tempParent)
        {
            if (tr.tag == tag)
            { 
                return tr.GetComponent<Transform>();
            }
        }
        return null;
    }

    private void OnStackChangeHandler(PalletStack stack)
    {
        CurrentOrder.UpdateAmounts(stack.Color, stack.StackAmount);
        GameManager.Instance.OrderController.CheckForOrder();
    }

    private void InitPalletStack()
    {
        for (int i = 0; i < 4; i++)
        {
            
            var stack = transform.GetChild(i).GetComponent<PalletStack>();
            var color = (PackageId)Enum.GetValues(_stacksColor.GetType()).GetValue(i);

            _palletStacks.Add(color, stack);
            stack.SetValues(color);
        }
        
        OnStackChange += OnStackChangeHandler;
    }
    
    private void GetClosestStack(Transform employee, out PalletStack closeStack)
    {
        var minDistance = Mathf.Infinity;
        closeStack = null;

        foreach (var currentStack in _palletStacks.Values)
        {
            var distance = Vector3.Distance(currentStack.transform.position, employee.position);
            if(distance > minDistance) continue;

            minDistance = distance;
            closeStack = currentStack;
        }
    }

    private void GetLastPackage(PackageCollector collector)
    {
        var id = _lastIDStack.Pop();
        
        foreach (var _stacks in _palletStacks)
        {
            if(_stacks.Key != id) continue;
            
            Debug.Log($"Last Package ID: {_stacks.Key}");
            _stacks.Value.RemovePackage(collector);
        }
    }

    private void Suscribe()
    {
        GameManager.OnTruckArrives += Reset;
        GameManager.OnChangedScene += Unsucribe;
    }

    private void Unsucribe()
    {
        GameManager.OnTruckArrives -= Reset;
    }

    public void Interact(Collider other)
    {
        if (!other.TryGetComponent(out PackageCollector collector)) return;

        if (collector.HasPackageInHand)
        {
            if (!CheckStack(collector.PackageInHand)) return;
            collector.ClearHand();
        }
        else
        {
            if (_lastIDStack.IsStackEmpty()) return;
            GetLastPackage(collector);
            /*GetClosestStack(collector.transform, out var stack);
            if (stack == null) return;
            stack.RemovePackage(collector);*/
        }
    }
    /*private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent(out PackageCollector collector)) return;

        if (collector.HasPackageInHand)
        {
            if(!CheckStack(collector.PackageInHand)) return;
            collector.ClearHand();
        }
        else
        {
            if (_lastIDStack.IsStackEmpty()) return;
            GetLastPackage(collector);
            /*GetClosestStack(collector.transform, out var stack);
            if (stack == null) return;
            stack.RemovePackage(collector);*/
}
