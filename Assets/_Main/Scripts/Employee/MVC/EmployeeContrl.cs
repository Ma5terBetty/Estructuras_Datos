using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmployeeContrl : MonoBehaviour
{
    private EmployeeModel _employeeModel;
    private EmployeeView _employeeView;
    private Rigidbody _rigidbody;
    private PackageCollector _packgeCollector;

    public EmployeeModel EmployeeModel { get => _employeeModel; set { _employeeModel = value; } }
    public EmployeeView EmployeeView { get => _employeeView; set { _employeeView = value;} }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _employeeModel = GetComponent<EmployeeModel>();
        _employeeView = GetComponent<EmployeeView>();
        _packgeCollector = GetComponent<PackageCollector>();
        _packgeCollector.OnPackageChange += OnPackageChangeHandler;
    }

    void Start()
    {
        _employeeView.SetSelectedOutline(false);
    }
    
    void Update()
    {
        /*if (employeeModel.IsDoingTask || employeeModel.PendingTasks.Count < 1)
            return;

        StartCoroutine(DoTask());*/
    }

    private void FixedUpdate()
    {
        if (_employeeModel.IsDoingTask || _employeeModel.PendingTasks.Count < 1)
            return;

        StartCoroutine(DoTask());
    }
    private IEnumerator DoTask()
    {
        _employeeModel.IsDoingTask = true;
        var ongoingTask = _employeeModel.PendingTasks.Dequeue();
        var ongoingTaskPosition = ongoingTask.Position;

        while (Vector3.Distance(transform.position, ongoingTaskPosition) > _employeeModel.Data.MinTaskDistance)
        {
            CmdMoveTowards move = new CmdMoveTowards(_rigidbody, ongoingTaskPosition, _employeeModel.Data.Speed);
            move.Do();

            if (!_employeeModel.IsDoingTask)
            {
                break;
            }

            yield return null;
        }

        _employeeModel.IsDoingTask = false;
    }
    public void AddTask(Task newTask)
    {
        _employeeModel.PendingTasks.Enqueue(newTask);
    }

    public void OverrideTask()
    {
        _employeeModel.IsDoingTask = false;
    }

    public void OnPackageChangeHandler()
    {
        _employeeModel.IsDoingTask = false;
    }
}
