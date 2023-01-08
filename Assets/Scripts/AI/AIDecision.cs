using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*=============================================
Product:    Juicy2DShooter v1.0
Developer:  nihar
Company:    DeadW0Lf Games
Date:       07-01-2023 21:43:57
================================================*/ 
public abstract class AIDecision : MonoBehaviour {

    protected AIActionData actionData;
    protected AIMovementData movementData;
    protected EnemyAIBrain enemyBrain;

    private void Awake() {
        actionData = transform.root.GetComponentInChildren<AIActionData>();
        movementData = transform.root.GetComponentInChildren<AIMovementData>();
        enemyBrain = transform.root.GetComponent<EnemyAIBrain>();
    }
    
    public abstract bool MakeDecision();
}