using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The task of picking up the box, the worker walks to the target and pick it up
/// </summary>
public class CmdPickUpObj : ICommand
{
    private Transform _transform;
    private float _speed;
    private GameObject _grabbedObj;

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
