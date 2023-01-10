using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*=============================================
Product:    Juicy2DShooter v1.0
Developer:  nihar
Company:    DeadW0Lf Games
Date:       10-01-2023 19:54:17
================================================*/ 
public class FeedbackPlayer : MonoBehaviour {
    [SerializeField]
    private List<Feedback> feedBackToPlay = null;

    public void PlayFeedback() {
        FinishFeedback();
        foreach (var feedback in feedBackToPlay) {
            feedback.CreateFeedback();
        }
    }

    private void FinishFeedback() {
        foreach (var feedback in feedBackToPlay) {
            feedback.CompletePrevFeedback();
        }
    }
}