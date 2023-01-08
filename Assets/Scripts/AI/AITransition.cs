using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*=============================================
Product:    Juicy2DShooter v1.0
Developer:  nihar
Company:    DeadW0Lf Games
Date:       07-01-2023 21:44:19
================================================*/ 
public class AITransition : MonoBehaviour {
    [field: SerializeField]
    public List<AIDecision> Decisions { get; set; }

    [field: SerializeField]
    public AIState PositiveResult { get; set; }

    [field: SerializeField]
    public AIState NegativeResult { get; set; }

    private void Awake() {
        Decisions.Clear();
        Decisions = new List<AIDecision>(GetComponents<AIDecision>());
    }
}