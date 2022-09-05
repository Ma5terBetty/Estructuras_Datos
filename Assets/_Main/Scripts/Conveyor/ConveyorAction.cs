using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorAction : MonoBehaviour
{
    [SerializeField]
    float speed;
    Rigidbody rb;

    GameObject leftWall;
    GameObject rightWall;

    public bool isLeftWallEnabled = true;
    public bool isRightWallEnabled = true;

    private void Awake()
    {
        leftWall = transform.GetChild(3).gameObject;
        rightWall = transform.GetChild(2).gameObject;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (!isLeftWallEnabled) leftWall.SetActive(false);
        if (!isRightWallEnabled) rightWall.SetActive(false);
    }

    private void FixedUpdate()
    {
        Vector3 pos = rb.position;
        rb.position += -transform.forward * speed * Time.fixedDeltaTime;
        rb.MovePosition(pos);
    }
}
