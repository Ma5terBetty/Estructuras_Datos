using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAction : MonoBehaviour
{
    [SerializeField] private Employee currentEmployee;
    
    /// <summary>
    /// When clicked tells the npc to go somewhere
    /// </summary>
    /// <param name="mousePos">Current mouse position</param>
    /// <param name="worker">The npc</param>
    public void ClickDetect(in Vector2 mousePos)
    {
        Ray ray = Camera.main.ScreenPointToRay(mousePos);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100f))
        {
            if (hit.collider.gameObject.CompareTag("Employee"))
            {
                currentEmployee = hit.collider.gameObject.GetComponent<Employee>();
                return;
            }

            if (currentEmployee == null) return;

            currentEmployee.SetTargetPosition(hit.point);
            
        }

    }

    
}
