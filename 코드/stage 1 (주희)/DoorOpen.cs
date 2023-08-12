using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public float doorspeed = 1;
    public string targetObjectName;
    //public string targetObjectName2;
    //GameObject doorUIObject;
    GameObject targetObject;



    private void Start()
    {
        GetComponent<Rigidbody2D>();
        targetObject = GameObject.Find(targetObjectName);
        //doorUIObject = GameObject.Find(targetObjectName2);
        //doorUIObject.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if(targetObject.transform.position.y <= -187 && this.transform.position.y <= -180)
        {
            this.transform.Translate(0, doorspeed / 50, 0);
            
        }
        //else
        
        //    doorUIObject.gameObject.SetActive(true);
        
        
    }
}
