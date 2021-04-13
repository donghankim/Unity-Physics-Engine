using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class gameover : MonoBehaviour
{
    public GameObject gameOver_screen;
    public TMP_Text sec_survived;
    bool game;

    float start_time;

    void Start(){
        start_time = Time.time;
        FindObjectOfType<Player> ().OnPlayerDeath += gameOver;

    }

    void Update()
    {
        if(game){
            if(Input.GetKeyDown (KeyCode.Space)){
                start_time = Time.time;
                SceneManager.LoadScene(0);
            }
        }
    }

    void gameOver(){
        gameOver_screen.SetActive(true);
        sec_survived.text = Mathf.RoundToInt((Time.time - start_time)).ToString();
        game = true;
    }
}
