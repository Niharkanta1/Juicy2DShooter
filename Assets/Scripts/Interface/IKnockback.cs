using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*=============================================
Product:    Juicy2DShooter v1.0
Developer:  nihar
Company:    DeadW0Lf Games
Date:       19-01-2023 19:07:34
================================================*/ 
public interface IKnockback {

    void KnockBack(Vector2 direction, float power, float duration);
}