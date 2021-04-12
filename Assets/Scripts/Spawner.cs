using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject fallingBlocks;
    public float secondsBetweenSpawns = 1;
    float lastSpawn;
    public Vector2 spawnMinMax;
    public float spawnAngleMax;
    Vector2 ScreenWidth;

    // Start is called before the first frame update
    void Start()
    {
        ScreenWidth = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
 
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > lastSpawn){
            lastSpawn = Time.time + secondsBetweenSpawns;
            float spawnSize = Random.Range(spawnMinMax.x, spawnMinMax.y);
            float spawnAngle = Random.Range(-spawnAngleMax, spawnAngleMax);
            Vector2 spawn_pos = new Vector2(Random.Range(-ScreenWidth.x, ScreenWidth.x), ScreenWidth.y + spawnSize);
            GameObject newBlock = (GameObject) Instantiate(fallingBlocks, spawn_pos, Quaternion.Euler(Vector3.forward*spawnAngle));
            newBlock.transform.localScale = Vector2.one * spawnSize;
        }
    }
}
