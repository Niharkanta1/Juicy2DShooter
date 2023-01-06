using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if(collision.gameObject.layer == LayerMask.NameToLayer("Obstacle")) {
            HitObstacle();
        }
        Destroy(gameObject);
    }

    private void HitObstacle() {
        
    }
}