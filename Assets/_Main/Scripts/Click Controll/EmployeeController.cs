using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmployeeController : MonoBehaviour
{
    [SerializeField] private Camera worldCamera;
    private IControllable employee;


    private void Update()
    {
        if(employee == null)
            SelectEmployee();
        else
            SelectDestination();
    }

    private void SelectEmployee()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = worldCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                if (hitInfo.collider.gameObject.CompareTag("Employee"))
                {
                    Debug.Log("Employee Found!");
                    if (hitInfo.collider.TryGetComponent(out IControllable newEmployee))
                    {
                        employee = newEmployee;
                    }
                    else Debug.Log("IControllable component was not found");
                }
                else
                    Debug.Log("Nothing");
            }
        }
    }

    private void SelectDestination()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = worldCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo, 100f))
            {
                if (hitInfo.collider.CompareTag("Employee")) return;

                employee.SetTargetPosition(hitInfo.point);
                employee = null;
            }
        }
    }
}
