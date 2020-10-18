using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    public GameObject player;
    public GameObject deathZone;
    private Rigidbody2D rb2d;
    private SpriteRenderer spriteRenderer;
    private float moveInput;
    private float speed = 10f;

    public Text scoreText;
    public Text startText;
    public Text deadText;
    private float topScore = 0.0f;
    private bool isStarted = false;
    public bool isDead = false;
    private float angle = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.gravityScale = 0;
        rb2d.velocity = Vector3.zero;

        spriteRenderer = player.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isStarted == false)
        {
            isStarted = true;
            startText.gameObject.SetActive(false);
            rb2d.gravityScale = 5f;
        }

        if (isStarted)
        {
            if (rb2d.velocity.y > 0 && player.transform.position.y > topScore)
            {
                topScore = player.transform.position.y;
            }

            scoreText.text = "Score: " + Mathf.Round(topScore).ToString();

            if (rb2d.velocity.y > 0)
            {
                deathZone.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + -25f, player.transform.position.z);
            }
        }

        if (isDead)
        {
            deadText.gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    void FixedUpdate()
    {
        if (isStarted)
        {
            moveInput = Input.GetAxis("Horizontal");
            rb2d.velocity = new Vector2(moveInput * speed, rb2d.velocity.y);

            if (moveInput < 0)
            {
                spriteRenderer.flipX = true;
            }
            if (moveInput > 0)
            {
                spriteRenderer.flipX = false;
            }

            Vector2 v = rb2d.velocity;
            angle = Mathf.Atan2(v.x, v.y) * Mathf.Rad2Deg;
            player.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}
