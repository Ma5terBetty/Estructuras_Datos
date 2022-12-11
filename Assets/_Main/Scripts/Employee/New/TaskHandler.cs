using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskHandler : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private EmployeeSO _stats;
    private CustomQueue<Task> _pendingTasks = new();
    private bool _isDoingTask;
    private IEnumerator _doTask;
    Animator _anim;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _stats = GetComponent<Employee>().GetData();
        _anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (_isDoingTask || _pendingTasks.Count < 1)
            return;
        
        if(_doTask != null)
            StartCoroutine(_doTask);
        _doTask = DoTask(_pendingTasks.Dequeue());
        StartCoroutine(_doTask);
    }

    public void AddTask(Task newTask)
    {
        _pendingTasks.Enqueue(newTask);
    }

    public void OverrideTask()
    {
        _isDoingTask = false;
    }

    public void Stopper()
    {
        StopCoroutine("DoTask");
        OverrideTask();
        _isDoingTask = false;
        _anim.SetBool("IsFree", true);
    }

    private IEnumerator DoTask(Task task)
    {
        _isDoingTask = true;
        _anim.SetBool("IsFree", false);

        while (Vector3.Distance(transform.position, task.Position) > _stats.MinTaskDistance)
        {
            var lookPos = task.Position - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 10);
            CmdMoveTowards move = new CmdMoveTowards(_rigidbody, task.Position, _stats.Speed);
            move.Do();

            if (!_isDoingTask)
            {
                break;
            }

            yield return null;
        }

        _isDoingTask = false;
        _anim.SetBool("IsFree", true);
    }
}
