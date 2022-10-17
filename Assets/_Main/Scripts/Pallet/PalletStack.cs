using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PalletStack : MonoBehaviour
{
    public PackageId StackColor { get; private set; }

    public string color;
    public Transform[] positions;
    public CustomStack<GameObject> stack = new CustomStack<GameObject>();

    public bool IsShowingNames;
    public int StackAmount { get; private set; }
    public string Color => StackColor.ToString();
    
    //Test
    private float maxTime = 2f;

    private void Awake()
    {
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
        input.DropInPallet(positions[stack.Index()]);
        stack.Push(input.gameObject);
        StackAmount++;
        Debug.Log("Package Left In Pallet");
    }

    public void RecieveItem(GameObject input)
    {
        input.gameObject.transform.SetParent(positions[stack.Index()]);
        input.transform.position = input.transform.parent.position;
        input.transform.rotation = new Quaternion(0,0,0,0);
        stack.Push(input);
    }

    GameObject RemoveItem()
    {
        StackAmount--;
        transform.parent.GetComponent<Pallet>().OnStackChange?.Invoke(this);
        return stack.Pop();
    }

    private void RemovePackage(PackageCollector collector)
    {
        if (collector == null) return;

        var package = RemoveItem().GetComponent<Package>();
        
        package.TakeOutFromShelf();
        collector.PickUpPackage(package);
        Debug.Log("Package Taken From Pallet");
    }

    void GetChildTransforms()
    {
        positions = new Transform[transform.childCount];
        for (int i = 0; i < positions.Length; i++)
        {
            positions[i] = transform.GetChild(i);
        }
    }

    public void RestartStacks()
    {
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

    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent(out PackageCollector collector)) return;

        if (collector.HasPackageInHand) return;

        if (stack.IsStackEmpty()) return;
        
        RemovePackage(collector);
    }
}
