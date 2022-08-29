using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PalletStack : MonoBehaviour
{
    public string color;
    public Transform[] positions;
    public CustomStack<GameObject> stack = new CustomStack<GameObject>();

    public bool IsShowingNames;

    private void Awake()
    {
        GetChildTransforms();
    }

    private void Start()
    {
        stack.Initialize(transform.childCount);
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
        return stack.Pop();
    }

    void GetChildTransforms()
    {
        positions = new Transform[transform.childCount];
        for (int i = 0; i < positions.Length; i++)
        {
            positions[i] = transform.GetChild(i);
        }
    }
}
