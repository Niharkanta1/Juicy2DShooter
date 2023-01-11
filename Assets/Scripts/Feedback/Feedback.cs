using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*=============================================
Product:    Juicy2DShooter v1.0
Developer:  nihar
Company:    DeadW0Lf Games
Date:       10-01-2023 19:49:14
================================================*/ 
public abstract class Feedback : MonoBehaviour {

    public abstract void CreateFeedback();
    public abstract void CompletePrevFeedback();

    protected virtual void OnDestroy() {
        CompletePrevFeedback();
    }
}