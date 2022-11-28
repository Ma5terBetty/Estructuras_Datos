using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PalletTosser : MonoBehaviour, IInteractable
{
    /*private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Employee")) return;

        GameManager.Instance.ResetLevel();
    }*/

    public void Interact(Collider other)
    {
        if (!other.CompareTag("Employee")) return;

        GameManager.Instance.ResetLevel();
    }
}
