using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Employee", fileName = "Work/Employee", order = 0)]
public class EmployeeSO : ScriptableObject
{
    public string id { get; private set; }
    public float speed { get; private set; }
}
