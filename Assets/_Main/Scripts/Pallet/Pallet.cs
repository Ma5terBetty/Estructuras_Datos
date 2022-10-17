using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Pallet : MonoBehaviour
{
    [SerializeField] private PackageId stacksColor;
    
    Dictionary<PackageId, GameObject> stacks = new Dictionary<PackageId, GameObject>();
    Dictionary<PackageId, PalletStack> palletStacks = new Dictionary<PackageId, PalletStack>();
    public Order currentOrder;
    TestBox tempBox;
    int index = 0;
    public UnityAction<PalletStack> OnStackChange;

    private void Start()
    {
        Suscribe();
        stacks = new Dictionary<PackageId, GameObject>();
        index = 0;
        
        InitPalletStack();
    }
    
    private bool CheckStacks(GameObject input)
    {
        var colorKey = input.GetComponent<Package>().Data.Id;

        if (stacks.ContainsKey(colorKey) && stacks[colorKey].GetComponent<PalletStack>().stack.Index() <= 3)
        {
            stacks[colorKey].GetComponent<PalletStack>().RecieveItem(input);
            currentOrder.Add(colorKey.ToString());
            GameManager.Instance.OrderController.CheckForOrder();
            Debug.Log("La Key ya existe!");
            return true;
        }
        else if (stacks.Count < 4)
        {
            stacks.Add(colorKey, transform.GetChild(index).gameObject);
            index++;
            stacks[colorKey].GetComponent<PalletStack>().RecieveItem(input);
            currentOrder.Add(colorKey.ToString());
            GameManager.Instance.OrderController.CheckForOrder();

            Debug.Log("No ten�a esta key!");
            return true;
        }
        
        return false;
    }


    private bool CheckStack2(Package input)
    {
        var packageColor = input.Data.Id;

        if (!palletStacks.TryGetValue(packageColor, out var stack)) return false;

        if (stack.StackAmount == 4) return false;
        
        stack.RecieveItem(input);
        GameManager.Instance.OrderController.CheckForOrder();
        OnStackChange?.Invoke(stack);

        return true;
        
    }

    private void Update()
    {
        //Debug.Log(stacks.Count);
    }

    /*private void OnTriggerEnter(Collider other)
    {
        var package = FindChildWithTag(other.transform, "Object");

        if (package != null)
        {
            package.SetParent(package);

            if (!CheckStacks(package.gameObject)) return;
            
            other.GetComponent<PackageCollector>().DropInPallet();


        }
    }*/

    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent(out PackageCollector collector)) return;

        if (!collector.HasPackageInHand) return;
        
        if(!CheckStack2(collector.PackageInHand)) return;
        
        collector.ClearHand();
    }

    public void Reset()
    {
        var packages = GetComponentsInChildren<Package>();

        for (int i = 0; i < packages.Length; i++)
        {
            Destroy(packages[i].gameObject);
            stacks.Clear();
        }

        index = 0;
        currentOrder = new Order();

        Debug.Log("stacks reseteados");
        Debug.Log(stacks.Count);
    }

    Transform FindChildWithTag(Transform parent, string tag)
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
        currentOrder.UpdateAmounts(stack.Color, stack.StackAmount);
    }

    private void InitPalletStack()
    {
        for (int i = 0; i < 4; i++)
        {
            
            var stack = transform.GetChild(i).GetComponent<PalletStack>();
            var color = (PackageId)Enum.GetValues(stacksColor.GetType()).GetValue(i);

            palletStacks.Add(color, stack);
            stack.SetValues(color);
        }
        
        OnStackChange += OnStackChangeHandler;
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
}
