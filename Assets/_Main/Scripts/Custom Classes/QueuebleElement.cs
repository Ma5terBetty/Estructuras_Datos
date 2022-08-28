using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueuebleElement<T>
{
    public T input;
    public QueuebleElement<T> next;
}
