using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CmdMoveTowards : ICommand
{
    private readonly Transform _transform;
    private readonly Vector3 _target;
    private readonly float _speed;

    public CmdMoveTowards(Transform transform, Vector3 target, float speed)
    {
        _transform = transform;
        _target = target;
        _speed = speed;
    }

    public void Do()
    {
        // var position = _transform.position;
        // var dir = _target - position;
        // dir.Normalize();
        // position += dir * (_speed * Time.deltaTime);
        // _transform.position = position;

        _transform.position = Vector3.MoveTowards(_transform.position, _target, _speed * Time.deltaTime);
    }
}
