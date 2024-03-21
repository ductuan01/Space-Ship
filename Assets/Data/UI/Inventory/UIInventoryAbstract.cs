using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIInventoryAbstract : SameMonoBehaviour
{
    
    [Header("UIInventory Abstract")]
    [Header("Inv Item Spawner")]
    [SerializeField] protected UIInventoryCtrl inventoryCtrl;
    public UIInventoryCtrl InventoryCtrl => inventoryCtrl;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadInventoryCtrl();
    }

    protected virtual void LoadInventoryCtrl()
    {
        if (this.inventoryCtrl != null) return;
        this.inventoryCtrl = transform.parent.GetComponent<UIInventoryCtrl>();
        Debug.Log(transform.name + ": LoadInventoryCtrl", gameObject);
    }
}
