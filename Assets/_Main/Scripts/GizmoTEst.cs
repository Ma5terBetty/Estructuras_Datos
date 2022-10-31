using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class GizmoTEst : MonoBehaviour
{
    [SerializeField]
    GameObject a;
    [SerializeField]
    GameObject b;
    [SerializeField]
    GameObject c;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 rayDir = a.transform.position - b.transform.position;
        Gizmos.DrawRay(a.transform.localPosition, -rayDir);
        rayDir = a.transform.position - c.transform.position;
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(a.transform.localPosition, -rayDir);
    }
}
