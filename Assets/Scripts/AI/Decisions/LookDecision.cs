using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Look")]
public class LookDecision : Decision
{
    public override bool Decide(StateController controller)
    {
        bool targetVisible = Look(controller);
        return targetVisible;
    }

    private bool Look(StateController controller)
    {
        RaycastHit hit;
        if (Physics.SphereCast(controller.Eyes.position, controller.CurrentStat.LookSphereCastRadius, controller.Eyes.forward,
                out hit, controller.CurrentStat.LookRange) && hit.collider.CompareTag("Player"))
        {
            controller.ChaseTarget = hit.transform;
            return true;
        }

        return false;
    }
}
