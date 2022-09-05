using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomStack<T> : ICustomStack<T>
{
    T[] inputs;
    int index = 0;

    public void Initialize(int range = 100)
    {
        inputs = new T[range];
        index = 0;
    }
    public void Push(T input)
    {
        inputs[index] = input;
        index++;
    }
    public T Pop()
    {
        index--;
        return inputs[index];
    }
    public T Top()
    {
        return inputs[index -1];
    }
    public int Index()
    {
        return index;
    }
    public bool IsStackEmpty()
    {
        return (index == 0);
    }
}
