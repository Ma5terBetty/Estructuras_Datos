using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomQueue<T> : ICustomQueue<T>
{
    QueuebleElement<T> firstElement;
    QueuebleElement<T> lastElement;
    public void InitializeQueue()
    {
        firstElement = null;
        lastElement = null;
    }
    public void Enqueue(T input)
    {
        QueuebleElement<T> newInput = new QueuebleElement<T>();
        newInput.input = input;
        newInput.next = null;

        if (lastElement != null)
        { 
            lastElement.next = newInput;
        }

        lastElement = newInput;

        if (firstElement == null)
        { 
            firstElement = lastElement;
        }
    }
    public void Dequeue()
    {
        firstElement = firstElement.next;

        if (firstElement == null)
        {
            lastElement = null;
        }
    }
    public T FirstInQueue()
    {
        return firstElement.input;
    }
    public bool IsQueueEmpty()
    {
        return (lastElement == null);
    }
}
