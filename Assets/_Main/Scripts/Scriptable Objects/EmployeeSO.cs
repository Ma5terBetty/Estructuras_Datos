using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Employee", fileName = "Work/Employee", order = 0)]
public class EmployeeSO : ScriptableObject
{
    [SerializeField] private string id = "Default";
    [SerializeField] private float speed = 5f;
    [SerializeField] private float minTaskDistance = .3f;

    public string ID => id;
    public float Speed => speed;
    public float MinTaskDistance => minTaskDistance;
}
