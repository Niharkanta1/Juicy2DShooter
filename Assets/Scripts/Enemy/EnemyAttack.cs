using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*=============================================
Product:    Juicy2DShooter v1.0
Developer:  nihar
Company:    DeadW0Lf Games
Date:       09-01-2023 19:51:56
================================================*/ 
public abstract class EnemyAttack : MonoBehaviour {

    protected EnemyAIBrain enemyBrain;

    [field: SerializeField]
    public float AttackDelay { get; set; }
    protected bool waitBeforeAttack;

    private void Awake() {
        enemyBrain = GetComponent<EnemyAIBrain>();
    }

    public abstract void Attack(int damage);
    protected IEnumerator WaitBeforeAttackCoroutine() {
        waitBeforeAttack = true;
        yield return new WaitForSeconds(AttackDelay);
        waitBeforeAttack = false;
    }

    protected GameObject GetTarget() {
        return enemyBrain.Target;
    }
}