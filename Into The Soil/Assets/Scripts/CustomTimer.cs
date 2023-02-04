using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomTimer : MonoBehaviour
{
    public delegate void Action();
    private Action TargetMethod;
    private IEnumerator cor;
    private float maxTime { get; set; }
    private float currentTime { get; set; }


    private bool isLooping = false;
    private bool isPaused = false;
    private bool isActive = false;
    public bool IsPaused { get { return isPaused; } }
    public bool IsActive { get { return isActive; } }

    public bool IsLooping { get { return isLooping; } }

    // ReadOnly Current Time, show how much time went by
    public float CurrentTime
    {
        get
        {
            return currentTime;
        }
    }

    public float RemainingTime
    {
        get
        {
            return maxTime - currentTime;
        }
    }

    public CustomTimer()
    {
        cor = CustomUpate_(0);
    }
    private IEnumerator CustomUpate_(float time)
    {
        yield return new WaitForSeconds(time);
        while (true)
        {
            RunningTime();
            yield return null;
        }
    }

    // For instance, call this CustomizedTimer.StartTimer(10, ExecuteMethod)
    // it will call back that ExecuteMethod when the countdown is ended
    // when you call this again during counting, it should be replace the original one
    public void StartTimer(float MaxTime, Action ExecuteMethod)
    {
        StopCoroutine(cor);
        currentTime = 0;
        isActive = true;
        isPaused = false;
        maxTime = MaxTime;
        TargetMethod = ExecuteMethod;
        StartCoroutine(cor);
    }

    public void StartTimer(float MaxTime, Action ExecuteMethod, bool bIsLooping)
    {
        StopCoroutine(cor);
        currentTime = 0;
        isActive = true;
        isLooping = true;
        isPaused = false;
        maxTime = MaxTime;
        TargetMethod = ExecuteMethod;
        StartCoroutine(cor);
    }


    public void Pause()
    {
        StopCoroutine(cor);
        isPaused = true;
    }

    public void Continue()
    {
        StartCoroutine(cor);
        isPaused = false;
    }

    public void Dispose()
    {
        StopCoroutine(cor);
        currentTime = 0;
        maxTime = 0;
        TargetMethod = null;
        isPaused = false;
        isActive = false;
        isLooping = false;
    }

    private void RunningTime()
    {
        currentTime += Time.deltaTime;

        if (currentTime > maxTime)
        {
            if (!isLooping)
            {
                StopCoroutine(cor);
                //Debug.Log("Finished");
                if (TargetMethod != null)
                    TargetMethod();
                Dispose();
                return;
            }
            else
            {
                if (TargetMethod != null)
                    TargetMethod();
                currentTime = 0;
                return;
            }
        }

    }
}