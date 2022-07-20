using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Patrol")]
public class PatrolAction : Action
{
    public override void Act(StateController controller)
    {
        Patrol(controller);
    }

    public override void Exit(StateController controller)
    {
        Debug.Log("Exited from patrol action");
    }

    private void Patrol(StateController controller)
    {
        controller.Agent.destination = controller.Waypoints[controller.WayPointIndex].position;
        controller.Agent.isStopped = false;
        if (controller.Agent.remainingDistance <= controller.Agent.stoppingDistance && !controller.Agent.pathPending)
        {
            controller.WayPointIndex = (controller.WayPointIndex + 1) % controller.Waypoints.Count;
        }
    }
}
