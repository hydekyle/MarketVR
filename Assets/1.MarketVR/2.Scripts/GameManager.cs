using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    public Slider multiplierTimeSlider;
    public Text timeText, multiplierText;
    DateTime startDate;

    private void Awake()
    {
        startDate = DateTime.Now;
    }

    async void Start()
    {
        await UniTask.WaitUntil(() => Input.GetButton("primaryButton"));
        print("done");
    }

    private void Update()
    {
        TimeClockUpdate();
    }

    private void TimeClockUpdate()
    {
        var now = startDate.AddSeconds(Time.timeSinceLevelLoadAsDouble);
        var hour = now.Hour > 10 ? now.Hour.ToString() : "0" + now.Hour.ToString();
        var min = now.Minute > 10 ? now.Minute.ToString() : "0" + now.Minute.ToString();
        var second = now.Second > 10 ? now.Second.ToString() : "0" + now.Second.ToString();
        timeText.text = now.Second % 2 == 0 ? $"{hour}:{min}:{second}" : $"{hour}.{min}.{second}";
        var multiplierValue = multiplierTimeSlider.value.ToString();
        multiplierText.text = multiplierValue.Length > 1 ? "x" + multiplierTimeSlider.value.ToString() : "x" + multiplierTimeSlider.value.ToString() + ".0";
        Time.timeScale = multiplierTimeSlider.value;
        if (!multiplierTimeSlider.spriteState.pressedSprite) multiplierTimeSlider.value = Mathf.Lerp(multiplierTimeSlider.value, 1f, Time.deltaTime * 10);
    }

    public void OnTemperatureChanged(float newTemperature)
    {
        print("Changed: " + newTemperature);
    }

    public void OnTemperatureSnapChanged(float newSnap)
    {
        print("Changed: " + newSnap);
    }



}
