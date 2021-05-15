using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorTransitionScript : MonoBehaviour
{
    public Color[] myColors;
    public float duration = 5f;
    public float howCooked = 0;

    private float cookingIncrement;
    private int currentCookingStage;
    
    private float t = 0; // lerp control
    
    private MeshRenderer rend;
    private bool debug = true;

    private int seconds = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<MeshRenderer>();
        rend.material.color = myColors[0];
        cookingIncrement = Time.deltaTime / duration;
        currentCookingStage = 1;
    }
    
    private void OnTriggerStay(Collider other)
    {
        if (other.tag.Equals("TemperatureChange") && currentCookingStage < myColors.Length)
        {
            rend.material.color = Color.Lerp(rend.material.color, myColors[currentCookingStage], cookingIncrement );
            howCooked += (100 / duration) * Time.deltaTime ;

            if (howCooked >= 100)
            {
                currentCookingStage++;
                howCooked = 0;
            }
        }
    }

    private IEnumerator DebugInfo(string info = "This Works")
    {
        Debug.Log($"Seconds: {seconds++} - {info}");
        debug = false;
        yield return new WaitForSeconds(1);
        debug = true;

    } // DebugInfo
    
}
