using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Sprites;
using UnityEngine;
using UnityEngine.SceneManagement;

/*=============================================
Product:    Juicy2DShooter v1.0
Developer:  nihar
Company:    DeadW0Lf Games
Date:       05-01-2023 16:02:34
================================================*/
public class GameManager : MonoBehaviour {
    [SerializeField]
    private Texture2D cursorTexture = null;

    private void Start() {
        SetCursorIcon();
    }

    private void SetCursorIcon() {
        Cursor.SetCursor(cursorTexture, new Vector2(cursorTexture.width / 2f, cursorTexture.height / 2f),
            CursorMode.Auto);
    }

    public void RestartLevel() {
        DOTween.KillAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}