using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*=============================================
Product:    Juicy2DShooter v1.0
Developer:  nihar
Company:    DeadW0Lf Games
Date:       02-01-2023 17:26:05
================================================*/

[RequireComponent(typeof(SpriteRenderer))]
public class AgentRenderer : MonoBehaviour {
    protected SpriteRenderer spriteRenderer;

    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void FaceDirection(Vector2 pointerInput) {
        var direction = (Vector3)pointerInput - transform.position;
        var result = Vector3.Cross(Vector2.up, direction);
        if(result.z > 0) {
            spriteRenderer.flipX = true;
        } else if(result.z < 0) {
            spriteRenderer.flipX = false; 
        }
    }
}