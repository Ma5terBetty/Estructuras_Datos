using System;
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
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        GetChildTransforms();

        if (stack == null) stack = new CustomStack<GameObject>();
        stack.Initialize(transform.childCount);
        Suscribe();
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

    public void RestartStacks()
    {
        stack.Initialize(transform.childCount);
    }

    private void Suscribe()
    {
        if (stack != null) Debug.Log("NO ES NULO");
       GameManager.OnTruckArrives += RestartStacks;
        GameManager.OnChangedScene += Unsuscribe;
    }

    private void Unsuscribe()
    {
        GameManager.OnTruckArrives -= RestartStacks;
    }
}
