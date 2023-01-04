using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*=============================================
Product:    Juicy2DShooter v1.0
Developer:  nihar
Company:    DeadW0Lf Games
Date:       04-01-2023 15:47:58
================================================*/
[RequireComponent(typeof(SpriteRenderer))]
public class WeaponRenderer : MonoBehaviour {

    [SerializeField]
    protected int playerSortingOrder = 0;
    protected SpriteRenderer weaponRenderer;

    private void Awake() {
        weaponRenderer = GetComponent<SpriteRenderer>();
    }

    public void FlipSprite(bool value) {
        if (value) {
            transform.localScale = new Vector3(transform.localScale.x, -1 * Mathf.Abs(transform.localScale.y), transform.localScale.z);
        } else {
            transform.localScale = new Vector3(transform.localScale.x, 1 * Mathf.Abs(transform.localScale.y), transform.localScale.z);
        }
    }

    public void RenderBehindHead(bool value) {
        if(value) {
            weaponRenderer.sortingOrder = playerSortingOrder - 1;
        } else {
            weaponRenderer.sortingOrder = playerSortingOrder + 1;
        }
    }


}