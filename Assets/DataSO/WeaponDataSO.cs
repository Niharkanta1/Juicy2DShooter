using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*=============================================
Product:    Juicy2DShooter v1.0
Developer:  nihar
Company:    DeadW0Lf Games
Date:       04-01-2023 16:56:52
================================================*/
[CreateAssetMenu(menuName = "Weapon/WeaponData")]
public class WeaponDataSO : ScriptableObject {

    [field: SerializeField]
    [field: Range(0, 100)]
    public int AmmoCapacity { get; set; }

    [field: SerializeField]
    public bool AutomaticFire { get; set; } = false;

    [field: SerializeField]
    [field: Range(0.1f, 2f)]
    public float WeaponDelay { get; set; } = 0.1f;

    [field: SerializeField]
    [field: Range(0, 10f)]
    public float SpreadAngle { get; set; } = 5;

    [SerializeField]
    private bool multiBulletShot = false;
    [SerializeField]
    [Range(1, 10)]
    private int bulletCount = 1;

    internal int GetBulletCountToSpawn() {
        return multiBulletShot ? bulletCount : 1;
    }
}