using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static float score;
    public float speed = 7;
    float screenWidth;

    public event System.Action OnPlayerDeath;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        float halfPlayerWidth = transform.localScale.x /2.0f;
        screenWidth = Camera.main.aspect * Camera.main.orthographicSize + halfPlayerWidth;
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float velocity = inputX * speed;
        transform.Translate(Vector2.right * velocity * Time.deltaTime);

        if(transform.position.x > screenWidth)
            transform.position = new Vector2(-screenWidth, transform.position.y);
        if(transform.position.x < -screenWidth)
            transform.position = new Vector2(screenWidth, transform.position.y);
    }

    void OnTriggerEnter2D(Collider2D trigger_collider){
        if(trigger_collider.tag == "FallingBlock"){
            if(OnPlayerDeath != null)
                OnPlayerDeath();
            Destroy(gameObject);
        }
    }
}
