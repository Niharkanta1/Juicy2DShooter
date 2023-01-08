using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*=============================================
Product:    Juicy2DShooter v1.0
Developer:  nihar
Company:    DeadW0Lf Games
Date:       07-01-2023 21:43:28
================================================*/ 
public class AIActionData : MonoBehaviour {
    [field: SerializeField]
    public bool Attack { get; set; }

    [field: SerializeField]
    public bool TargetSpotted { get; set; }

    [field: SerializeField]
    public bool Arrived { get; set; }
}