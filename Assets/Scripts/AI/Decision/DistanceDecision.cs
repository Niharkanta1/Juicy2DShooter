using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*=============================================
Product:    Juicy2DShooter v1.0
Developer:  nihar
Company:    DeadW0Lf Games
Date:       08-01-2023 22:05:12
================================================*/
public class DistanceDecision : AIDecision {

    [field: SerializeField]
    [field: Range(0.1f, 10)]
    public float Distance { get; set; } = 5f;

    public override bool MakeDecision() {
        if(Vector3.Distance(enemyBrain.Target.transform.position, transform.position) < Distance) {
            if(actionData.TargetSpotted == false) {
                actionData.TargetSpotted = true;
            } 
        } else {
            actionData.TargetSpotted = false;
        }
        return actionData.TargetSpotted;
    }

    protected void OnDrawGizmos() {
        if(UnityEditor.Selection.activeObject == gameObject) {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, Distance);
            Gizmos.color = Color.white;
        }
    }
}