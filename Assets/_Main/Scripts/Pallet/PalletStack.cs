using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PalletStack : MonoBehaviour
{
    private Pallet _pallet;
    public PackageId StackColor { get; private set; }
    public Transform[] Positions { get; private set; }
    public CustomStack<GameObject> stack = new CustomStack<GameObject>();
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

        if (stack == null) stack = new CustomStack<GameObject>();
        stack.Initialize(transform.childCount);
        Suscribe();
    }

    public void SetValues(PackageId newColor)
    {
        StackColor = newColor;
    }

    public void RecieveItem(Package input)
    {
        input.DropInPallet(Positions[stack.Index()]);
        stack.Push(input.gameObject);
        StackAmount++;
        Debug.Log("Package Left In Pallet");
    }

    private GameObject RemoveItem()
    {
        StackAmount--;
        return stack.Pop();
    }

    public void RemovePackage(PackageCollector collector)
    {
        if (stack.IsStackEmpty()) return;

        var package = RemoveItem().GetComponent<Package>();
        
        package.TakeOutFromShelf();
        collector.PickUpPackage(package);
        _pallet.OnStackChange.Invoke(this);
        Debug.Log("Package Taken From Pallet");
    }

    void GetChildTransforms()
    {
        Positions = new Transform[transform.childCount];
        for (int i = 0; i < Positions.Length; i++)
        {
            Positions[i] = transform.GetChild(i);
        }
    }

    public void RestartStacks()
    {
        stack.Initialize(transform.childCount);
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
        
        stack.Initialize(transform.childCount);
        StackAmount = 0;
    }

    private void Suscribe()
    {
        if (stack != null) //Debug.Log("NO ES NULO");
       GameManager.OnTruckArrives += RestartStacks; 
        GameManager.OnChangedScene += Unsuscribe;
    }

    private void Unsuscribe()
    {
        GameManager.OnTruckArrives -= RestartStacks;
    }
}
