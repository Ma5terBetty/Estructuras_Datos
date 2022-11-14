using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISortable
{
    public float SortValue { get; }
    public GameObject GameObject { get; }
    public void SetSortValue(float value);
}
