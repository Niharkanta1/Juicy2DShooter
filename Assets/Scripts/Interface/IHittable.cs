using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/*=============================================
Product:    Juicy2DShooter v1.0
Developer:  nihar
Company:    DeadW0Lf Games
Date:       06-01-2023 15:39:25
================================================*/
public interface IHittable {

    UnityEvent OnGetHit { get; set; } 

    void GetHit(int damage, GameObject damageDealer);
}