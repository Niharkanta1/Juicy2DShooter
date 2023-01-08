using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*=============================================
Product:    Juicy2DShooter v1.0
Developer:  nihar
Company:    DeadW0Lf Games
Date:       08-01-2023 22:17:16
================================================*/
public class ChaseAction : AIAction {

    public override void TakeAction() {
        var direction = enemyBrain.Target.transform.position - transform.position;
        movementData.Direction = direction.normalized;
        movementData.PointOfIntrest = enemyBrain.Target.transform.position;
        enemyBrain.Move(movementData.Direction, movementData.PointOfIntrest);
    }
}