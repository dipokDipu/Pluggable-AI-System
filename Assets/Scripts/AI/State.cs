using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/State")]
public class State : ScriptableObject
{
    public Color SceneGizmoColor = Color.cyan;
    public Action[] Actions;
    public Transition[] Transitions;
 
    public void UpdateState(StateController controller)
    {
        DoActions(controller);
        CheckTransition(controller);
    }

    private void DoActions(StateController controller)
    {
        foreach (var action in Actions)
        {
            action.Act(controller);
        }
    }

    private void CheckTransition(StateController controller)
    {
        foreach (var transition in Transitions)
        {
            controller.SwitchState(transition.DecisionMaker.Decide(controller)
                ? transition.TrueState
                : transition.FalseState);
        }
    }

    public virtual void ExitState(StateController controller)
    {
        foreach (var action in Actions)
        {
            action.Exit(controller);
        }
        controller.TimeElapsed = 0;
        controller.Agent.ResetPath();
        controller.gameObject.GetComponent<TankCanvas>().ResetTriggerUi();
    }
}
