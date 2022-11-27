using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignTask : MonoBehaviour
{
    [SerializeField] private LayerMask target;
    private EmployeeManager _employeeManager;

    private void Awake()
    {
        _employeeManager = GetComponent<EmployeeManager>();
    }

    /*public void SetTask(in Vector2 mousePos)
    {
        if(!_employeeManager) return;

        var ray = Camera.main.ScreenPointToRay(mousePos);
        RaycastHit hit;
        if (!Physics.Raycast(ray, out hit, 100f, target)) return;
        if (!_employeeManager.HasEmployee()) return;
        _employeeManager.SetTask(new Task(){Position = hit.point, TaskPoint = null});
    }*/

    public void SetTask(Vector3 position)
    {
        if(!_employeeManager) return;

        //var ray = Camera.main.ScreenPointToRay(mousePos);
        //RaycastHit hit;
        //if (!Physics.Raycast(ray, out hit, 100f, target)) return;
        //if (!_employeeManager.HasEmployee()) return;
        _employeeManager.SetTask(new Task(){Position = position, TaskPoint = null});
    }

    public void OverrideTask()
    {
        _employeeManager.OverrideTask();
    }
}
