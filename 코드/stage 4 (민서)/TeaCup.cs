using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeaCup : MonoBehaviour
{
    Vector3 pos;
    float delta = 13.9f;
    float speed = 1.0f;
    CameraShake camera;
    public GameObject desk;
    void Start()
    {
        pos = transform.position;
        camera = GameObject.FindWithTag("MainCamera").GetComponent<CameraShake>();
    }

    void Update()
    {
        Vector3 v = pos;
        v.y += delta * Mathf.Sin(Time.time * speed);
        transform.position = v;
    }
    private void OnCollisionEnter2D(Collision2D desk)
    {
        camera.VibrateFOrTime(0.05f);
    }
}
