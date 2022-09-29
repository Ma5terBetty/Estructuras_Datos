using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmployeeView : MonoBehaviour
{
    Animator animator;
    [SerializeField]
    Outline selectionOutline;
    [SerializeField]
    Outline2 backWall;
    EmployeeModel employeeModel;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        selectionOutline.enabled = false;
    }

    void Update()
    {
        
    }
    public void SetSelectedOutline(in bool isSelected)
    {
        if (!selectionOutline) return;
        selectionOutline.enabled = isSelected;
    }

}
