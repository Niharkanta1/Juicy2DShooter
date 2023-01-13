using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*=============================================
Product:    Juicy2DShooter v1.0
Developer:  nihar
Company:    DeadW0Lf Games
Date:       13-01-2023 15:44:52
================================================*/
public class ShakeFeedback : Feedback {

    [SerializeField]
    private GameObject objectToShake;
    [SerializeField]
    private float duration = 0.2f, strength = 1, randomness = 90;
    [SerializeField]
    private int vibrato = 10;
    [SerializeField]
    private bool snapping = false, fadeout = true;


    public override void CompletePrevFeedback() {
        objectToShake.transform.DOComplete();
    }

    public override void CreateFeedback() {
        CompletePrevFeedback();
        objectToShake.transform.DOShakePosition(duration, strength, vibrato, randomness, snapping, fadeout);
    }
}