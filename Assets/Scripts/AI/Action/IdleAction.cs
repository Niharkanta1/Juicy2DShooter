using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*=============================================
Product:    Juicy2DShooter v1.0
Developer:  nihar
Company:    DeadW0Lf Games
Date:       08-01-2023 22:25:50
================================================*/
public class IdleAction : AIAction {
    public override void TakeAction() {
        movementData.Direction = Vector2.zero;
        movementData.PointOfIntrest = transform.position;
        enemyBrain.Move(movementData.Direction, movementData.PointOfIntrest);
    }
}