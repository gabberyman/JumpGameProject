using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Controller : MonoBehaviour
{

    private Rigidbody2D rb2d;
    private float moveInput;
    private float speed = 10f;

    private bool isStarted = false;

    public TextMeshProUGUI scoreText;

    public TextMeshProUGUI startText;

    private float topScore = 0f;

    // Start is called before the first frame update
    void Start()
    {
        

        rb2d = GetComponent<Rigidbody2D>();

        rb2d.gravityScale = 0f;
        rb2d.velocity = Vector3.zero;


    }

    void Update() 
    {

        if (Input.GetKeyDown(KeyCode.Space) && !isStarted) 
        {

            isStarted = true;
            startText.gameObject.SetActive(false);
            rb2d.gravityScale = 5f;

        }

        if (isStarted == true) 
        {

            if (rb2d.velocity.y > 0 && transform.position.y > topScore)
            {

                topScore = transform.position.y;

            }

            scoreText.text = "Score: " + Mathf.Round(topScore).ToString();
        
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isStarted == true) 
        {
        
            moveInput = Input.GetAxis("Horizontal");
            rb2d.velocity = new Vector2(moveInput * speed, rb2d.velocity.y);
        }
    }
}
