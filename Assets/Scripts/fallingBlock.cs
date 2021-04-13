using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingBlock : MonoBehaviour
{

    float visibleHeight;
    float speed = 7;
    // Start is called before the first frame update
    void Start()
    {
        visibleHeight = -Camera.main.orthographicSize - transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down*speed*Time.deltaTime);
        if(transform.position.y < visibleHeight){
            Destroy(gameObject);
            Player.score++;
        }
    }
}
