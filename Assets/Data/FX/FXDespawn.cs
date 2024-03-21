using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXDespawn : DesSpawnByTime
{
    public override void DespawnObject()
    {
        FXSpawner.Instance.Despawn(transform.parent);
    }
}
