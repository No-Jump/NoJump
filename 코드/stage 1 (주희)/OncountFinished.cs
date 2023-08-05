using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OncountFinished : MonoBehaviour
{
    public int lastcount = 3;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(GameCounter.value == lastcount)
        {
            
        }
    }
}
