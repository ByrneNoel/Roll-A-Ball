using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Diagnostics;


public class PlayerController : MonoBehaviour
{

    public float speed = 800.0f;
    public Text scoreText;
    private int count = 0;
    public Text winText;
    public Text livesText;
    public GameObject ExitRamp;
    public GameObject PlatformDoor;
    public Vector3 respawnpoint = new Vector3(0.0f, 0.5f, 0.0f);
    private int lives = 3;
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        GetComponent<Rigidbody>().AddForce(movement * speed * Time.deltaTime);
        if(transform.position.y < -5)
        {
            respawn();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag =="Portal")
        {
            SceneManager.LoadScene(1);
            
        }
        if (other.gameObject.tag =="Enemy")
        {
            respawn();
        }
        if (other.gameObject.tag == "Pickup")
        {
            other.gameObject.SetActive(false);
            
            scoreText.text = "Score: " + ++count;
        }
        if (count >= 14)
        {
            
            ExitRamp.SetActive(true);
        }
        
    }

    void respawn()
    {
        lives--;
        livesText.text = "Lives: " + lives;

        if (lives <= 0)
        {
            SceneManager.LoadScene(2);
        }
        else
        {
            transform.position = respawnpoint;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}