using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player_size : MonoBehaviour
{
    private float size = 2.9f;

    void Update()
    {
        Vector3 scale = Vector3.zero;
        if (Input.GetMouseButton(0))
        {
            if (transform.localScale.x < size)
            {
                scale.x = 0.1f;
            }
        }
        

        if(Input.GetMouseButton(1))
        {
            if(transform.localScale.z >= 1f)
            {
                scale.x = -0.1f;
                if(transform.localScale.x <= 1.0f)
                {
                    scale.x = 0f;
                }
            }
        }

         transform.localScale += scale;
    }

    private void FixedUpdate()
    {
    }
}