using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Flee Distance")]

public class FleeDistanceDecision : Decision
{

    public override bool Decide(StateController controller)
    {
        return OutOfRange(controller);
    }

    private bool OutOfRange(StateController controller)
    {
        if (controller.ChaseTarget != null)
        {
            if (Vector3.Distance(controller.transform.position, controller.ChaseTarget.position) >
                controller.CurrentStat.OutOfRangeFleeDistance)
                return true;
            else
                return false;
        }

        return true;
    }
}
