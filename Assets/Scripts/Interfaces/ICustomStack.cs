using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICustomStack<T>
{
    void Initialize(int range = 0);
    void Push(T input);
    T Pop();
    bool IsStackEmpty();
    T Top();
    int Index();
}
