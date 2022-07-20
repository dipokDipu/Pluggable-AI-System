using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Transition
{
    public Decision DecisionMaker;
    public State TrueState;
    public State FalseState;
}
