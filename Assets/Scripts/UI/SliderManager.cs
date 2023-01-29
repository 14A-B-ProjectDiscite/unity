using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderManager : MonoBehaviour
{
    public Slider slider;
    [SerializeField] private FloatVariable value;
    [SerializeField] private FloatVariable maxValue;

    private void Start()
    { 
        SetMaxValue();
    }

    public void SetValue()
    {
        slider.value = value.Value;
    }

    public void SetMaxValue()
    {
        slider.maxValue  = maxValue.Value;
    }
}
