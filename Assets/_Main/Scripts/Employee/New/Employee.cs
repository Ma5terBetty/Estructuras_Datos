using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Common mediator for all employee scripts, it follows the Facade design pattern
/// </summary>
public class Employee : MonoBehaviour
{
    [SerializeField] private EmployeeSO data;
    
    private OutlineHandler _outlineHandler;
    private PackageCollector _packageCollector;
    
    private TaskHandler _taskHandler;

    private void Awake()
    {
        _taskHandler = GetComponent<TaskHandler>();
        _packageCollector = GetComponent<PackageCollector>();
        _outlineHandler = GetComponent<OutlineHandler>();
    }

    private void Start()
    {
        _packageCollector.OnPackageChange += OverrideTask;
    }

    private void OnDisable()
    {
        _packageCollector.OnPackageChange -= OverrideTask;
    }

    /// <summary>
    /// Gets the scriptable object containing the stats from the employee 
    /// </summary>
    /// <returns></returns>
    public EmployeeSO GetData() => data;
    
    /// <summary>
    /// Add a task
    /// </summary>
    /// <param name="newTask"></param>
    public void AddTask(Task newTask)
    {
        _taskHandler.AddTask(newTask);
    }

    /// <summary>
    /// Cancel the current task
    /// </summary>
    public void OverrideTask()
    {
        _taskHandler.OverrideTask();
    }

    /// <summary>
    /// Turns the outline on or off
    /// </summary>
    /// <param name="isSelected"></param>
    public void SetOutline(in bool isSelected)
    {
        _outlineHandler.SetSelectedOutline(isSelected);
    }
}
