using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class GizmoTEst : MonoBehaviour
{
    [SerializeField]
    GameObject a;
    [SerializeField]
    Transform[] transforms = new Transform[10];

    private void OnDrawGizmos()
    {
        for (int i = 0; i < transforms.Length; i++)
        {
            Gizmos.color = Color.red;
            Vector3 rayDir = a.transform.position - transforms[i].transform.position;
            Gizmos.DrawRay(a.transform.localPosition, -rayDir);
        }
    }
}
