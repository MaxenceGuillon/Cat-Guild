using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderEvent : MonoBehaviour
{
    public Slider sliderEvent;

    public void SetMinEventPoint(int currentEventPoint)
    {
        sliderEvent.minValue = currentEventPoint;
        sliderEvent.value = currentEventPoint;
    }

    public void SetCurrentEventPoint(int currentEventPoint)
    {
        sliderEvent.value = currentEventPoint;
    }
}
