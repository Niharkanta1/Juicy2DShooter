using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/*=============================================
Product:    Juicy2DShooter v1.0
Developer:  nihar
Company:    DeadW0Lf Games
Date:       07-01-2023 20:59:03
================================================*/
public class Player : MonoBehaviour, IAgent
{
    public int Health { get; set; }

    public UnityEvent OnDie { get; set; }
    public UnityEvent OnGetHit { get; set; }
}