using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worker : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    private Vector3 _velocity = Vector3.zero;
    public Vector3 Target { get; private set; }


    private void Start()
    {
        Target = transform.position;
    }
    private void Update()
    {
        if(transform.position != Target)
        {
            MoveToTarget();
        }
    }

    private void MoveToTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, Target, speed * Time.deltaTime);
        //transform.forward = Vector3.SmoothDamp(transform.forward, Target, ref _velocity, speed);
        // Rotate thowards the position 
    }

    /// <summary>
    /// Sets position of the target
    /// </summary>
    /// <param name="pos"></param>
    public void SetTargetPosition(Vector3 pos) => Target = pos;
}
