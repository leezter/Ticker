using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading;

public class Tickable : MonoBehaviour
{
    public Ticker _ticker;

    // Start is called before the first frame update
    void Start()
    {
        this._ticker = new Ticker();
        StartCoroutine(_ticker.RegisterTickable(this, 0.5f));
    }

    //I wasn't sure how to call the 'StopTickable' method from this class without using Unity's update function. 
    public void Stop()
    {
        _ticker.StopTickable(this);
    }

    public string Tick()
    {
        //Using a coroutine from RegisterTickable() in the Ticker class, the Tick() method is called 
        //once every 0.5 seconds and the 's' variable is returned on each call. The coroutine allows 
        //the execution to pause for a given amount of time (in this case 0.5 seconds) and then 
        //to continue where it left off. The value returned from the 'time' variable is the time in 
        //milliseconds since the last frame update which is 0.016 (60fps) on average. It is not the time 
        //delay between yields (0.5 seconds).

        float time = Time.deltaTime;
        string s = "The tick method has been called at " + time;
        Debug.Log(s);
        return s;
    }

    public void Update()
    {
        //Using the update method, the 's' variable is returned on every frame. This happens 
        //because any function within the update method must execute its entirety within a single
        //frame update. The value returned from the 'time' variable is the time in seconds since 
        //the last frame update, which is 0.016 (60fps) on average.

        float time = Time.deltaTime;
        string s = "The update method returns every frame " + time;
        Debug.Log(s);
    }
}