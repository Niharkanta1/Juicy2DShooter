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
[RequireComponent(typeof(AudioSource))]
public class AgentStepAudioPlayer : MonoBehaviour {
    
    protected AudioSource audioSource;
    protected float basePitch;
    [SerializeField] protected float pitchRandomness = 0.05f;
    [SerializeField] protected AudioClip stepClip;

    private void Awake() {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start() {
        basePitch = audioSource.pitch;
    }

    protected void PlayClipWithVariablePitch(AudioClip clip) {
        var randomPitch = Random.Range(-pitchRandomness, pitchRandomness);
        audioSource.pitch = basePitch + randomPitch;
        PlayClip(clip);
    }

    protected void PlayClip(AudioClip clip) {
        audioSource.Stop();
        audioSource.clip = clip;
        audioSource.Play();
    }

    public void PlayStepSound() {
        PlayClipWithVariablePitch(stepClip);
    }
}