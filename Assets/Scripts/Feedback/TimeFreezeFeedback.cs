using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*=============================================
Product:    Juicy2DShooter v1.0
Developer:  nihar
Company:    DeadW0Lf Games
Date:       18-01-2023 16:09:15
================================================*/
public class TimeFreezeFeedback : Feedback {

    [SerializeField]
    private float freezeTimeDelay = 0.01f, unfreezeTimeDelay = 0.02f;
    [SerializeField]
    [Range(0, 1)]
    private float freezeTimeValue = 0.2f;

    public override void CompletePrevFeedback() {
        if (TimeController.instance != null)
            TimeController.instance.ResetTimeScale();
    }

    public override void CreateFeedback() {
        TimeController.instance.ModifyTimeScale(freezeTimeValue, freezeTimeDelay, 
            () => TimeController.instance.ModifyTimeScale(1, unfreezeTimeDelay));
    }
}