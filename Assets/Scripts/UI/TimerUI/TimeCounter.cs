using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TimeCounter : MonoBehaviour
{
    [SerializeField] TMP_Text timerText;
    [SerializeField] float startingTime;
    [SerializeField] float remainingTime;
    private bool timerRunning = false;
    public bool TimerRunning{get{return timerRunning;}}
    bool startedPoisoning = false;
    public float RemainingTime{get{return remainingTime;}}
    private Coroutine timerCoroutine;
    public GameEvent onLowAmountOfTime;
    public GameEvent onTimeout;

    private void Awake() {
        remainingTime = startingTime;
    }
    private void OnEnable() {

        startTimer();
    }
    private void OnDisable() {
        
    }
    IEnumerator Timer()
    {
        while(remainingTime>0)
        {
            remainingTime-=1;
            displayTimer();
            if(remainingTime <= 60 && startedPoisoning == false)
            {
                onLowAmountOfTime.Raise();
            }
            yield return new WaitForSeconds(1);
        }
        onTimeout.Raise();
    }
    public void stopTimer()
    {
        timerRunning = false;
        if(timerCoroutine != null) StopCoroutine(timerCoroutine);
    }
    public void startTimer()
    {
        timerRunning = true;
        timerCoroutine = StartCoroutine(Timer());
    }
    void displayTimer()
    {
        float minutes = Mathf.FloorToInt(remainingTime / 60);
        float seconds = Mathf.FloorToInt(remainingTime%60);
        if(seconds<10)
        {
            timerText.GetComponent<TMP_Text>().text = minutes+":0"+seconds;
        }
        else
        {
            timerText.GetComponent<TMP_Text>().text = minutes+":"+seconds;
        }
    }
}
