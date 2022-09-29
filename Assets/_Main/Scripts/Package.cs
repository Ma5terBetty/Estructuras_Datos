using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Package : MonoBehaviour
{
    [SerializeField] private PackageTypeSO data;
    private MeshRenderer meshRender;
    private Rigidbody _rigidbody;
    private bool _canUse = true;
    public PackageTypeSO Data { get; private set; }
    public bool CanUse => _canUse;
    
    // No hace falta, si queres saber el nombre podes obtnerlo con Data.Id
    //public string ColorName { get; private set; }

    
    
    private void Awake()
    {
        meshRender = GetComponent<MeshRenderer>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        SetData(data);
    }

    public void SetData(PackageTypeSO newData) //we could use this for spawners
    {
        if (newData == null) return;

        Data = newData;
        meshRender.sharedMaterial.color = data.Color;
        
        //ColorName = Data.Id.ToString();
    }

    public void PickUp(Transform employee, Transform hand)
    {
        if(!_canUse) return;
        
        _rigidbody.isKinematic = true;
        transform.position = hand.position;
        transform.rotation = employee.rotation;
        transform.SetParent(employee);
    }

    public void Drop()
    {
        _rigidbody.isKinematic = false;
        _canUse = false;
    }

    public void SetCanUse(bool input) => _canUse = input;

    private void OnMouseOver()
    {
        var name = Data.Id.ToString();
        UIManager.Instance.ShowName($"{name} package");
    }

    private void OnMouseExit()
    {
        UIManager.Instance.TurnOffName();
    }
}
