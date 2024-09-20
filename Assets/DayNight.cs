using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DayNight : MonoBehaviour
{
    [SerializeField]
    Light2D sun;

    [SerializeField]
    Gradient sunColor;

    [SerializeField]
    public float dayDurationSeconds = 60;

    private float day = 0;
    public float Day
    { 
        get { return day; } 
        private set { day = value; } 
    }

    public void UpdateLight(Light2D light)
    {
        float normalizedTime = day % 1;
        light.color = sunColor.Evaluate(normalizedTime);
    }

    // Update is called once per frame
    void Update()
    {
        day += Time.deltaTime / dayDurationSeconds;

        UpdateLight(sun);
    }
}
