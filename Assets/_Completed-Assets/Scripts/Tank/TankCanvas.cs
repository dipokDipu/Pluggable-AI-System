using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankCanvas : MonoBehaviour
{
    public Slider SliderForTrigger;
    public Slider SilderForQuestion;
    public Color TempQuestionMarkColor;
    public Color PermaQuestionMarkColor;

    public void SetTriggerUi(float currentValue, float maxValue)
    {
        SliderForTrigger.value = (currentValue / maxValue) *100;
    }

    public void SetTempQuestionUi(float currentValue, float maxValue)
    {
        SilderForQuestion.value = (currentValue / maxValue) * 100 + 
                                  (gameObject.GetComponent<StateController>().CurrentTolerance/(float)gameObject.GetComponent<StateController>().CurrentStat.SuspectedObjectTolerance)*100f;
    }

    public void SetPermaQuestionUi(float currentValue, float maxValue)
    {
        SilderForQuestion.value = (currentValue / maxValue) * 100;
    }

    public void ResetTriggerUi()
    {
        SliderForTrigger.value = 0;
    }

   
}
