using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCount : MonoBehaviour {

    int frameCount = 0;
    double nextUpdate = 0.0;
    double fps = 0.0;
    double updateRate = 4.0;  // 4 updates per sec.

    public void Start()
    {
        nextUpdate = Time.time;
    }

    public void Update()
    {
        frameCount++;
        if (Time.time > nextUpdate)
        {
            nextUpdate += 1.0 / updateRate;
            fps = frameCount * updateRate;
            frameCount = 0;
        }
        Debug.Log(fps);
    }
}
