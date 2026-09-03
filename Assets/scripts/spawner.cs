using UnityEngine;

public class spawner : MonoBehaviour
{
    public Transform[] spawnpoints;
    public GameObject[] enemies;

    private float timebtwspawn;
    public float starttimebtwspawn;

    public float mintimebtwspawn;
    public float decreasetime;

    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            if (timebtwspawn <= 0)
            {
                Transform randspawnpoint = spawnpoints[Random.Range(0, spawnpoints.Length)];
                GameObject randenemy = enemies[Random.Range(0, enemies.Length)];
                Instantiate(randenemy, randspawnpoint.position, Quaternion.identity);

                if (starttimebtwspawn > mintimebtwspawn)
                {
                    starttimebtwspawn -= decreasetime;
                }


                timebtwspawn = starttimebtwspawn;
            }
            else
            {
                timebtwspawn -= Time.deltaTime;
            }
        }
    }
}

