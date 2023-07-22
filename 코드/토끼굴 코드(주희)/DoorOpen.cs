using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public float doorspeed = 1;
    public string targetObjectName;
    GameObject targetObject;


    private void Start()
    {
        GetComponent<Rigidbody2D>();
        targetObject = GameObject.Find(targetObjectName);
        
    }
    // Update is called once per frame
    void Update()
    {
        if(targetObject.transform.position.y <= -29.3 && this.transform.position.y <= -23.5)
        {
            this.transform.Translate(0, doorspeed / 50, 0);
            //문이 다시 닫히는지 구현은 생각 안해봄 
            // 기능구현 어느정도 하면 추가할까 생각중....
        }
    }
}
