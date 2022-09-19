using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "New Package Type", fileName = "Package", order = 0)]
public class PackageTypeSO : ScriptableObject
{
    [Tooltip("Maybe we won't use this...")]
    [SerializeField] private float health = 100;
    [Tooltip("Maybe we won't use this...")]
    [SerializeField] private float weight = 10;
    [SerializeField] private Color packageColor;
    [Tooltip("Could be usefull to identify colors")]
    [SerializeField] private PackageId id;

    public float Health => health;
    public float Weight => weight;
    public Color Color => packageColor;
    public PackageId Id => id;
}

public enum PackageId
{ 
    red,
    blue,
    green,
    yellow
}
