using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/*=============================================
Product:    Juicy2DShooter v1.0
Developer:  nihar
Company:    DeadW0Lf Games
Date:       21-01-2023 14:42:11
================================================*/
public class LineOfSightDecision : AIDecision {
    [SerializeField]
    [Range(1, 15)]
    private float distance = 15;
    [SerializeField]
    private LayerMask raycastMask = new LayerMask();

    [field: SerializeField]
    public UnityEvent OnPlayerSpotted { get; set; }

    public override bool MakeDecision() {
        var direction = enemyBrain.Target.transform.position - transform.position;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, distance, raycastMask);
        if(hit.collider != null && hit.collider.gameObject.layer == LayerMask.NameToLayer("Player")) {
            return true;
        }
        return false;
    }

    private void OnDrawGizmos() {
        if(UnityEditor.Selection.activeObject == gameObject && enemyBrain != null && enemyBrain.Target != null) {
            Gizmos.color = Color.red;
            var direction = enemyBrain.Target.transform.position - transform.position;
            Gizmos.DrawRay(transform.position, direction.normalized * distance);
        }
    }
}