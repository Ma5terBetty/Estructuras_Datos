using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    [SerializeField]
    float speed;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 pos = rb.position;
        rb.position += Vector3.back * speed * Time.fixedDeltaTime;
        rb.MovePosition(pos);
    }
}
