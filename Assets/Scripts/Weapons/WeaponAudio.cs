using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*=============================================
Product:    Juicy2DShooter v1.0
Developer:  nihar
Company:    DeadW0Lf Games
Date:       05-01-2023 14:25:12
================================================*/
public class WeaponAudio : AudioPlayer {

    [SerializeField]
    private AudioClip shootBulletClip = null, outOfBulletsClip = null;

    public void PlayShootSound() {
        PlayClip(shootBulletClip);
    }

    public void PlayNoBulletsSound() {
        PlayClip(outOfBulletsClip);
    }
}