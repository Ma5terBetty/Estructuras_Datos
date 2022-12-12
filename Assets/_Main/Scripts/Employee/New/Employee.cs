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
    [SerializeField] private SkinnedMeshRenderer mesh;
    
    private OutlineHandler _outlineHandler;
    private PackageCollector _packageCollector;
    
    private TaskHandler _taskHandler;
    private Animator _animation;
    
    public EmployeeRole Role { get; private set; }

    
    //Animations
    public bool HasPackage { get; private set; }
    public bool IsDoingTask { get; private set; }


    private void Awake()
    {
        _taskHandler = GetComponent<TaskHandler>();
        _packageCollector = GetComponent<PackageCollector>();
        _outlineHandler = GetComponent<OutlineHandler>();
        _animation = GetComponent<Animator>();
    }

    private void Start()
    {
        _taskHandler.OnTaskChanged += OnTaskChangedHandler;
        _packageCollector.OnPackageChange += OverrideTask;
        _packageCollector.OnPackageChange += OnPackageChangeHandler;
        //Role = data.Role;
        SetRole(data);
    }

    private void OnDisable()
    {
        _taskHandler.OnTaskChanged -= OnTaskChangedHandler;
        _packageCollector.OnPackageChange -= OverrideTask;
        _packageCollector.OnPackageChange -= OnPackageChangeHandler;
    }

    private void OnPackageChangeHandler(bool hasPackage)
    {
        HasPackage = hasPackage;
    }

    private void OnTaskChangedHandler(bool isDoingTask)
    {
        IsDoingTask = isDoingTask;
    }

    private void SetRole(EmployeeSO newData)
    {
        Role = newData.Role;
        mesh.material = newData.Material;
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
    public void OverrideTask(bool hasPackage = false)
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
