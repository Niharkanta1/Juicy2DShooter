using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/*=============================================
Product:    Juicy2DShooter v1.0
Developer:  nihar
Company:    DeadW0Lf Games
Date:       04-01-2023 16:28:26
================================================*/
public class Weapon : MonoBehaviour {

    [SerializeField]
    protected GameObject muzzle;
    [SerializeField]
    protected WeaponDataSO weaponData;

    [SerializeField]
    protected int ammo = 20;

    public int Ammo
    {
        get { return ammo; }
        set {
            ammo = Mathf.Clamp(value, 0, weaponData.AmmoCapacity);
        }
    }

    public bool AmmoFull { get => Ammo >= weaponData.AmmoCapacity; }

    protected bool isShooting = false;

    [SerializeField]
    protected bool reloadCoroutine = false;

    [field: SerializeField]
    public UnityEvent OnShoot { get; set; }
    [field: SerializeField]
    public UnityEvent OnShootNoAmmo { get; set; }

    private void Start() {
        Ammo = weaponData.AmmoCapacity;
    }

    private void Update() {
        UseWeapon();
    }

    private void UseWeapon() {
        if(isShooting && !reloadCoroutine) {
            if(Ammo > 0) {
                Ammo--;
                OnShoot?.Invoke();
                for (int i = 0; i < weaponData.GetBulletCountToSpawn(); i++) {
                    ShootBullet();
                }
            } else {
                isShooting = false;
                OnShootNoAmmo?.Invoke();
                return;
            }
            FinishShoot();
        }
    }

    private void ShootBullet() {
        Debug.Log("Shooting Bullet");
    }

    private void FinishShoot() {
        StartCoroutine(DelayNextShootCoroutine());
        if(weaponData.AutomaticFire == false) {
            isShooting = false;
        }
    }

    private IEnumerator DelayNextShootCoroutine() {
        reloadCoroutine = true;
        yield return new WaitForSeconds(weaponData.WeaponDelay);
        reloadCoroutine = false;
    }

    public void TryShooting() {
        isShooting = true;
    }

    public void StopShoot() {
        isShooting = false;
    }

    public void ReloadAmmo(int ammo) {
        Ammo += ammo;
    }
}