using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Item Investigation")]

public class ItemInvestigationAction : Action
{
    public override void Act(StateController controller)
    {
        SuspiciousItemInspect(controller);
    }

    private void SuspiciousItemInspect(StateController controller)
    {
        if (controller.Agent.pathStatus == NavMeshPathStatus.PathComplete
            && !controller.Agent.pathPending
            && controller.Agent.remainingDistance <= controller.Agent.stoppingDistance)
        {
            controller.gameObject.GetComponent<TankCanvas>().SetTempQuestionUi(controller.TimeElapsed, controller.CurrentStat.SuspicousObjectExaminationDuration);
            controller.gameObject.GetComponent<TankCanvas>().SilderForQuestion.fillRect.GetComponent<Image>().color =
                controller.gameObject.GetComponent<TankCanvas>().TempQuestionMarkColor;
        }
    }

    public override void Exit(StateController controller)
    {
        controller.CurrentTolerance++;
        controller.gameObject.GetComponent<TankCanvas>().SilderForQuestion.fillRect.GetComponent<Image>().color =
            controller.gameObject.GetComponent<TankCanvas>().PermaQuestionMarkColor;
        controller.gameObject.GetComponent<TankCanvas>().SetPermaQuestionUi(controller.CurrentTolerance, controller.CurrentStat.SuspectedObjectTolerance);
        Debug.Log("Exiting From Item Inspection State");
    }
}
