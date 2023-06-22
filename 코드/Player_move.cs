using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

public class Player_move : MonoBehaviour
{
    public float speed = 2.0f;
    private float vx = 0;
    private bool leftflip;
    public float angle = 0f;
    Vector2 target, Mouse;
    Rigidbody2D rbody;
    
    void Start()
    {
        target = transform.position;
        rbody = GetComponent<Rigidbody2D>();
        rbody.gravityScale = 1f;
        rbody.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    void Update()
    {
        vx = 0;
        if(Input.GetKey(KeyCode.A)) 
        {
            vx = -speed;
            leftflip = true;
        }
        
        if(Input.GetKey(KeyCode.D)) 
        {
            vx = speed;
            leftflip = false;
        }

        Mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        angle = Mathf.Atan2(Mouse.y - target.y, Mouse.x - target.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

    }

    private void FixedUpdate()
    {
        transform.Translate(vx  * Time.deltaTime , 0, 0);
        this.GetComponent<SpriteRenderer>().flipX = leftflip;
    }
}
