using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Liquid : MonoBehaviour
{
    private TEMPERATURES temp = TEMPERATURES.Room;
    private ParticleSystem ps;
    
    public bool isBoiled = false;

    private void Start()
    {
        OnTempChange += TemperatureChangeHandler;
        ps = GetComponent<ParticleSystem>();
        ps.Stop();
        IsBoiled();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("TemperatureChange"))
        {
            Temp = other.GetComponent<ITemperatureChange>().temp;
        };
    } // OnTriggerEnter

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("exit");
        if (other.tag.Equals("TemperatureChange"))
        {
            Temp = TEMPERATURES.Room;
        };
    }

    public TEMPERATURES Temp
    {
        get => temp;
        set
        {
            if (temp.Equals(value)) return;
            temp = value;

            if (OnTempChange != null)
            {
                OnTempChange(value);
                if (value.Equals(TEMPERATURES.Hot)) ps.Play();
                // else
                // {
                //     ps.Stop();
                //     Debug.Log("Gets here");
                // }
            }
        }
    } // Temp property

    public delegate void OnTempChangeDelegate(TEMPERATURES newTemp);

    public event OnTempChangeDelegate OnTempChange;

    public void TemperatureChangeHandler(TEMPERATURES newTemp)
    {
        IsBoiled();
    }

    public void IsBoiled()
    {
        if (temp.Equals(TEMPERATURES.Boiling)) isBoiled = true;
    } // IsBoiled()
} // class


