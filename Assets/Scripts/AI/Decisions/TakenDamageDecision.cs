using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Taken Damage")]

public class TakenDamageDecision : Decision
{
    public override bool Decide(StateController controller)
    {
        return DamageTaken(controller);
    }

    private bool DamageTaken(StateController controller)
    {
        if (controller.GetComponent<Complete.TankHealth>().CurrentHealth ==
            controller.GetComponent<Complete.TankHealth>().PreviousHealth)
        {
            return false;
        }

        controller.ChaseTarget = controller.GetComponent<Complete.TankHealth>().DamagedByTank.transform;
        controller.GetComponent<Complete.TankHealth>().PreviousHealth =
            controller.GetComponent<Complete.TankHealth>().CurrentHealth;
        return true;

    }


}
