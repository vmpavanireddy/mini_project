using UnityEngine;

public class enemy : MonoBehaviour
{
    public float minspeed;
    public float maxspeed;
    float speed;

    public int damage;
    player playerscript;
    public GameObject effcts;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        speed=Random.Range(minspeed,maxspeed);
        playerscript=GameObject.FindGameObjectWithTag("Player").GetComponent<player>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down*speed*Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D hitobject)
    {
        if(hitobject.tag=="Player")
        {
            print("player hit");
            playerscript.takeDamage(damage);
            Instantiate(effcts,transform.position,Quaternion.identity);
            Destroy(gameObject);
        }
        if(hitobject.tag=="ground")
        {
            Instantiate(effcts,transform.position,Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
