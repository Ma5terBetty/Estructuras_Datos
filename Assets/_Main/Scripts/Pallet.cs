using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pallet : MonoBehaviour
{
    Dictionary<PackageId, GameObject> stacks = new Dictionary<PackageId, GameObject>();

    int index = 0;

    TestBox tempBox;

    private void Start()
    {
        
    }

    void CheckStacks(GameObject input)
    {
        var colorKey = input.GetComponent<Package>().Data.Id;

        if (stacks.ContainsKey(colorKey) && stacks[colorKey].GetComponent<PalletStack>().stack.Index() <= 3)
        {
            stacks[colorKey].GetComponent<PalletStack>().RecieveItem(input);
        }
        else if (stacks.Count < 4)
        {
            stacks.Add(colorKey, transform.GetChild(index).gameObject);
            index++;
            stacks[colorKey].GetComponent<PalletStack>().RecieveItem(input);
        }
        else
        { 
            //Pallet lleno
        }

    }
    void AssignStack()
    { 
    
    }
    void AddToStack()
    { 
        
    }

    private void OnTriggerEnter(Collider other)
    {
        /*
        if (other.GetComponent<TestBox>() != null)
        { 
            tempBox = other.GetComponent<TestBox>();

            if (tempBox.IsPickuble)
            { 
                tempBox.IsPickuble = false;
                CheckStacks(other.gameObject);
            }
        }*/

        var package = FindChildWithTag(other.transform, "Object");

        if (package != null)
        {
            package.SetParent(package);

            CheckStacks(package.gameObject);

            other.GetComponent<PickUpObj>().Drop();
        }
        /*
        if (other.transform.GetChild(2) != null);
        {
            
            CheckStacks(other.transform.GetChild(2).gameObject);

            other.gameObject.GetComponent<PickUpObj>().Drop();
        }*/
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
}
