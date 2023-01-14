using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

/*=============================================
Product:    Juicy2DShooter v1.0
Developer:  nihar
Company:    DeadW0Lf Games
Date:       05-01-2023 12:42:34
================================================*/
public class BulletRegular : Bullet {
    protected Rigidbody2D rb2d;

    public override BulletDataSO BulletData { 
        get => base.BulletData;
        set { 
            base.BulletData = value;
            rb2d = GetComponent<Rigidbody2D>();
            rb2d.drag = BulletData.Friction;
        }
    }

    private void FixedUpdate() {
        if(rb2d != null && bulletData != null) {
            rb2d.MovePosition(transform.position + bulletData.BulletSpeed * transform.right * Time.fixedDeltaTime);
        } 
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        
        if (collision.gameObject.layer == LayerMask.NameToLayer("Obstacle")) {
            HitObstacle(collision);
        } else if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy")) {
            var hittable = collision.GetComponent<IHittable>();
            hittable?.GetHit(bulletData.Damage, gameObject);
            HitEnemy(collision);
        }
        Destroy(gameObject);
    }

    private void HitEnemy(Collider2D collision) {
        Vector2 randomOffset = Random.insideUnitCircle * 0.5f;
        Instantiate(BulletData.ImpactEnemyPrefab, collision.transform.position + (Vector3)randomOffset, Quaternion.identity);
    }

    private void HitObstacle(Collider2D collision) {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right);
        if(hit.collider != null) {
            Instantiate(BulletData.ImpactObstaclePrefab, hit.point, Quaternion.identity);
        }
    }
}