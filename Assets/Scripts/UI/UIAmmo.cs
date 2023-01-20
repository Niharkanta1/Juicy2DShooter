using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/*=============================================
Product:    Juicy2DShooter v1.0
Developer:  nihar
Company:    DeadW0Lf Games
Date:       20-01-2023 17:30:40
================================================*/ 
public class UIAmmo : MonoBehaviour {
    [SerializeField]
    private TextMeshProUGUI text = null;

    public void UpdateBulletsText(int bulletCount) {
        if (bulletCount == 0)
            text.color = Color.red;
        else
            text.color = Color.white;

        text.SetText(bulletCount.ToString());
    }
}