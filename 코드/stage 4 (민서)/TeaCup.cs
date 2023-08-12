using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeaCup : MonoBehaviour
{
    public new CameraShake camera;
    public GameObject desk;
    void Start()
    {
        camera = GameObject.FindWithTag("MainCamera").GetComponent<CameraShake>();
        Go();
    }
    private void Go()
    {
        iTween.MoveTo(gameObject, iTween.Hash("position", new Vector3(-35.056f, -2.4f, 0),
            "time", 2, "easeType", iTween.EaseType.easeOutQuint, "oncomplete", "Comeback"));
    }
    private void Comeback()
    {
        iTween.MoveTo(gameObject, iTween.Hash("position", new Vector3(-35.056f, 11.4f, 0),
            "time", 2, "easeType", iTween.EaseType.easeOutQuint, "oncomplete", "Go"));
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "desk")
        {
            camera.VibrateFOrTime(0.05f);
        }
    }
}
