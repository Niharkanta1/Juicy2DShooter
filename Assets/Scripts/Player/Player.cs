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

    [SerializeField]
    private int maxHealth = 3;
 
    private int health;
    public int Health {
        get => health;
        set {
            health = Mathf.Clamp(value, 0, maxHealth);
            uiHealth.UpdateHealthUI(health);
        }
    }

    private bool dead = false;

    [field: SerializeField]
    public UIHealth uiHealth { get; set; }

    [field: SerializeField]
    public UnityEvent OnGetHit { get; set; }

    [field: SerializeField]
    public UnityEvent OnDie { get; set; }

    private void Start() {
        Health = maxHealth;
        uiHealth.Initialize(Health);
    }

    public void GetHit(int damage, GameObject damageDealer) {
        if (dead)
            return;

        Health -= damage;
        OnGetHit?.Invoke();
        if(Health <= 0) {
            dead = true;
            OnDie?.Invoke();
            //StartCoroutine(DeathCoroutine());
        }
    }

    //IEnumerator DeathCoroutine() {
    //    yield return new WaitForSeconds(0.5f);
    //    Destroy(gameObject);
    //}
}