using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*=============================================
Product:    Juicy2DShooter v1.0
Developer:  nihar
Company:    DeadW0Lf Games
Date:       06-01-2023 15:55:47
================================================*/
[CreateAssetMenu(menuName = "Enemy/EnemyData")]
public class EnemyDataSO : ScriptableObject {

    [field:SerializeField]
    public int MaxHealth { get; set; } = 3;

    [field: SerializeField]
    public int Damage { get; set; } = 1;
}