using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*=============================================
Product:    Juicy2DShooter v1.0
Developer:  nihar
Company:    DeadW0Lf Games
Date:       05-01-2023 12:35:59
================================================*/

[CreateAssetMenu(menuName = "Weapon/BulletData")]
public class BulletDataSO : ScriptableObject {

    [field: SerializeField]
    public GameObject BulletPrefab { get; set; }

    [field: SerializeField]
    [field: Range(1, 100)]
    public float BulletSpeed { get; internal set; } = 20;

    [field: SerializeField]
    [field: Range(1, 10)]
    public int Damage { get; set; } = 1;

    [field: SerializeField]
    [field: Range(0f, 100f)]
    public float Friction { get; internal set; } = 0f;

    [field: SerializeField]
    public bool Bounce { get; set; } = false;

    [field: SerializeField]
    public bool GoThroughHittable { get; set; } = false;

    [field: SerializeField]
    public bool IsRaycast { get; set; } = false;

    [field: SerializeField]
    public GameObject ImpactObstaclePrefab { get; set; }

    [field: SerializeField]
    public GameObject ImpactEnemyPrefab { get; set; }

    [field: SerializeField]
    [field: Range(1, 20)]
    public float KnockBackPower { get; set; } = 5;

    [field: SerializeField]
    [field: Range(0.01f, 1f)]
    public float KnockBackDelay { get; set; } = 0.1f;


}