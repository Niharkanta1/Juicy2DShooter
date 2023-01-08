using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*=============================================
Product:    Juicy2DShooter v1.0
Developer:  nihar
Company:    DeadW0Lf Games
Date:       08-01-2023 22:33:31
================================================*/
public class AttackAction : AIAction {
    public override void TakeAction() {
        movementData.Direction = Vector2.zero;
        movementData.PointOfIntrest = enemyBrain.Target.transform.position;
        enemyBrain.Move(movementData.Direction, movementData.PointOfIntrest);
        actionData.Attack = true;
        enemyBrain.Attack();
    }
}