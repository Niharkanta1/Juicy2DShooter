using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*=============================================
Product:    Juicy2DShooter v1.0
Developer:  nihar
Company:    DeadW0Lf Games
Date:       02-01-2023 17:11:26
================================================*/
[RequireComponent(typeof(Animator))]
public class AgentAnimations : MonoBehaviour {
    protected Animator agentAnimator;

    private void Awake() {
        agentAnimator = GetComponent<Animator>();
    }

    public void SetMovingAnimation(bool val) {
        agentAnimator.SetBool("isMoving", val);
    }

    public void AnimatePlayer(float velocity) {
        SetMovingAnimation(velocity > 0);
    }
}