using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

/*=============================================
Product:    Juicy2DShooter v1.0
Developer:  nihar
Company:    DeadW0Lf Games
Date:       11-01-2023 22:48:27
================================================*/
public class FeedbackFlashLight : Feedback {

    [SerializeField]
    private Light2D muzzleLight = null;
    [SerializeField]
    private float lightOnDelay = 0.01f, lightOffDelay = 0.01f;
    [SerializeField]
    private bool defaultState = false;
    [SerializeField]
    private SpriteRenderer muzzleSprite = null;

    public override void CompletePrevFeedback() {
        StopAllCoroutines();
        muzzleLight.enabled = defaultState;
        muzzleSprite.enabled = defaultState;
    }

    public override void CreateFeedback() {
        StartCoroutine(ToggleLightCoroutine(lightOnDelay, true, () => StartCoroutine(ToggleLightCoroutine(lightOffDelay, false))));
    }

    IEnumerator ToggleLightCoroutine(float time, bool result, Action FinishCallback = null) {
        yield return new WaitForSeconds(time);
        muzzleLight.enabled = result;
        muzzleSprite.enabled = result;
        FinishCallback?.Invoke();
    }
}