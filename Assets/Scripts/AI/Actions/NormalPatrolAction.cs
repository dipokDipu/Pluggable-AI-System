using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Normal Patrol")]
public class NormalPatrolAction : Action
{
    public override void Act(StateController controller)
    {
        AlertedPatrol(controller);
    }
    private void AlertedPatrol(StateController controller)
    {
        controller.NormalStateEnemyStat();
    }
    public override void Exit(StateController controller)
    {
        Debug.Log("exiting from normal patrol state");
    }
}
