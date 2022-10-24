using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PalletStack : MonoBehaviour
{
    private Pallet _pallet;
    public CustomStack<Package> PackageStack { get; private set; } 
    public PackageId StackColor { get; private set; }
    public Transform[] Positions { get; private set; }
    public int StackAmount { get; private set; }
    public string Color => StackColor.ToString();
    

    private void Awake()
    {
        _pallet = transform.parent.GetComponent<Pallet>();
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        GetChildTransforms();

        if (PackageStack == null) PackageStack = new CustomStack<Package>();
        PackageStack.Initialize(transform.childCount);
        Suscribe();
    }
    
    public void SetValues(PackageId newColor)
    {
        StackColor = newColor;
    }

    public void ReceiveItem(Package input)
    {
        input.DropInPallet(Positions[PackageStack.Index()]);
        AddItem(input);
        Debug.Log("Package Left In Pallet");
    }

    private void AddItem(Package input)
    {
        PackageStack.Push(input);
        StackAmount++;
    }

    private Package RemoveItem()
    {
        StackAmount--;
        return PackageStack.Pop();
    }

    public void RemovePackage(PackageCollector collector)
    {
        if (PackageStack.IsStackEmpty()) return;

        var package = RemoveItem().GetComponent<Package>();
        
        package.TakeOutFromShelf();
        collector.PickUpPackage(package);
        _pallet.OnStackChange.Invoke(this);
        Debug.Log("Package Taken From Pallet");
    }

    private void GetChildTransforms()
    {
        Positions = new Transform[transform.childCount];
        for (int i = 0; i < Positions.Length; i++)
        {
            Positions[i] = transform.GetChild(i);
        }
    }

    public void RestartStacks()
    {
        PackageStack.Initialize(transform.childCount);
        StackAmount = 0;
    }

    public void ClearStack()
    {
        if (transform.childCount == 0) return;

        var packages = GetComponentsInChildren<Package>();
        
        for (int i = 0; i < packages.Length; i++)
        {
            Destroy(packages[i].gameObject);
        }
        
        PackageStack.Initialize(transform.childCount);
        StackAmount = 0;
    }

    private void Suscribe()
    {
        if (PackageStack != null) //Debug.Log("NO ES NULO");
       GameManager.OnTruckArrives += RestartStacks; 
        GameManager.OnChangedScene += Unsuscribe;
    }

    private void Unsuscribe()
    {
        GameManager.OnTruckArrives -= RestartStacks;
    }
}
