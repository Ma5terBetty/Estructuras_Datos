using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorPoolTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        transform.parent.gameObject.GetComponent<ConveyorPool>().OnChildTriggerEntered(other, gameObject.name);
    }
}
