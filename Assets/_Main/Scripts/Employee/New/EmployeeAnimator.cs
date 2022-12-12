using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmployeeAnimator : MonoBehaviour
{
    private Employee _employee;
    private Animator _animator;

    private void Awake()
    {
        _employee = GetComponent<Employee>();
        _animator = GetComponent<Animator>();
    }

    private enum AnimationStates
    {
        Idle,
        Walking,
        BoxIdle,
        BoxWalking
    }
    
    private AnimationStates _currAnimState;

    private void FixedUpdate()
    {
        SetAnimation();
    }

    private void SetAnimation()
    {
        if (!_employee.HasPackage)
        {
            _currAnimState = _employee.IsDoingTask ? AnimationStates.Walking : AnimationStates.Idle;
        }
        else
        {
            _currAnimState = _employee.IsDoingTask ? AnimationStates.BoxWalking : AnimationStates.BoxIdle;
        }
        
        _animator.SetInteger("State", (int)_currAnimState);
    }
}
