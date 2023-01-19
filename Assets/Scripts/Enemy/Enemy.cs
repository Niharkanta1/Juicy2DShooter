using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/*=============================================
Product:    Juicy2DShooter v1.0
Developer:  nihar
Company:    DeadW0Lf Games
Date:       06-01-2023 15:42:59
================================================*/
public class Enemy : MonoBehaviour, IHittable, IAgent, IKnockback {

    [field: SerializeField]
    public EnemyDataSO EnemyData { get; set; }

    [field: SerializeField]
    public int Health { get; private set; } = 2;

    [field: SerializeField]
    public EnemyAttack enemyAttack { get; set; }

    private AgentMovement agentMovement;

    //[SerializeField]
    //private float despwanTimer = 0.5f;

    private bool dead = false;

    [field: SerializeField]
    public UnityEvent OnGetHit { get; set; }
    [field: SerializeField]
    public UnityEvent OnDie { get; set; }

    private void Awake() {
        if(enemyAttack == null) {
            enemyAttack = GetComponent<EnemyAttack>();
        }

        agentMovement = GetComponent<AgentMovement>();
    }

    private void Start() {
        Health = EnemyData.MaxHealth;
    }

    public void GetHit(int damage, GameObject damageDealer) {
        if (dead)
            return;

        Health -= damage;
        OnGetHit?.Invoke();
        if (Health <= 0) {
            dead = true;
            OnDie?.Invoke();
        }
    }

    //private IEnumerator WaitToDie() {
    //    yield return new WaitForSeconds(despwanTimer);
    //    Destroy(gameObject);
    //}

    public void Die() {
        Destroy(gameObject);
    }

    public void PerformAttack() {
        if(!dead) {
            enemyAttack.Attack(EnemyData.Damage);
        }
    }

    public void KnockBack(Vector2 direction, float power, float duration) {
        agentMovement.KnockBack(direction, power, duration);
    }
}