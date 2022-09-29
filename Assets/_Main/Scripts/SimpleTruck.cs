using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTruck : MonoBehaviour
{
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        OnEnable();
    }
    private void Update()
    {
        Test();
    }

    void StartPallet()
    {
        GameManager.Instance.TruckArrived();
        GameManager.Instance.OrderController.GenerateOrder();
    }
    public void ChangeToIdle()
    {
        OnDisable();
        animator.SetBool("IsWaiting", true);
    }
    public void ChangeToLeaving()
    {
        animator.SetBool("IsWaiting", false);
        OnEnable();
    }

    void Test()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            animator.SetBool("IsWaiting", false);
        }
    }

    private void OnEnable()
    {
        GameManager.OnTruckArrives += ChangeToIdle;
        GameManager.OnTruckArrives -= ChangeToLeaving;
    }

    private void OnDisable()
    {
        GameManager.OnTruckLeaves -= ChangeToIdle;
        GameManager.OnTruckLeaves += ChangeToLeaving;
    }
}
