using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public struct Info<T>
{
    public int Id;
    public T Data;

    public Info(int id, T data)
    {
        Id = id;
        Data = data;
    }
}
public class NodeTree<T>
{
    public Info<T> Info;
    public NodeTree<T> Left;
    public NodeTree<T> Right;

    public NodeTree()
    {
        Info = new Info<T>(0, default);
        Left = null;
        Right = null;
    }

    public NodeTree(Info<T> data)
    {
        Info = data;
        Left = null;
        Right = null;
    }

    public NodeTree(Info<T> data, NodeTree<T> left, NodeTree<T> right)
    {
        Info = data;
        Left = left;
        Right = right;
    }
}

public class MyTree<T> : ITreeADT<T>
{
    private int _size = 0;

    public NodeTree<T> Root { get; private set; }
    public int Count => _size;
    public bool IsEmpty => Root == null;
    [CanBeNull] public NodeTree<T> Right => Root?.Right;
    [CanBeNull] public NodeTree<T> Left => Root?.Left;

    public T this[int i]
    {
        get
        {
            ThrowIfIndexOutOfRange(i);
            if (Find(i) != null) return Find(i).Info.Data;
            else throw new Exception();
        }
        set
        {
            ThrowIfIndexOutOfRange(i);
            if(Find(i) != null) Find(i).Info.Data = value;
        }
    }

    public MyTree()
    {
        Clear();
    }

    public void Insert(int index, T element)
    {
        ThrowIfIndexOutOfRange(index);
        var newItem = new NodeTree<T>(new Info<T>(_size, element));
        Root = Root == null ? newItem : RecursiveInsert(Root, newItem);

        for (var i = _size; i > index; i--)
        {
            Find(i).Info.Data = Find(i - 1).Info.Data;
        }
        Find(index).Info.Data = element;
        _size++;


    }

    public void Add(T element)
    {
        var newItem = new NodeTree<T>(new Info<T>(_size, element));
        Root = Root == null ? newItem : RecursiveInsert(Root, newItem);
        _size++;
    }

    public bool Remove(T element)
    {
        if (!Contains(element)) return false;
        RemoveAt(GetItemIndex(element));
        return true;
    }

    private int GetItemIndex(T element)
    {
        for (var i = 0; i < _size; i++)
        {
            if (!Find(i).Info.Data.Equals(element)) continue;
            return i;
        }

        return -1;
    }

    public void RemoveAt(int index)
    {
        ThrowIfIndexOutOfRange(index);
        for (var i = index; i < _size - 1; i++)
        {
            Find(i).Info.Data = Find(i + 1).Info.Data;
        }
        Remove(Root, _size - 1);
        _size--;
    }

    private NodeTree<T> Remove(NodeTree<T> current, int target)
    {
        NodeTree<T> parent;
        if (current == null) return null;
        else
        {
            if (target < current.Info.Id)
            {
                current.Left = Remove(current.Left, target);
                if (BalanceFactor(current) == -2)
                {
                    if (BalanceFactor(current.Right) <= 0) current = RotateRR(current);
                    else current = RotateRL(current);
                }
            }
            else if (target > current.Info.Id)
            {
                current.Right = Remove(current.Right, target);
                if (BalanceFactor(current) == 2)
                {
                    if (BalanceFactor(current.Left) >= 0) current = RotateLL(current);
                    else current = RotateLR(current);
                }
            }
            else
            {
                if (current.Right != null)
                {
                    parent = current.Right;
                    while (parent.Left != null)
                    {
                        parent = parent.Left;
                    }
                    current.Info = parent.Info;
                    current.Right = Remove(current.Right, parent.Info.Id);
                    if (BalanceFactor(current) == 2)
                    {
                        if (BalanceFactor(current.Left) >= 0) current = RotateLL(current);
                        else current = RotateLR(current);
                    }
                }
                else return current.Left;
            }
        }
        return current;
    }

    public bool Contains(T element)
    {
        for (var i = 0; i < _size; i++)
        {
            var currentValue = Find(i).Info.Data;
            if (currentValue.Equals(element))
            {
                return true;
            }
        }

        return false;
    }

    public void Clear()
    {
        Root = null;
        _size = 0;
    }

    [CanBeNull]
    private NodeTree<T> BalanceTree([CanBeNull] NodeTree<T> current)
    {
        var factor = BalanceFactor(current);
        if (factor > 1)
        {
            current = BalanceFactor(current?.Left) > 0 ? RotateLL(current) : RotateLR(current);
        }
        else if (factor < -1)
        {
            current = BalanceFactor(current?.Right) > 0 ? RotateRL(current) : RotateRR(current);
        }
        return current;
    }

    private NodeTree<T> RecursiveInsert(NodeTree<T> current, NodeTree<T> newNode)
    {
        if (current == null)
        {
            current = newNode;
            return current;
        }

        if (newNode.Info.Id < current.Info.Id)
        {
            current.Left = RecursiveInsert(current.Left, newNode);
            current = BalanceTree(current);
        }
        else if (newNode.Info.Id > current.Info.Id)
        {
            current.Right = RecursiveInsert(current.Right, newNode);
            current = BalanceTree(current);
        }
        return current;
    }

    public NodeTree<T> Find(int key)
    {
        var node = Find(key, Root);
        if ((node != null) && (node.Info.Id == key))
        {
            return node;
        }
        return null;
    }

    private NodeTree<T> Find(int target, [CanBeNull] NodeTree<T> current)
    {
        if (target < current?.Info.Id)
        {
            return target == current.Info.Id ? current : Find(target, current.Left);
        }

        if (target == current?.Info.Id)
        {
            return current;
        }
        return current?.Right != null ? Find(target, current.Right) : null;
    }

    private int Max(int left, int right) => left > right ? left : right;

    private int GetHeight([CanBeNull] NodeTree<T> current)
    {
        var height = 0;
        if (current != null)
        {
            var left = GetHeight(current.Left);
            var right = GetHeight(current.Right);
            var maxHeight = Max(left, right);
            height = maxHeight + 1;
        }
        return height;
    }

    private int BalanceFactor(NodeTree<T> current)
    {
        var left = GetHeight(current.Left);
        var right = GetHeight(current.Right);
        var factor = left - right;
        return factor;
    }

    private NodeTree<T> RotateRR(NodeTree<T> parent)
    {
        var pivot = parent.Right;
        parent.Right = pivot?.Left;
        if (pivot != null) pivot.Left = parent;
        return pivot;
    }

    private NodeTree<T> RotateLL(NodeTree<T> parent)
    {
        var pivot = parent.Left;
        parent.Left = pivot?.Right;
        if (pivot != null) pivot.Right = parent;
        return pivot;
    }

    private NodeTree<T> RotateLR(NodeTree<T> parent)
    {
        var pivot = parent.Left;
        parent.Left = RotateRR(pivot);
        return RotateLL(parent);
    }

    private NodeTree<T> RotateRL(NodeTree<T> parent)
    {
        var pivot = parent.Right;
        parent.Right = RotateLL(pivot);
        return RotateRR(parent);
    }

    private void ThrowIfIndexOutOfRange(int index)
    {
        if (index > _size - 1 || index < 0)
        {
            throw new ArgumentOutOfRangeException($"The current size of the tree is {_size}");
        }
    }
}
