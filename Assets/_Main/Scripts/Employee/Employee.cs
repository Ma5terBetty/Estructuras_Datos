using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Employee : MonoBehaviour
{
    [SerializeField] private EmployeeSO data;
    
    private Outline _selectedOutline;
    private PickUpObj _pickUpObj;
    private CustomQueue<Task> _pendingTasks = new();
    private bool _isDoingTask;
    public EmployeeSO GetData() => data;

    private void Awake()
    {
        _selectedOutline = GetComponent<Outline>();
        _pickUpObj = GetComponent<PickUpObj>();
        _pickUpObj.OnPackageChange += OnPackageChangeHandler;
    }

    private void OnDisable()
    {
        
    }

    private void Start()
    {
        SetSelectedOutline(false);
        StartCoroutine(DoTask2());
    }

    private void Update()
    {
        /*if(_isDoingTask || _pendingTasks.Count < 1)
            return;

        StartCoroutine(DoTask());*/
    }

    private IEnumerator DoTask2()
    {
        while (true)
        {
            if (!_isDoingTask && _pendingTasks.Count >= 1)
            {
                            
                _isDoingTask = true;
                var ongoingTask = _pendingTasks.Dequeue();
                var ongoingTaskPosition = ongoingTask.Position;

                while (Vector3.Distance(transform.position, ongoingTaskPosition) > data.MinTaskDistance && _isDoingTask)
                {
                    CmdMoveTowards move = new CmdMoveTowards(transform, ongoingTaskPosition, data.Speed);
                    move.Do();
            
                    yield return null;
                }

                _isDoingTask = false;
            }
            
            yield return null;
        }
    }

    private IEnumerator DoTask()
    {
        _isDoingTask = true;
        var ongoingTask = _pendingTasks.Dequeue();
        var ongoingTaskPosition = ongoingTask.Position;

        while (Vector3.Distance(transform.position, ongoingTaskPosition) > data.MinTaskDistance)
        {
            CmdMoveTowards move = new CmdMoveTowards(transform, ongoingTaskPosition, data.Speed);
            move.Do();

            if (!_isDoingTask)
            {
                break;
            }
            
            yield return null;
        }

        _isDoingTask = false;
    }

    public void SetSelectedOutline(in bool isSelected)
    {
        if (!_selectedOutline) return;
        _selectedOutline.enabled = isSelected;
    }

    public void AddTask(Task newTask)
    {
        _pendingTasks.Enqueue(newTask);
    }

    private void OnPackageChangeHandler()
    {
        _isDoingTask = false;
    }

}
