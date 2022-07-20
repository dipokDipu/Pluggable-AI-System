using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Suspicious Object")]
public class SuspiciousObjectDectectionDecision : Decision
{
    public override bool Decide(StateController controller)
    {
        bool suspiciousTargetVisible = ObjectDetection(controller);
        return suspiciousTargetVisible;
    }

    private bool ObjectDetection(StateController controller)
    {
        return controller.SuspectedObject.Count > 0;
    }
}
