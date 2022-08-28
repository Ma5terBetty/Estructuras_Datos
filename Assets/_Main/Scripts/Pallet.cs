using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pallet : MonoBehaviour
{
    Dictionary<string, GameObject> stacks = new Dictionary<string, GameObject>();

    int index = 0;

    TestBox tempBox;

    private void Start()
    {
        
    }

    void CheckStacks(GameObject input)
    {
        if (stacks.ContainsKey(tempBox.color) && stacks[tempBox.color].GetComponent<PalletStack>().stack.Index() < 4)
        {
            stacks[tempBox.color].GetComponent<PalletStack>().RecieveItem(input);
        }
        else if (stacks.Count < 4)
        {
            stacks.Add(tempBox.color, transform.GetChild(index).gameObject);
            index++;
            stacks[tempBox.color].GetComponent<PalletStack>().RecieveItem(input);
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
        if (other.GetComponent<TestBox>() != null)
        { 
            tempBox = other.GetComponent<TestBox>();

            if (tempBox.IsPickuble)
            { 
                tempBox.IsPickuble = false;
                CheckStacks(other.gameObject);
            }
        }

        
    }
}
