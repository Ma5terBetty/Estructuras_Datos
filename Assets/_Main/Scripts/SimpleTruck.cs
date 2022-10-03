using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTruck : MonoBehaviour
{ 
    [SerializeField] private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        Suscribe();
    }
    private void Update()
    {
        Test();
    }

    public void StartPallet()
    {
        GameManager.Instance.TruckArrived();
        GameManager.Instance.OrderController.GenerateOrder();
    }
    
    public void ChangeToIdle()
    {
        Unsuscribe();
        if(animator)
            animator.SetBool("IsWaiting", true);
    }
    public void ChangeToLeaving()
    {
        if(animator)
            animator.SetBool("IsWaiting", false);
        Suscribe();
    }

    void Test()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            animator.SetBool("IsWaiting", false);
        }
    }

    private void Suscribe()
    {
        GameManager.OnTruckArrives += ChangeToIdle;
        GameManager.OnTruckArrives -= ChangeToLeaving;
    }

    private void Unsuscribe()
    {
        GameManager.OnTruckLeaves -= ChangeToIdle;
        GameManager.OnTruckLeaves += ChangeToLeaving;
    }
}
