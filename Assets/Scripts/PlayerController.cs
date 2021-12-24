using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody Player;
    //public GameObject BallVisible;
    /// <summary>
    /// sets the speed of the ball. How fast? no idea.;
    /// </summary>
    public float speed = 700f;
    private int score = 0;
    /// <summary>
    /// player health;
    /// </summary>
    public int health = 5;
    void Start()
    {
        
    }

    void Update()
    {
        if (health == 0)
        {
            Debug.Log("Game Over!");
            score = 0;
            health = 5;
            SceneManager.LoadScene("maze");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey("w") || Input.GetKey(KeyCode.UpArrow))
            Player.AddForce(0, 0, speed * Time.deltaTime);
        if (Input.GetKey("s") || Input.GetKey(KeyCode.DownArrow))
            Player.AddForce(0, 0, -speed * Time.deltaTime);
        if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
            Player.AddForce(speed * Time.deltaTime, 0, 0);
        if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow))
            Player.AddForce(-speed * Time.deltaTime, 0, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pickup")
        {
            score++;
            Debug.Log("Score: " + score.ToString());
            Destroy(other.gameObject);
        }
        if (other.tag == "Trap")
        {
            health--;
            Debug.Log("Health: " + health);
        }
        if (other.tag == "Goal")
            Debug.Log("You win!");
    }
}
