using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameramove : MonoBehaviour
{
    public float cameraSpeed = 5.0f;

    public GameObject player;

    private void LateUpdate()
    {
        Vector3 dir = player.transform.position - this.transform.position;
        Vector3 moveVector = new Vector3(dir.x * cameraSpeed * Time.deltaTime, (dir.y * cameraSpeed - 10) * Time.deltaTime, 0.0f);
        
        this.transform.Translate(moveVector);
        
        
     
        
        
        
    }
}
