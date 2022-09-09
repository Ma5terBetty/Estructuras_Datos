using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Employee : MonoBehaviour
{
    [SerializeField] private EmployeeSO data;
    
    private bool _isDoingTask;
    private CustomQueue<TaskPoint> _pendingTasks = new();
    /// <summary>
    /// This will be empty by default the supervisor will assign a task
    /// </summary>
    private ICommand _currentTask;
    private Outline _selectedOutline;
    public EmployeeSO GetData() => data;

    private void Awake()
    {
        _selectedOutline = GetComponent<Outline>();
        TaskPoint.OnClickedTaskPoint += OnTaskPointClickedHandler;
    }

    private void OnDisable()
    {
        TaskPoint.OnClickedTaskPoint -= OnTaskPointClickedHandler;
    }

    private void Start()
    {
        SetSelectedOutline(false);
    }

    private void Update()
    {
        if(_isDoingTask || _pendingTasks.Count < 1)
            return;

        StartCoroutine(DoTask());
    }

    private IEnumerator DoTask()
    {
        _isDoingTask = true;
        var ongoingTask = _pendingTasks.Dequeue();
        var ongoingTaskPosition = ongoingTask.transform.position;

        while (Vector3.Distance(transform.position, ongoingTaskPosition) > data.MinTaskDistance)
        {
            var dir = ongoingTaskPosition - transform.position;
            dir.Normalize();
            transform.position += dir * (data.Speed * Time.deltaTime);
            yield return null;
        }

        _isDoingTask = false;
    }

    /// <summary>
    /// Gives the a task to the worker
    /// </summary>
    /// <param name="objTag"></param>
    public void GiveTask(ICommand task)
    {
        _currentTask = task;
    }

    public void SetSelectedOutline(bool isSelected)
    {
        if (!_selectedOutline) return;
        _selectedOutline.enabled = isSelected;
    }

    private void OnTaskPointClickedHandler(TaskPoint newTaskPoint)
    {
        _pendingTasks.Enqueue(newTaskPoint);
    }

}
