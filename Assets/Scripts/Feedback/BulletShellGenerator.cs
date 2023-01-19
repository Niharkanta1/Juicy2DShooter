using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

/*=============================================
Product:    Juicy2DShooter v1.0
Developer:  nihar
Company:    DeadW0Lf Games
Date:       19-01-2023 20:25:48
================================================*/ 
public class BulletShellGenerator : ObjectPool {
    [SerializeField]
    private float flyDuration = 0.3f, flyStrength = 1;

    public void SpawnBulletShell() {
        var shell = SpawnObject();
        MoveShellInRandomDirection(shell);
    }

    private void MoveShellInRandomDirection(GameObject shell) {
        shell.transform.DOComplete();
        var randomDirection = Random.insideUnitCircle;
        randomDirection = randomDirection.y > 0 ? new Vector2(randomDirection.x, -randomDirection.y) : randomDirection;
        shell.transform
            .DOMove(((Vector2)transform.position + randomDirection) * flyStrength, flyDuration)
            .OnComplete(()=>shell.GetComponent<AudioSource>()?.Play());
        shell.transform.DORotate(new Vector3(0, 0, Random.Range(0, 360f)), flyDuration);
    }


}