using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerDisplayer : MonoBehaviour,IDisplayUI
{
     [SerializeField] Canvas timerCanvas;
     [SerializeField] TimeCounter timeCounter;
    private void OnEnable() 
    {
        WaveController.onWaveStartGlobal += DisplayUI;
        WaveController.onWaveEndGlobal += DisplayUI;
    }
    private void OnDisable() 
    {
        WaveController.onWaveStartGlobal -= DisplayUI;
        WaveController.onWaveEndGlobal -= DisplayUI;
    }
    public void DisplayUI()
    {
        if(timerCanvas == null) return;
        timerCanvas.enabled = !timerCanvas.enabled;
        if(timeCounter.TimerRunning == true)
        {
            timeCounter.stopTimer();
        }
        else
        {
            timeCounter.startTimer();
        }
    }
}
