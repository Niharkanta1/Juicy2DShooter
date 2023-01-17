using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*=============================================
Product:    Juicy2DShooter v1.0
Developer:  nihar
Company:    DeadW0Lf Games
Date:       16-01-2023 20:49:23
================================================*/
public class FlashSpriteFeedback : Feedback {
    [SerializeField]
    private SpriteRenderer spriteRenderer = null;
    [SerializeField]
    private float flashTime = 0.1f;
    [SerializeField]
    private Material flashMaterial = null;

    private Shader originalMaterialShader;
    private string originalShortingLayer;

    private void Start() {
        originalMaterialShader = spriteRenderer.material.shader;
        originalShortingLayer = spriteRenderer.sortingLayerName;
    }

    public override void CompletePrevFeedback() {
        StopAllCoroutines();
        spriteRenderer.material.shader = originalMaterialShader;
    }

    public override void CreateFeedback() {
        if (spriteRenderer.material.HasProperty("_MakeSolidColor") == false) {
            spriteRenderer.material.shader = flashMaterial.shader;
        }
        spriteRenderer.material.SetInt("_MakeSolidColor", 1);
        spriteRenderer.sortingLayerName = "FX";
        StartCoroutine(WaitBeforeChangingBack());
    }

    IEnumerator WaitBeforeChangingBack() {
        yield return new WaitForSeconds(flashTime);
        if(spriteRenderer.material.HasProperty("_MakeSolidColor")) {
            spriteRenderer.material.SetInt("_MakeSolidColor", 0);
        }
        spriteRenderer.material.shader = originalMaterialShader;
        spriteRenderer.sortingLayerName = originalShortingLayer;
    }
}