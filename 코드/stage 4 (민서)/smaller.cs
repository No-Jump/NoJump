using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class smaller : MonoBehaviour
{
    float scaleSpeed = 1f;
    float height;

    void Start()
    {
        BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();
        height = boxCollider.size.y;
    }
    void OnCollisionStay2D(Collision2D other)
    {
            if (other.gameObject.tag == "Player")
            {
                transform.localScale = new Vector3
                (1, transform.localScale.y - 0.05f * scaleSpeed * Time.deltaTime, 0);
                if (height == 0)
                {
                    Destroy(this);
                }
            }
        }
    }
