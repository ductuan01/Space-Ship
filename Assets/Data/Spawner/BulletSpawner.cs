using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : Spawner
{
    private static BulletSpawner instance;
    public static BulletSpawner Instance { get => instance; }

    public static string bulletOne = "Bullet_1";
    public static string bulletTwo = "Bullet_2";
    public static string bulletThree = "Bullet_3";


    protected override void Awake()
    {
        base.Awake();
        if (BulletSpawner.instance != null) Debug.LogError("Only 1 InputManager allow to exist");
        BulletSpawner.instance = this;
    }
}
