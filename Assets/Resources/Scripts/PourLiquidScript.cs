using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PourLiquidScript : MonoBehaviour
{

    public ParticleSystem ps;
    
    private bool debug = true;
    
    
    private void Start()
    {

    }

    private void Update()
    {
        if (debug) StartCoroutine(DisplayRotation());
        
        float RotZ = transform.eulerAngles.z;
        if (RotZ > 90 && RotZ < 180 && ps.isStopped) ps.Play();
        if(RotZ < 90 && ps.isPlaying) ps.Stop(); 
    }

    IEnumerator DisplayRotation()
    {
        float RotZ = transform.eulerAngles.z;
        if (RotZ > 90 && RotZ < 180) Debug.Log("Pour: - Z - " + RotZ);
        debug = false;
        yield return new WaitForSeconds(1);
        debug = true;
    }
    
} // class
