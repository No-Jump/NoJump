using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class smaller : MonoBehaviour
{
    float scaleSpeed = 1f;
    float timer;

    private void Update()
    {
        timer += Time.deltaTime;
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(timer > 1f)
        {
            if (other.gameObject.tag == "Player")
            {
                transform.localScale = new Vector3
                    (transform.localScale.x - 0.7f * scaleSpeed * Time.deltaTime,
                    transform.localScale.y - 0.7f * scaleSpeed * Time.deltaTime, 0);
            }
        }
    }
}
