using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "PluggableAI/Decisions/Health")]

public class HealthDecision : Decision
{

    public override bool Decide(StateController controller)
    {
        return BelowHealth(controller);
    }

    private bool BelowHealth(StateController controller)
    {
        return controller.GetComponent<Complete.TankHealth>().CurrentHealth < controller.CurrentStat.FleeTankHealth;
    }
}
