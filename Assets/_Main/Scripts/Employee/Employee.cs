using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Employee : MonoBehaviour
{
    [SerializeField] private EmployeeSO data;
    /// <summary>
    /// The idea is that every time the player(AKA the supervisor) tells the employee something to do it will get in a queue
    /// We could use queue (cola) here
    /// It is not implemented yet
    /// </summary>
    private List<ICommand> _pendingTasks = new List<ICommand>();
    /// <summary>
    /// This will be empty by default the supervisor will assign a task
    /// </summary>
    private ICommand _currentTask;
    private Outline _selectedOutline;
    public EmployeeSO GetData() => data;

    private void Awake()
    {
        _selectedOutline = GetComponent<Outline>();
    }

    private void Start()
    {
        SetSelectedOutline(false);
    }

    private void Update()
    {
        if(_currentTask == null) return;
        _currentTask.Do();
    }

    /// <summary>
    /// Gives the a task to the worker
    /// </summary>
    /// <param name="objTag"></param>
    public void GiveTask(ICommand task)
    {
        _currentTask = task;
        
        // if (_currentTask == null)
        // {
        //     _currentTask = task;
        // }
        // else
        // {
        //     _pendingTasks.Add(task);
        // }
    }

    public void SetSelectedOutline(bool isSelected)
    {
        if (!_selectedOutline) return;
        _selectedOutline.enabled = isSelected;
    }

    private void OnMouseOver()
    {
        var name = data.ID;
        UIManager.Instance.ShowName($"Employee: {name}");
    }

    private void OnMouseExit()
    {
        UIManager.Instance.TurnOffName();
    }

}
