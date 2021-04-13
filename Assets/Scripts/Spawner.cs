using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject fallingBlocks;
    public float secondsBetweenSpawns = 0.5f;
    float level = 1;
    float current_time;
    float lastSpawn;
    public Vector2 spawnMinMax;
    public float spawnAngleMax;
    Vector2 ScreenWidth;

    // Start is called before the first frame update
    void Start()
    {
        current_time = Time.time;
        ScreenWidth = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
    }

    // Update is called once per frame
    void Update()
    {
        lastSpawn = current_time;
        int number = calc_level();
        if(Time.time > lastSpawn + secondsBetweenSpawns*level){
            lastSpawn = Time.time + secondsBetweenSpawns;
            for(int i = 0; i < number; i++)
                create_blocks();
        }
        current_time = lastSpawn;
    }

    int calc_level(){
        float difficulty = (Player.score/5)/100;
        level = 1 - difficulty*10;

        int number_of_blocks = (int) Player.score/5 + 1;
        return number_of_blocks;
    }

    void create_blocks(){
        float spawnSize = Random.Range(spawnMinMax.x, spawnMinMax.y);
        float spawnAngle = Random.Range(-spawnAngleMax, spawnAngleMax);
        Vector2 spawn_pos = new Vector2(Random.Range(-ScreenWidth.x, ScreenWidth.x), ScreenWidth.y + spawnSize);
        GameObject newBlock = (GameObject)Instantiate(fallingBlocks, spawn_pos, Quaternion.Euler(Vector3.forward * spawnAngle));
        newBlock.transform.localScale = Vector2.one * spawnSize;
    }
}
