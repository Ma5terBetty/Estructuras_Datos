using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAction : MonoBehaviour
{
    [SerializeField] private Employee currentEmployee;
    
    /// <summary>
    /// Casts a raycast, checks if it hit an employee, assigns the variable "_currentEmployee".
    /// If there isn't an employee selected it returns.
    /// If you select another employee, it changes the selected employee
    /// </summary>
    /// <param name="mousePos">Current mouse position</param>
    /// <param name="worker">The npc</param>
    public void ClickDetect(in Vector2 mousePos)
    {
        Ray ray = Camera.main.ScreenPointToRay(mousePos);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100f))
        {
            // if the ray hits an employee it assigns the current employee
            if(EmployeeManager.Instance.CheckEmployee(hit.collider.gameObject))
            {
                EmployeeManager.Instance.GetEmployee(hit.collider.gameObject.GetComponent<Employee>());
                return;
            }
            //Checks if it has an employee
            if (!EmployeeManager.Instance.HasEmployee())
            {
                return;
            }
            else
            {
                EmployeeManager.Instance.SetTask(hit.point, hit.collider.gameObject);
            }
            
            
            
        }

    }


    
}
