using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/*=============================================
Product:    Juicy2DShooter v1.0
Developer:  nihar
Company:    DeadW0Lf Games
Date:       17-01-2023 22:22:07
================================================*/
public class DissolveFeedback : Feedback {

    [SerializeField]
    private SpriteRenderer spriteRenderer = null;
    [SerializeField]
    private float duration = 0.05f;
    [field: SerializeField]
    public UnityEvent DeathCallBack { get; set; }

    public override void CompletePrevFeedback() {
        spriteRenderer.DOComplete();
        spriteRenderer.material.DOComplete();
    }

    public override void CreateFeedback() {
        var sequence = DOTween.Sequence();
        sequence.Append(spriteRenderer.material.DOFloat(0, "_Dissolve", duration));
        if(DeathCallBack != null) {
            sequence.AppendCallback(() => DeathCallBack.Invoke());
        }
    }
}