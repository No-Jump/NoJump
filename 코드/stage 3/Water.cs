using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public float upY;

    void Update()
    {
        upY = Time.deltaTime;   //값이 0.1씩 늘어남
        RiseWater();
    }

    IEnumerator WaterScale()
    {
        yield return new WaitForSeconds(0.5f);
    }

    void RiseWater()
    {
        transform.localScale = new Vector3(2, transform.localScale.y + upY, 1);
        StartCoroutine(WaterScale());
    }
}
