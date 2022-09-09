using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class TaskPoint : MonoBehaviour
{
    public static event Action<TaskPoint> OnClickedTaskPoint;
    private bool _isClicked;

    private void OnMouseDown()
    {
        if(_isClicked)
            return;
        _isClicked = true;
#if UNITY_EDITOR
        print("object clicked");
#endif
        OnClickedTaskPoint?.Invoke(this);
    }
}
