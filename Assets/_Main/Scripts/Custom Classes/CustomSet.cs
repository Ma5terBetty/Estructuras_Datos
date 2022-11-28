using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomSet : ISet
{
    CustomNode root;

    public void Add(int input)
    {
        if (!this.BelongsToSet(input))
        { 
            CustomNode aux = new CustomNode();
            aux.data = input;
            aux.next = root;
            root = aux;
        }
    }

    public bool BelongsToSet(int input)
    {
        CustomNode aux = root;
        while ((aux != null) && (aux.data != input))
        {
            aux = aux.next;
        }
        return (aux != null);
    }

    public void InitializeSet()
    {
        root = null;
    }

    public bool IsSetEmpty()
    {
        return (root == null);
    }

    public int Pick()
    {
        return root.data;
    }

    public void Remove(int input)
    {
        if (root.data == input)
        {
            root = root.next;
        }
        else
        {
            CustomNode aux = root;
            while (aux.next != null && aux.next.data != input)
            { 
                aux = aux.next;
            }
            if (aux.next != null)
            { 
                aux.next = aux.next.next;
            }
        }
    }
}
