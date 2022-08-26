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
    [SerializeField] private Material packageMaterial;
    [Tooltip("Could be usefull to identify colors")]
    [SerializeField] private Colors packageColor;

    public float Health => health;
    public float Weight => weight;
    public Material MaterialColor => packageMaterial;
    public Colors PackageColor => packageColor;
}

public enum Colors
{ 
    red,
    blue,
    green,
    yellow
}
