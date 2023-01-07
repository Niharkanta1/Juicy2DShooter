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
public class Enemy : MonoBehaviour, IHittable {

    [field: SerializeField]
    public EnemyDataSO EnemyData { get; set; }

    [field: SerializeField]
    public int Health { get; private set; } = 2;

    [field: SerializeField]
    public UnityEvent OnGetHit { get; set; }
    [field: SerializeField]
    public UnityEvent OnDie { get; set; }

    private void Start() {
        Health = EnemyData.MaxHealth; 
    }

    public void GetHit(int damage, GameObject damageDealer) {
        Health--;
        OnGetHit?.Invoke();
        if(Health <= 0) {
            OnDie?.Invoke();
        }
    }

    private IEnumerator WaitToDie() {
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);
    }
}