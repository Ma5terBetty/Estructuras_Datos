using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectEmployee : MonoBehaviour
{
    [SerializeField] private LayerMask target;
    /// <summary>
    /// Casts a raycast, checks if it hit an employee, assigns the variable "_currentEmployee".
    /// If there isn't an employee selected, the current employee is null.
    /// If you select another employee, it changes the selected employee
    /// </summary>
    /// <param name="mousePos">Current mouse position</param>
    ///
    
    private EmployeeManager _employeeManager;

    private void Awake()
    {
        _employeeManager = GetComponent<EmployeeManager>();
    }
    
    public void GetEmployee(in Vector2 mousePos)
    {
        if(!_employeeManager) return;
        
        var ray = Camera.main.ScreenPointToRay(mousePos);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100f, target))
        {
            _employeeManager.GetEmployee(hit.collider.gameObject.GetComponent<Employee>());

            var aux = float.MaxValue;
            var dist = 0f;
            for (int i = 0; i < LevelManager.Instance.waypoints.Length; i++)
            {
                dist = Vector3.Distance(hit.collider.gameObject.transform.position, LevelManager.Instance.waypoints[i].transform.position);
                if (dist < aux)
                {
                    aux = dist;
                    Supervisor.Instance.dijkstraTest.origen = int.Parse(LevelManager.Instance.waypoints[i].name);
                }
            }
        }
        // else
        // {
        //     _employeeManager.RemoveEmployee();
        // }
    }
}
