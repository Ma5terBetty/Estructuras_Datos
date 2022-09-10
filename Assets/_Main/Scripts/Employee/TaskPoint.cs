using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public struct Task
{
    public Vector3 Position;
    public TaskPoint TaskPoint;
}
public class TaskPoint : MonoBehaviour
{
    private bool _isClicked;
    
    public static event Action<Task> OnClickedTaskPoint;

    private void OnMouseDown()
    {
        if(_isClicked)
            return;
        _isClicked = true;
#if UNITY_EDITOR
        print("object clicked");
#endif
        OnClickedTaskPoint?.Invoke(new Task(){ Position = transform.position, TaskPoint = this});
    }
}
