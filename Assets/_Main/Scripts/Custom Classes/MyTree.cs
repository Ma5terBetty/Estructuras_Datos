using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTree : ITreeADT
{
    private NodeABB _root;
    public int Root => _root.Info;
    public bool Empty => _root == null;
    public NodeABB Left => _root.Left;
    public NodeABB Right => _root.Right;

    public MyTree()
    {
        Initialize();
    }

    public void Initialize() => _root = null;

    public void Add(ref NodeABB root, int x)
    {
        if (Empty)
        {
            root = new NodeABB(x);
        }
        else if (Root > x)
        {
            Add(ref root.Left, x);
        }
        else if (Root < x)
        {
            Add(ref root.Right, x);
        }
    }
    
    public void Remove(ref NodeABB root, int x)
    {
        if (Empty) return;
        if (Root == x && root.Left == null && root.Right == null)
        {
            _root = null;
        }
        else if (Root == x && root.Left != null)
        {
            _root.SetInfo(Highest(root.Left));
            Remove(ref root.Left, root.Info);
        }
        else if (Root == x && root.Left == null)
        {
            _root.SetInfo(Lowest(root.Right));
            Remove(ref root.Right, root.Info);
        }
        else if (Root < x)
        {
            Remove(ref root.Right, root.Info);
        }
        else
        {
            Remove(ref root.Left, root.Info);
        }
    }
    public static int Highest(NodeABB a) => a.Right == null ? a.Info : Highest(a.Right);
    public static int Lowest(NodeABB a) => a.Left == null ? a.Info : Lowest(a.Left);

    public static int Height(NodeABB ab)
    {
        if (ab == null)
            return -1;
        else
            return (1 + Math.Max(Hight()))
    }
}
