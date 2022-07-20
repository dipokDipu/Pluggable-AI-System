using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Chase")]
public class ChaseAction : Action
{
    public override void Act(StateController controller)
    {
        Chase(controller);
    }

    public override void Exit(StateController controller)
    {
        Debug.Log("Exited from chase action");
    }

    private void Chase(StateController controller)
    {
        controller.Agent.destination = controller.ChaseTarget.position;
        controller.Agent.isStopped = false;
    }
}
