using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*=============================================
Product:    Juicy2DShooter v1.0
Developer:  nihar
Company:    DeadW0Lf Games
Date:       07-01-2023 21:42:21
================================================*/ 
public class AIMovementData : MonoBehaviour {

    [field: SerializeField]
    public Vector2 Direction { get; set; }

    [field: SerializeField]
    public Vector2 PointOfIntrest { get; set; }
}