using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorPool : MonoBehaviour
{
    Transform output;
    GameObject temp;

    [SerializeField]
    float dropRate = 3f;
    float dropTimer = 0;

    CustomQueue<GameObject> poolPacakges = new CustomQueue<GameObject>();

    private void Awake()
    {
        output = transform.GetChild(0);
    }
    private void Start()
    {
        poolPacakges.InitializeQueue();
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
            poolPacakges.Enqueue(other.gameObject);
            other.gameObject.SetActive(false);
        }
    }

    void DropPackage()
    { 
        if (!poolPacakges.IsQueueEmpty())
        { 
            temp = poolPacakges.Peek();
            temp.gameObject.SetActive(true);
            temp.gameObject.transform.position = output.position;
            temp.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            temp.gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
            poolPacakges.Dequeue();
            temp = null;
        }

        dropTimer = 0;
    }
}
