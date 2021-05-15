using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum  TEMPERATURES
{
    Frozen,
    Cold,
    Room,
    Hot,
    Boiling
} // enum

public interface ITemperatureChange
{

    bool isOn { get; set; }
    TEMPERATURES temp { get; set; }

}
