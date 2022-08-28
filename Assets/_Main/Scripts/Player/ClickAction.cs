using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAction : MonoBehaviour
{
    /// <summary>
    /// When clicked tells the npc to go somewhere
    /// </summary>
    /// <param name="mousePos">Current mouse position</param>
    /// <param name="worker">The npc</param>
    public void ClickDetect(in Vector2 mousePos, in Worker worker)
    {
        Ray ray = Camera.main.ScreenPointToRay(mousePos);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100f))
        {
            worker.SetTargetPosition(hit.point);
        }

    }
}
