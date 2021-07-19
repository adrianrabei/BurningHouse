using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Image fill;
        
    private float fillSpeed = 0.5f;
    private float targetFill = 0f;

    private void Awake()
    {
        slider = GetComponent<Slider>();
        fill.color = Color.blue;
        slider.maxValue = 5;
    }

    private void Update()
    {
        if (slider.value < targetFill)
        {
            slider.value += fillSpeed * Time.deltaTime;
        }
        else if (slider.value > targetFill)
        {
            slider.value -= fillSpeed * Time.deltaTime;
        }
    }

    public void Increment(float amount)
    {
        targetFill = slider.value += amount;
    }

    public void Decrement(float amount)
    {
        targetFill = slider.value -= amount;
    }
}