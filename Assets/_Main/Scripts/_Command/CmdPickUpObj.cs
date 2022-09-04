using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The task of picking up the box, the worker walks to the target and pick it up
/// </summary>
public class CmdPickUpObj : ICommand
{
    /// <summary>
    /// My position
    /// </summary>
    private Transform _transform;
    /// <summary>
    /// My speed
    /// </summary>
    private float _speed;
    /// <summary>
    /// The object
    /// </summary>
    private GameObject _grabbedObj;

    //private Collider _objCollider;
    private Transform _hand;
    
    public void Do()
    {
        if (_grabbedObj != null) return;
        CmdMoveTowards moveToObj = new CmdMoveTowards(_transform, _grabbedObj.transform.position, _speed);
        GrabObj();
    }

    private void GrabObj()
    {
        
    }
}
