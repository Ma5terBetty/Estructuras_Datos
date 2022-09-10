using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manage the employee, checks if it is an employee, if there is an employee selected, and tells them what to do
/// </summary>
public class EmployeeManager : MonoBehaviour
{
    public static EmployeeManager Instance;
    
    //private List<Employee> _employees = new List<Employee>();
    [SerializeField] private Employee _currentEmployee;
   

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    /// <summary>
    /// Assigns current employee to the elected employee
    /// </summary>
    /// <param name="employee"></param>
    public void GetEmployee(Employee employee)
    {
        RemoveEmployee();
        _currentEmployee = employee;
        _currentEmployee.SetSelectedOutline(true);
    }

    /// <summary>
    /// if currently there is an employee selected
    /// </summary>
    /// <returns></returns>
    public bool HasEmployee()
    {
        return _currentEmployee;
    }
    
    /// <summary>
    /// Checks if an object is an employee.
    /// It gets the component employee, if the object doesn't have it, it isn't an employee
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public bool CheckEmployee(GameObject obj)
    {
        var employee = obj.GetComponent<Employee>();
        return employee;
    }

    /// <summary>
    /// Gives a task to the employee.
    /// </summary>
    /// <param name="target"></param>
    /// <param name="obj"></param> 
    public void SetTask(Vector3 target,GameObject obj)
    {
        _currentEmployee.GiveTask(new CmdMoveTowards(_currentEmployee.transform, target, _currentEmployee.GetData().Speed));
        // if(obj.CompareTag("Box"))
        //     _currentEmployee.GiveTask(new CmdPickUpObj());
    }

    public void RemoveEmployee()
    {
        if (_currentEmployee != null) _currentEmployee.SetSelectedOutline(false);
        _currentEmployee = null;
    }
}
