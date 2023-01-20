using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*=============================================
Product:    Juicy2DShooter v1.0
Developer:  nihar
Company:    DeadW0Lf Games
Date:       04-01-2023 15:26:56
================================================*/ 
public class PlayerWeapon : AgentWeapon {
    [SerializeField]
    private UIAmmo uiAmmo;

    public bool AmmoFull { 
        get=> weapon!=null && weapon.AmmoFull; 
    }

    private void Start() {
        if (weapon == null)
            return;
        weapon.OnAmmoChange.AddListener(uiAmmo.UpdateBulletsText);
        uiAmmo.UpdateBulletsText(weapon.Ammo);
    }

    public void AddAmmo(int amount) {
        if (weapon == null)
            return;
        weapon.Ammo += amount;
    }
}