using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Package : MonoBehaviour
{
    [SerializeField] private PackageTypeSO data;
    private MeshRenderer meshRender;
    public PackageTypeSO Data { get; private set; }
    // No hace falta, si queres saber el nombre podes obtnerlo con Data.Id
    //public string ColorName { get; private set; }

    
    
    private void Awake()
    {
        meshRender = GetComponent<MeshRenderer>();
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
