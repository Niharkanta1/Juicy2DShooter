using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*=============================================
Product:    Juicy2DShooter v1.0
Developer:  nihar
Company:    DeadW0Lf Games
Date:       09-01-2023 19:57:55
================================================*/
public class EnemyMeleeAttack : EnemyAttack {


    public override void Attack(int damage) {
        if (waitBeforeAttack)
            return;

        var hittable = GetTarget().GetComponent<IHittable>();
        hittable?.GetHit(damage, gameObject);
        StartCoroutine(WaitBeforeAttackCoroutine());
    }
}