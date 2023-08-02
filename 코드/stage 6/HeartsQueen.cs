using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartsQueen : MonoBehaviour
{
    public GameObject hedgehog;
    float offsetX = 1f, offsetY = 1f;

    private void Start()
    {
        InvokeRepeating("Create_hedgehog", 5f, 5f);
    }

    public void Create_hedgehog()
    {
        Vector3 newPos = this.transform.position;
        newPos.y += offsetY;
        newPos.x += offsetX;
        newPos.z = -5f;
        GameObject newGameObject = Instantiate(hedgehog) as GameObject;
        newGameObject.transform.position = newPos;
    }
}
