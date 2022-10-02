using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manage the employee, checks if it is an employee, if there is an employee selected, and tells them what to do
/// </summary>
public class EmployeeManager : MonoBehaviour
{
    //private List<Employee> _employees = new List<Employee>();
    //[SerializeField] private Employee _currentEmployee;
    [SerializeField] private EmployeeContrl _currentEmployee;
    
    private void Start()
    {
        TaskPoint.OnClickedTaskPoint += SetTask;
    }

    private void OnDisable()
    {
        TaskPoint.OnClickedTaskPoint += SetTask;
    }

    /// <summary>
    /// Assigns current employee to the elected employee
    /// </summary>
    /// <param name="employee"></param>
    public void GetEmployee(EmployeeContrl employee)
    {
        RemoveEmployee();
        _currentEmployee = employee;
        _currentEmployee.EmployeeView.SetSelectedOutline(true);
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
    public void SetTask(Task newTask)
    {
#if UNITY_EDITOR
        Debug.Log(">>>>>>>>>>>>>>Set task");
#endif
        if (_currentEmployee)
        {
#if UNITY_EDITOR
            Debug.Log("<<<<<<<<<<<<<<<Set task");
#endif
            _currentEmployee.AddTask(newTask);
        }


    }

    public void OverrideTask()
    {
        _currentEmployee.OverrideTask();
    }

    public void RemoveEmployee()
    {
        if (_currentEmployee != null) _currentEmployee.EmployeeView.SetSelectedOutline(false);
        _currentEmployee = null;
    }
}
