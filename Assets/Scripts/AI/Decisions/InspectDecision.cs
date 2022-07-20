using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Inspect")]

public class InspectDecision : Decision
{
    public override bool Decide(StateController controller)
    {
        return AlreadyInspected(controller);
    }

    private bool AlreadyInspected(StateController controller)
    {
        if (controller.Agent.isPathStale || controller.Agent.pathStatus is NavMeshPathStatus.PathInvalid or NavMeshPathStatus.PathPartial) return true;
        if (controller.Agent.pathStatus == NavMeshPathStatus.PathComplete
            && !controller.Agent.pathPending
            && controller.Agent.remainingDistance <= controller.Agent.stoppingDistance)
        {
            if (controller.TimePassed(controller.CurrentStat.InvestigationStateDuration))
                return true;
            return false;
        }
        return false;
    }
}
