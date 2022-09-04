using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CmdMoveTowards : ICommand
{
    private Transform _transform;
    private Vector3 _target;
    private float _speed;

    public CmdMoveTowards(Transform transform, Vector3 target, float speed)
    {
        _transform = transform;
        _target = target;
        _speed = speed;
    }

    public void Do()
    {
        _transform.position = Vector3.MoveTowards(_transform.position, _target, _speed * Time.deltaTime);
    }
}
