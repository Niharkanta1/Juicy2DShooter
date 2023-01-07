using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*=============================================
Product:    Juicy2DShooter v1.0
Developer:  nihar
Company:    DeadW0Lf Games
Date:       06-01-2023 16:07:23
================================================*/ 
public class AgentSounds : AudioPlayer {

    [SerializeField]
    private AudioClip hitClip = null, deathClip = null, voiceLineClip = null;

    public void PlayHitSound() {
        PlayClipWithVariablePitch(hitClip);
    }

    public void PlayDeathSound() {
        PlayClip(deathClip);
    }

    public void PlayVoiceLine() {
        PlayClipWithVariablePitch(voiceLineClip);
    }
}