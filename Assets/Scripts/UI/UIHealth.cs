using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*=============================================
Product:    Juicy2DShooter v1.0
Developer:  nihar
Company:    DeadW0Lf Games
Date:       20-01-2023 16:57:24
================================================*/
public class UIHealth : MonoBehaviour {
    [SerializeField]
    private GameObject heartPrefab = null, healthPanel;
    [SerializeField]
    private Sprite heartFull, heartEmplty;

    private int heartCount = 0;
    private List<Image> hearts = new List<Image>();

    public void Initialize(int livesCount) {
        heartCount = livesCount;
        foreach (Transform child in healthPanel.transform) {
            Destroy(child.gameObject);
        } 
        for(int i=0; i < livesCount; i++) {
            hearts.Add(Instantiate(heartPrefab, healthPanel.transform).GetComponent<Image>());
        }
    }

    public void UpdateHealthUI(int health) {
        for(int i =0; i < heartCount; i++) {
            if(i >= health) {
                hearts[i].sprite = heartEmplty;
            } else {
                hearts[i].sprite = heartFull;
            }
        }
    }
}