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
    void Start()
    {
        
    }

    public void ChangeToIdle()
    {
        animator.SetBool("IsWaiting", true);
    }

    public void ChangeToLeaving()
    {
        animator.SetBool("IsWaiting", false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
