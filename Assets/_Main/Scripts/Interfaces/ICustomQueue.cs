using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICustomQueue<T>
{
    void InitializeQueue();
    void Enqueue(T input);
    void Dequeue();
    bool IsQueueEmpty();
    T FirstInQueue();
}
