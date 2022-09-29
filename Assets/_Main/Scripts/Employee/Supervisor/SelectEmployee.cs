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
    ///
    
    private EmployeeManager _employeeManager;

    private void Awake()
    {
        _employeeManager = GetComponent<EmployeeManager>();
    }
    
    public void GetEmployee(in Vector2 mousePos)
    {
        if(!_employeeManager) return;
        
        var ray = Camera.main.ScreenPointToRay(mousePos);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100f, target))
        {
            _employeeManager.GetEmployee(hit.collider.gameObject.GetComponent<EmployeeContrl>());
        }
        else
        {
            _employeeManager.RemoveEmployee();
        }
    }
}
