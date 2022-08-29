using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pallet : MonoBehaviour
{
    Dictionary<Color, GameObject> stacks = new Dictionary<Color, GameObject>();

    int index = 0;

    TestBox tempBox;

    private void Start()
    {
        
    }

    void CheckStacks(GameObject input)
    {
        var colorKey = input.GetComponent<MeshRenderer>().material.color;

        if (stacks.ContainsKey(colorKey) && stacks[colorKey].GetComponent<PalletStack>().stack.Index() < 4)
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

        if (other.transform.GetChild(2) != null);
        {
            
            CheckStacks(other.transform.GetChild(2).gameObject);

            other.gameObject.GetComponent<PickUpObj>().Drop();
        }
    }
}
