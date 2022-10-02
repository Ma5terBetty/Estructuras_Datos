using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// It is the sript that tells the employees what to do
/// It utilize the Facade design pattern
/// </summary>
public class Supervisor : MonoBehaviour
{
    private InputHandler _input;
    private SelectEmployee _selectEmployee;
    private AssignTask _assignTask;

    private void Awake()
    {
        _input = GetComponent<InputHandler>();
        _selectEmployee = GetComponent<SelectEmployee>();
        _assignTask = GetComponent<AssignTask>();
    }

    private void Start()
    {
        _input.OnRightClick += AssignTask;
        _input.OnLeftClick += SelectEmployee;
        _input.OnDoubleRightClick += OverrideTask;
    }

    private void OnDisable()
    {
        _input.OnRightClick -= AssignTask;
        _input.OnLeftClick -= SelectEmployee;
        _input.OnDoubleRightClick -= OverrideTask;
    }

    private void SelectEmployee()
    {
        _selectEmployee.GetEmployee(_input.MousePosition);
    }

    private void AssignTask()
    {
        _assignTask.SetTask(_input.MousePosition);
    }

    private void OverrideTask()
    {
        _assignTask.OverrideTask();
    }
}
