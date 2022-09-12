using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pallet : MonoBehaviour
{
    Dictionary<Colors, GameObject> stacks = new Dictionary<Colors, GameObject>();

    int index = 0;

    TestBox tempBox;
    Order currentOrder = new Order();

    private void Start()
    {
        OrdersManager.Instance.pallets.Add(this);
    }

    void CheckStacks(GameObject input)
    {
        var package = input.GetComponent<Package>();
        var colorKey = package.Data.PackageColor;

        if (stacks.ContainsKey(colorKey) && stacks[colorKey].GetComponent<PalletStack>().stack.Index() <= 3)
        {
            stacks[colorKey].GetComponent<PalletStack>().RecieveItem(input);
            currentOrder.Add(package.ColorName);
            CheckOrders();
        }
        else if (stacks.Count < 4)
        {
            stacks.Add(colorKey, transform.GetChild(index).gameObject);
            index++;
            stacks[colorKey].GetComponent<PalletStack>().RecieveItem(input);
            currentOrder.Add(package.ColorName);
            CheckOrders();
        }
        else
        {
            //Pallet lleno
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        var package = FindChildWithTag(other.transform, "Object");

        if (package != null)
        {
            package.SetParent(package);

            CheckStacks(package.gameObject);

            other.GetComponent<PickUpObj>().Drop();
        }
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

    void CheckOrders()
    {
        var orders = OrdersManager.Instance.currentOrders;

        for (int i = 0; i < orders.Count; i++)
        {
            if (currentOrder.redAmount == orders[i].redAmount &&
                currentOrder.blueAmount == orders[i].blueAmount &&
                currentOrder.greenAmount == orders[i].greenAmount &&
                currentOrder.yellowAmount == orders[i].yellowAmount)
            {
                Debug.Log("OrderCompleted");
                OrdersManager.Instance.DepartPallet(this, currentOrder);
            }
        }
    }
}
