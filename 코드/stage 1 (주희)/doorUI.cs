using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorUI : MonoBehaviour
{
    public string targetObjectName;
    GameObject targetObject;
    //public string playerName;
    //GameObject playerObject;
    // Start is called before the first frame update
    void Start()
    {
        targetObject = GameObject.Find(targetObjectName);
        //playerObject = GameObject.Find(playerName);
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(targetObject.transform.position.y <= -180)  //&& playerObject.transform.position.x >= 4
        {
            this.gameObject.SetActive(true);
        }
    }
}
