using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "PluggableAI/Decisions/Player Alive")]
public class PlayerAliveDecision : Decision
{
    public override bool Decide(StateController controller)
    {
        bool playerAlive = CheckPlayerAliveStatus(controller);
        return playerAlive;
    }

    private bool CheckPlayerAliveStatus(StateController controller)
    {
        return controller.ChaseTarget.transform.gameObject.activeSelf;
    }
}
