using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

/*=============================================
Product:    Juicy2DShooter v1.0
Developer:  nihar
Company:    DeadW0Lf Games
Date:       02-01-2023 17:47:49
================================================*/ 
public class AgentStepAudioPlayer : AudioPlayer {
    
    [SerializeField] protected AudioClip stepClip;

    public void PlayStepSound() {
        PlayClipWithVariablePitch(stepClip);
    }
}