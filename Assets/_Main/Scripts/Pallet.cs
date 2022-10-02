using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pallet : MonoBehaviour
{
    Dictionary<PackageId, GameObject> stacks = new Dictionary<PackageId, GameObject>();
    public Order currentOrder;
    TestBox tempBox;
    int index = 0;

    private void Start()
    {
        OnEnable();
    }
    void CheckStacks(GameObject input)
    {
        var colorKey = input.GetComponent<Package>().Data.Id;

        if (stacks.ContainsKey(colorKey) && stacks[colorKey].GetComponent<PalletStack>().stack.Index() <= 3)
        {
            stacks[colorKey].GetComponent<PalletStack>().RecieveItem(input);
            currentOrder.Add(colorKey.ToString());
            GameManager.Instance.orderController.CheckForOrder();
            Debug.Log("La Key ya existe!");
        }
        else if (stacks.Count < 4)
        {
            stacks.Add(colorKey, transform.GetChild(index).gameObject);
            index++;
            stacks[colorKey].GetComponent<PalletStack>().RecieveItem(input);
            currentOrder.Add(colorKey.ToString());
            GameManager.Instance.orderController.CheckForOrder();

            Debug.Log("No tenía esta key!");
        }
        else
        { 
            //La nada misma
        }
    }

    private void Update()
    {
            Debug.Log(stacks.Count);
    }

    private void OnTriggerEnter(Collider other)
    {
        var package = FindChildWithTag(other.transform, "Object");

        if (package != null)
        {
            package.SetParent(package);

            CheckStacks(package.gameObject);

            other.GetComponent<PackageCollector>().Drop();
        }
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

    private void OnEnable()
    {
        GameManager.OnTruckLeaves += Reset;
    }

    private void OnDisable()
    {
        GameManager.OnTruckArrives -= Reset;
    }
}
