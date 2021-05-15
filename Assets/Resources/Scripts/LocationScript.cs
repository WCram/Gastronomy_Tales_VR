using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationScript : MonoBehaviour
{

    // public Material location;
    public GameObject worldLoc;
    public GameObject defaultLoc;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateWorld()
    {
        worldLoc.SetActive(true);
        defaultLoc.SetActive(false);
    } // ActivateWorld()

    public void DeactivateWorld()
    {
        worldLoc.SetActive(false);
        defaultLoc.SetActive(true);
    } // DeactivateWorld()

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag.Equals("Hand"))
        {
            Debug.Log("Works");
            ActivateWorld();
        }
  
    }
} // class
