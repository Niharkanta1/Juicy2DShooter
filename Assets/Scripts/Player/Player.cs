using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/*=============================================
Product:    Juicy2DShooter v1.0
Developer:  nihar
Company:    DeadW0Lf Games
Date:       07-01-2023 20:59:03
================================================*/
public class Player : MonoBehaviour, IAgent, IHittable {

    [field: SerializeField]
    public int Health { get; set; } = 3;

    private bool dead = false;

    [field: SerializeField]
    public UnityEvent OnGetHit { get; set; }

    [field: SerializeField]
    public UnityEvent OnDie { get; set; }

    public void GetHit(int damage, GameObject damageDealer) {
        if (dead)
            return;

        Health -= damage;
        OnGetHit?.Invoke();
        if(Health <= 0) {
            dead = true;
            OnDie?.Invoke();
            StartCoroutine(DeathCoroutine());
        }
    }

    IEnumerator DeathCoroutine() {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}