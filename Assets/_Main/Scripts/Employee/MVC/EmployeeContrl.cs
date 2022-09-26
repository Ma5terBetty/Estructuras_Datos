using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmployeeContrl : MonoBehaviour
{
    EmployeeModel employeeModel;
    EmployeeView employeeView;
    PickUpObj _pickUpObj;

    public EmployeeModel EmployeeModel { get => employeeModel; set { employeeModel = value; } }
    public EmployeeView EmployeeView { get => employeeView; set { employeeView = value;} }
    public PickUpObj PickUpObj { get => _pickUpObj; set { _pickUpObj = value; } }

    private void Awake()
    {
        employeeModel = GetComponent<EmployeeModel>();
        employeeView = GetComponent<EmployeeView>();
        _pickUpObj = GetComponent<PickUpObj>();
        _pickUpObj.OnPackageChange += OnPackageChangeHandler;
    }

    void Start()
    {
        employeeView.SetSelectedOutline(false);
    }
    
    void Update()
    {
        if (employeeModel.IsDoingTask || employeeModel.PendingTasks.Count < 1)
            return;

        StartCoroutine(DoTask());
    }
    private IEnumerator DoTask()
    {
        employeeModel.IsDoingTask = true;
        var ongoingTask = employeeModel.PendingTasks.Dequeue();
        var ongoingTaskPosition = ongoingTask.Position;

        while (Vector3.Distance(transform.position, ongoingTaskPosition) > employeeModel.Data.MinTaskDistance)
        {
            CmdMoveTowards move = new CmdMoveTowards(transform, ongoingTaskPosition, employeeModel.Data.Speed);
            move.Do();

            if (!employeeModel.IsDoingTask)
            {
                break;
            }

            yield return null;
        }

        employeeModel.IsDoingTask = false;
    }
    public void AddTask(Task newTask)
    {
        employeeModel.PendingTasks.Enqueue(newTask);
    }

    public void OnPackageChangeHandler()
    {
        employeeModel.IsDoingTask = false;
    }
}
