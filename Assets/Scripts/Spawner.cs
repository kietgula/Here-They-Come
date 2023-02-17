using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject CrabPrefab;
    public float leftCorner;
    public float rightCorner;
    public float topCorner;

    float nextSpawnTime;
    public float spawnDelay;


    void Start()
    {
        nextSpawnTime = Time.time;
    }

    void Update()
    {
        if (nextSpawnTime < Time.time)
        {
            var CrabPosition = new Vector3(Random.Range(leftCorner, rightCorner), topCorner, 0);
            GameObject crab = Instantiate(CrabPrefab, CrabPosition, this.transform.rotation);
            GameEnvironment.Singleton.AddTopper(crab);
            
            nextSpawnTime = Time.time + spawnDelay;
        }
    }


}
