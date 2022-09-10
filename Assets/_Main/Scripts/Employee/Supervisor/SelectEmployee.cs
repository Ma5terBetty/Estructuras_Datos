using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectEmployee : MonoBehaviour
{
    [SerializeField] private LayerMask target;
    /// <summary>
    /// Casts a raycast, checks if it hit an employee, assigns the variable "_currentEmployee".
    /// If there isn't an employee selected, the current employee is null.
    /// If you select another employee, it changes the selected employee
    /// </summary>
    /// <param name="mousePos">Current mouse position</param>
    public void GetEmployee(in Vector2 mousePos)
    {
        var ray = Camera.main.ScreenPointToRay(mousePos);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100f, target))
        {
            EmployeeManager.Instance.GetEmployee(hit.collider.gameObject.GetComponent<Employee>());
        }
        else
        {
            EmployeeManager.Instance.RemoveEmployee();
        }
    }
}
