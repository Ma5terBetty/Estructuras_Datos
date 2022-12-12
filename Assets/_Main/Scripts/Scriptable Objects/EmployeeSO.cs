using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Employee", fileName = "Work/Employee", order = 0)]
public class EmployeeSO : ScriptableObject
{
    [SerializeField] private string id = "Default";
    [SerializeField] private float speed = 5f;
    [SerializeField] private float minTaskDistance = .3f;
    [SerializeField] private float pickUpDistance = 1f;
    [SerializeField] private Material material;

    public string ID => id;
    public float Speed => speed;
    public float MinTaskDistance => minTaskDistance;
    public float PickUpDistance => pickUpDistance;
    [field: SerializeField] 
    public EmployeeRole Role { get; private set; }
    public Material Material => material;
}

public enum EmployeeRole
{
    ShelvePallet,
    Shelve,
    Pallet,
    GarbageCollector
}
