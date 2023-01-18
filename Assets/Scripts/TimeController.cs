using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*=============================================
Product:    Juicy2DShooter v1.0
Developer:  nihar
Company:    DeadW0Lf Games
Date:       18-01-2023 15:59:44
================================================*/ 
public class TimeController : MonoBehaviour {

    public static TimeController instance;
    private void Awake() {
        if(instance == null) {
            instance = this;
        } else if (instance != this) {
            Destroy(this);
        }
    }

    public void ModifyTimeScale(float endTimeValue, float timeToWait, Action OnCompleteCallback = null) {
        StartCoroutine(TimeScaleCoroutine(endTimeValue, timeToWait, OnCompleteCallback));
    }

    IEnumerator TimeScaleCoroutine(float endTimeValue, float timeToWait, Action OnCompleteCallback) {
        yield return new WaitForSecondsRealtime(timeToWait);
        Time.timeScale = endTimeValue;
        OnCompleteCallback?.Invoke();
    }

    public void ResetTimeScale() {
        StopAllCoroutines();
        Time.timeScale = 1;
    }
}