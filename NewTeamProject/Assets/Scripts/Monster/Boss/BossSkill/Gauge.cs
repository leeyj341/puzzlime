using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gauge
{
    float castTime;
    float curcastTime;
    bool castActive;

    public float CastTime { get => castTime; set => castTime = value; }
    public float CurCastTime { get => curcastTime; set => curcastTime = value; }
    public bool CastActive { get => castActive; set => castActive = value; }
    // Update is called once per frame
    public void GaugeStart()
    {
        curcastTime = 0;
        castActive = true;
    }

    public bool GaugeUpdate()
    {
        if(!castActive) return false;
        curcastTime += Time.deltaTime;
        if (curcastTime >= castTime) return true;
        else return false;
    }

    public void StopGauge()
    {
        castActive = false;
        curcastTime = 0;
    }
    
    public void Init(float Ct)
    {
        curcastTime = 0;
        castTime = Ct;
        castActive = false;
    }
    
}
