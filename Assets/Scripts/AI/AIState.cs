using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*=============================================
Product:    Juicy2DShooter v1.0
Developer:  nihar
Company:    DeadW0Lf Games
Date:       07-01-2023 21:43:43
================================================*/ 
public class AIState : MonoBehaviour {

    private EnemyAIBrain enemyBrain = null;

    [SerializeField]
    private List<AIAction> actions = null;
    [SerializeField]
    private List<AITransition> transitions = null;

    private void Awake() {
        enemyBrain = transform.root.GetComponent<EnemyAIBrain>();
    }

    public void UpdateState() {
        foreach (var action in actions) {
            action.TakeAction();
        }
        foreach (var transition in transitions) {
            bool result = false;
            foreach(var decision in transition.Decisions) {
                result = decision.MakeDecision();
                if (result == false)
                    break;
            }

            if(result) {
                if(transition.PositiveResult != null) {
                    enemyBrain.ChangeToState(transition.PositiveResult);
                    return;
                } 
            } else {
                if (transition.NegativeResult != null) {
                    enemyBrain.ChangeToState(transition.NegativeResult);
                    return;
                }
            }
        }
    }
}