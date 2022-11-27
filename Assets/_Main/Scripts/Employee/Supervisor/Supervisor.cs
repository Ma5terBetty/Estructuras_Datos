using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// It is the sript that tells the employees what to do
/// It utilize the Facade design pattern
/// </summary>
public class Supervisor : MonoBehaviour
{
    public static Supervisor Instance;

    private InputHandler _input;
    private SelectEmployee _selectEmployee;
    private AssignTask _assignTask;
    public TestDijkstra dijkstraTest;

    private void Awake()
    {
        if (Instance == null)
        { 
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        _input = GetComponent<InputHandler>();
        _selectEmployee = GetComponent<SelectEmployee>();
        _assignTask = GetComponent<AssignTask>();
        dijkstraTest = GetComponent<TestDijkstra>();
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

    public void AssignTask()
    {
        //_assignTask.SetTask(_input.MousePosition);
        for (int i = 0; i < dijkstraTest.travelNodes.Length; i++)
        {
            _assignTask.SetTask(dijkstraTest.waypointsDic[dijkstraTest.travelNodes[i]].transform.position);
            Debug.Log(dijkstraTest.travelNodes[i]);
        }
    }

    private void OverrideTask()
    {
        _assignTask.OverrideTask();
    }
}
