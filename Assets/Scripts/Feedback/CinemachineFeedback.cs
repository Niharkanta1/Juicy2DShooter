using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*=============================================
Product:    Juicy2DShooter v1.0
Developer:  nihar
Company:    DeadW0Lf Games
Date:       13-01-2023 16:00:05
================================================*/
public class CinemachineFeedback : Feedback {

    [SerializeField]
    private CinemachineVirtualCamera cmVcam;
    [SerializeField]
    [Range(0,5)]
    private float amplitude = 1, intensity = 1;
    [SerializeField]
    [Range(0,1)]
    private float duration = 0.1f;

    private CinemachineBasicMultiChannelPerlin noise;

    private void Start() {
        if(cmVcam == null) {
            cmVcam = FindObjectOfType<CinemachineVirtualCamera>();
            noise = cmVcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        }
    }

    public override void CompletePrevFeedback() {
        StopAllCoroutines();
        noise.m_AmplitudeGain = 0f;
    }

    public override void CreateFeedback() {
        noise.m_AmplitudeGain = amplitude;
        noise.m_FrequencyGain = intensity;
        StartCoroutine(ShakeCoroutine());
    }

    private IEnumerator ShakeCoroutine() {
        for(float i = duration; i > 0; i -= Time.deltaTime) {
            noise.m_AmplitudeGain = Mathf.Lerp(0, amplitude, i/duration);
            yield return null;
        }
        noise.m_AmplitudeGain = 0;
    }
}