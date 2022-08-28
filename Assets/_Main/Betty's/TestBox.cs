using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBox : MonoBehaviour
{
    public bool IsPickuble;
    public string color;
    public Color matColor;

    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material.color = matColor;
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        if (IsPickuble)
        {
            rb.position += new Vector3(1f * Time.deltaTime, 0, 0);
        }
    }
}
