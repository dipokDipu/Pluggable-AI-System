using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Attack")]

public class AttackAction : Action
{
    public override void Act(StateController controller)
    {
        Attack(controller);
    }

    public override void Exit(StateController controller)
    {
        Debug.Log("Exited from attack action");
    }

    private void Attack(StateController controller)
    {
        RaycastHit hit;
        if (Physics.SphereCast(controller.Eyes.position, controller.CurrentStat.LookSphereCastRadius, controller.Eyes.forward,
                out hit, controller.CurrentStat.LookRange) && hit.collider.CompareTag("Player"))
        {
            if (controller.TimePassed(controller.CurrentStat.AttackRate))
            {
                controller.TankShooting.Fire(controller.CurrentStat.AttackForce);
                controller.TimeElapsed = 0;
            }
        }
        else
        {
            Debug.Log("did not find player");
        }
    }
}
