using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// First-in, first-out collection of objects
/// The definition s from the documentation
/// </summary>
/// <typeparam name="T"></typeparam>
public class CustomQueue<T> : ICustomQueue<T>
{
    private QueuebleElement<T> firstElement;
    private QueuebleElement<T> lastElement;

    /// <summary>
    /// Number of Elements T in the queue
    /// </summary>
    public int Count { get; private set; }

    public CustomQueue()
    {
        InitializeQueue();
    }

    /// <summary>
    /// Initializes the Queue
    /// BUT IT IS ALSO ALREADY INITIALIZED FROM THE CONSTRUCTOR
    /// </summary>
    public void InitializeQueue()
    {
        firstElement = null;
        lastElement = null;
        Count = 0;
    }
    
    /// <summary>
    /// Add element T to the end of the queee
    /// </summary>
    /// <param name="input"></param>
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

        Count++;
    }
    
    /// <summary>
    /// Removes the oldest element T from the queue and it also returns it
    /// </summary>
    /// <returns></returns>
    public T Dequeue()
    {
        var e = firstElement.input;
        firstElement = firstElement.next;

        if (firstElement == null)
        {
            lastElement = null;
        }
        if(Count > 0)
            Count--;
        return e;

    }
    
    /// <summary>
    /// Returns the oldest element from the queue
    /// </summary>
    /// <returns></returns>
    public T Peek()
    {
        return firstElement.input;
    }
    public bool IsQueueEmpty()
    {
        return (lastElement == null);
    }
}
