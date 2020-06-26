using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;
using System;

public class Ticker
{
    public Tickable _tickable;    
    public bool isTicking = true; 
    
    public IEnumerator RegisterTickable(Tickable tickable, float time)
    {
        _tickable = tickable;
        while (isTicking)
        {
            yield return new WaitForSeconds(time);
            _tickable.Tick();

            if (Input.GetKeyDown("s"))
            {
                StopTickable(_tickable);
            }
        }
    }

    public void StopTickable(Tickable tickable)
    {
        isTicking = false;
    }
}
