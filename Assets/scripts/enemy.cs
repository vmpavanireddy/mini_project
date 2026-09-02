using UnityEngine;

public class enemy : MonoBehaviour
{
    public float minspeed;
    public float maxspeed;
    float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        speed=Random.Range(minspeed,maxspeed);
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
        }
    }
}
