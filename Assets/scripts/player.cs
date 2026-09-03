using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    public GameObject losepanel;
    public Text healthtext;
    public float speed;
    private float input;
    Rigidbody2D rb;
    Animator anim;
    AudioSource audiosource;
    public int health;


    public float startdashtime;
    private float dashtime;
    public float extraspeed;
    private bool isdashing;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        healthtext.text = health.ToString();
    }
    private void Update()
    {
        if (input != 0)
        {
            anim.SetBool("isrunning", true);
        }
        else
        {
            anim.SetBool("isrunning", false);
        }
        if (input > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (input < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space) && !isdashing)
        {
            isdashing = true;
            dashtime = startdashtime;
            speed += extraspeed;
        }

        if (isdashing)
        {
            dashtime -= Time.deltaTime;

            if (dashtime <= 0)
            {
                isdashing = false;
                speed -= extraspeed;
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        input = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(input * speed, rb.linearVelocity.y);
    }
    public void takeDamage(int damageamount)
    {
        health -= damageamount;
        audiosource.Play();
        healthtext.text = health.ToString();
        if (health <= 0)
        {
            losepanel.SetActive(true);
            Destroy(gameObject);
        }
    }
}
