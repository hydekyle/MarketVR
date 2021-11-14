using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    async void Start()
    {
        await UniTask.WaitUntil(() => Input.GetButton("primaryButton"));
        print("done");
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
