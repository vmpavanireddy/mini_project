using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float speed;
    private float input;
    Rigidbody2D rb;
    Animator anim;
    public int health;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim=GetComponent<Animator>();
        rb=GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if(input !=0)
        {
            anim.SetBool("isrunning",true);
        }
        else
        {
            anim.SetBool("isrunning",false);
        }
        if(input>0)
        {
            transform.eulerAngles=new Vector3(0,0,0);
        }
        else if(input<0)
        {
            transform.eulerAngles=new Vector3(0,180,0);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        input=Input.GetAxisRaw("Horizontal");
        rb.linearVelocity=new Vector2(input*speed,rb.linearVelocity.y);
    }
    public void takeDamage(int damageamount)
    {
        health-=damageamount;
        if(health<=0)
        {
            Destroy(gameObject);
        }
    }
}
