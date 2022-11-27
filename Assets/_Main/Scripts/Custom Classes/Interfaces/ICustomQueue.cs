using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICustomQueue<T>
{
    int Count { get; }
    void InitializeQueue();
    void Enqueue(T input);
    T Dequeue();
    bool IsQueueEmpty();
    T Peek();
}
