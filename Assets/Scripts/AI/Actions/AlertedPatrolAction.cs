using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Alerted Patrol")]
public class AlertedPatrolAction : Action
{
    public override void Act(StateController controller)
    {
        AlertedPatrol(controller);
    }
    private void AlertedPatrol(StateController controller)
    {
        controller.AlertedStateEnemyStat();
    }
    public override void Exit(StateController controller)
    {
        Debug.Log("exiting from alerted patrol state");
    }
}
