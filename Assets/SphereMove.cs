using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SphereMove : MonoBehaviour
{
    public float speed = 0.5f;
    public int score = 0;
    public TMP_Text scoreText;
    public GameObject pauseObject;
    private bool countdown;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        countdown = false;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float horizMove = Input.GetAxisRaw("Horizontal") 
            * speed * Time.deltaTime;
        float vertMove = Input.GetAxisRaw("Vertical") 
            * speed * Time.deltaTime;
        transform.position += new Vector3(horizMove, 0, vertMove);

        if (Input.GetKeyDown(KeyCode.Space)){
            if (Time.timeScale == 0){
                Time.timeScale = 1;
                pauseObject.SetActive(false);
            } else{
                Time.timeScale = 0;
                pauseObject.SetActive(true);
            }
        }

        if (Input.GetKeyDown(KeyCode.Q)){
            countdown = true;
        }

        if (countdown){
            if (timer < 3){
                timer += Time.deltaTime;
            }
            else{
                UnityEditor.EditorApplication.isPlaying = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        float newX = Random.Range(-12, 12);
        float newZ = Random.Range(-5, 5);
        other.transform.position = 
               new Vector3(newX, 0, newZ);

        score++;
        Debug.Log("Score is now: " + score);
        scoreText.text = "Score: " + score;
    }
}
