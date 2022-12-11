using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "New Package Type", fileName = "Package", order = 0)]
public class PackageTypeSO : ScriptableObject
{
    [SerializeField] private Color packageColor;
    [SerializeField] private PackageId id;

    public Color Color => packageColor;
    public PackageId Id => id;
}

public enum PackageId
{ 
    red,
    blue,
    green,
    yellow,
    garbage
}
