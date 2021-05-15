using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heating : MonoBehaviour, ITemperatureChange
{
    // public GameObject turnOn;



    public bool isOn { get; set; } = true;
    public TEMPERATURES temp { get; set; } = TEMPERATURES.Hot;
}
