using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*=============================================
Product:    Juicy2DShooter v1.0
Developer:  nihar
Company:    DeadW0Lf Games
Date:       04-01-2023 15:18:16
================================================*/ 
public class AgentWeapon : MonoBehaviour {

    protected float desiredAngle;

    protected WeaponRenderer weaponRenderer;
    protected Weapon weapon;

    private void Awake() {
        AssignWeapon();
    }

    private void AssignWeapon() {
        weaponRenderer = GetComponentInChildren<WeaponRenderer>();
        weapon = GetComponentInChildren<Weapon>();
    }

    public virtual void AimWeapon(Vector2 pointerPos) {
        var aimDirection = (Vector3)pointerPos - transform.position;
        desiredAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        AdjustWeaponRendering();
        transform.rotation = Quaternion.AngleAxis(desiredAngle, Vector3.forward);
    }

    protected void AdjustWeaponRendering() {
        if (weaponRenderer == null)
            return;

        weaponRenderer?.FlipSprite(desiredAngle > 90 || desiredAngle < -90);
        weaponRenderer?.RenderBehindHead(desiredAngle < 180 && desiredAngle > 0);
    }

    public void Shoot() {
        weapon?.TryShooting();
    }

    public void StopShooting() {
        weapon?.StopShoot();
    }
}