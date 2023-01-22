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
    private PlayerWeapon playerWeapon;

    [field: SerializeField]
    public UIHealth uiHealth { get; set; }

    [field: SerializeField]
    public UnityEvent OnGetHit { get; set; }

    [field: SerializeField]
    public UnityEvent OnDie { get; set; }

    private void Awake() {
        playerWeapon = GetComponentInChildren<PlayerWeapon>();
    }

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

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Items")) {
            var item = collision.gameObject.GetComponent<Resource>();
            if(item != null) {
                switch (item.ResourceData.resourceType) {
                    case ResourceType.None:
                        break;
                    case ResourceType.Health:
                        if (Health >= maxHealth) return;
                        Health += item.ResourceData.getAmount();
                        item.PickupResource();
                        break;
                    case ResourceType.Ammo:
                        if (playerWeapon.AmmoFull) return;
                        playerWeapon.AddAmmo(item.ResourceData.getAmount());
                        item.PickupResource();
                        break;
                }
            }
        }
    }
}