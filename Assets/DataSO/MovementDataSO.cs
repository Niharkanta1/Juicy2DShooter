using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*=============================================
Product:    Juicy2DShooter v1.0
Developer:  nihar
Company:    DeadW0Lf Games
Date:       02-01-2023 11:11:03
================================================*/
[CreateAssetMenu(menuName ="Agent/MovementData")]
public class MovementDataSO : ScriptableObject {
    [Range(1, 10)]
    public float maxSpeed = 5f;

    [Range(0.1f, 100)]
    public float acceleration = 50, deacceleration = 50;
}