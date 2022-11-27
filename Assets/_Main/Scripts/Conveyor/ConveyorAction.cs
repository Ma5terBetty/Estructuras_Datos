using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorAction : MonoBehaviour
{
    [SerializeField]
    float speed;

    [SerializeField] private MeshRenderer belt;
    Rigidbody rb;
    private static readonly int ScrollSpeed = Shader.PropertyToID("_Speed");

    public bool isLeftWallEnabled = true;
    public bool isRightWallEnabled = true;

    private void Awake()
    {
        belt.material.SetFloat(ScrollSpeed, speed);
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 pos = rb.position;
        rb.position += -transform.forward * (speed * Time.fixedDeltaTime);
        rb.MovePosition(pos);
    }
}
