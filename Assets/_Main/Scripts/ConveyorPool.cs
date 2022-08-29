using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorPool : MonoBehaviour
{
    Transform output;

    [SerializeField]
    float dropRate = 3f;
    float dropTimer = 0;

    List<GameObject> packages = new List<GameObject>();

    private void Awake()
    {
        output = transform.GetChild(0);
    }
    private void Update()
    {
        dropTimer += Time.deltaTime;

        if (dropTimer >= dropRate) DropPackage();
    }

    public void OnChildTriggerEntered(Collider other, string name)
    {
        if (name == "Input")
        { 
            packages.Add(other.gameObject);
            other.gameObject.SetActive(false);
        }
    }

    void DropPackage()
    { 
        if (packages.Count > 0)
        { 
            packages[0].gameObject.SetActive(true);
            packages[0].gameObject.transform.position = output.position;
            packages[0].gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            packages[0].transform.rotation = new Quaternion(0,0,0,0);
            packages.Remove(packages[0]);
        }

        dropTimer = 0;
    }
}
