using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravity : MonoBehaviour
{
    Rigidbody2D rbody;
    public float falldownG = 0.5f;
    public float stage2G = 4;
    //public string targetObjectName;
    //GameObject targetObject;

    void Start()
    {
        
        rbody = GetComponent<Rigidbody2D>();
        //targetObject = GameObject.Find(targetObjectName);
        rbody.gravityScale = falldownG;
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.position.x >= 38)
        {
            rbody.gravityScale = stage2G;
        }
    }
}
