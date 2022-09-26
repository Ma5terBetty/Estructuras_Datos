using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmployeeModel : MonoBehaviour
{
    [SerializeField]
    EmployeeSO _data;

    Rigidbody _rigidBody;
    float _playerSpeed;
    PickUpObj _pickUpObj;
    private bool _isDoingTask;
    CustomQueue<Task> _pendingTasks = new();

    public bool IsDoingTask { get => _isDoingTask; set => _isDoingTask = value; }
    public CustomQueue<Task> PendingTasks { get => _pendingTasks; set => _pendingTasks = value; }
    public Rigidbody Rigidbody { get => _rigidBody; set => _rigidBody = value; }
    public float PlayerSpeed { get => _playerSpeed; set => _playerSpeed = value; }
    public PickUpObj PickUpObj { get => _pickUpObj; set => _pickUpObj = value; }
    public EmployeeSO Data { get => _data; set => _data = value; }

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        _playerSpeed = Rigidbody.velocity.magnitude;
    }
    
}
