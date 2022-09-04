using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Employee : MonoBehaviour, IControllable
{
    [SerializeField] private EmployeeSO data;    
    [SerializeField] private float speed = 1f;
    private Vector3 _velocity = Vector3.zero;
    private CmdMoveTowards _moveTowards;
    public Vector3 Target { get; private set; }

    public EmployeeSO GetData() => data;



    private void Start()
    {
        Target = transform.position;
    }
    private void Update()
    {
        if(transform.position != Target)
        {
            _moveTowards = new CmdMoveTowards(transform, Target, speed);
            _moveTowards.Do();
        }
    }

   

    /// <summary>
    /// Sets position of the target
    /// </summary>
    /// <param name="pos"></param>
    public void SetTargetPosition(Vector3 pos) => Target = pos;
}
