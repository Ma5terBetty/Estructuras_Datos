using UnityEngine;

public class CmdMoveTowards : ICommand
{
    private readonly Rigidbody _rigidBody;
    private readonly Vector3 _target;
    private readonly float _speed;

    public CmdMoveTowards(Rigidbody rigidBody, Vector3 target, float speed)
    {
        _rigidBody = rigidBody;
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
    
        _rigidBody.position = Vector3.MoveTowards(_rigidBody.position, _target, _speed * Time.deltaTime);
    }
}
