using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeABB 
{
    public int Info { get; private set; }
    public NodeABB Left;
    public NodeABB Right;

    public NodeABB()
    {
        Info = 0;
        Left = null;
        Right = null;
    }
        
    public NodeABB(int data, NodeABB left, NodeABB right)
    {
        Info = data;
        Left = left;
        Right = right;
    }

    public NodeABB(int data)
    {
        Info = data;
        Left = null;
        Right = null;
    }
        
    public void SetInfo(in int info) => Info = info;
    public void SetLeftChild(in NodeABB child) => Left = child;
    public void SetRightChild(in NodeABB child) => Right = child;
}
