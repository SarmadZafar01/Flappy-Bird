using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;

public class FlappyBirdyFly : MonoBehaviour

    
{

    public GameManger gameManger;

    [SerializeField] private float BirdSpeed =1;
    private Rigidbody2D rb;
    int score = 0;
    public TMP_Text ScoreText;

    public AudioSource audioSource;
    public AudioClip audioClip, gameoverSound, coinSound;

    public SpriteRenderer backgroundRenderer; // Reference to the background sprite renderer
    public Sprite background1; // First background
    public Sprite background2; // Second background
    public Sprite background3;
    public Sprite background4;// Third background
    public Sprite background5;
    public Sprite background6;
    private int currentBackground = 1; // Track the current background (1, 2, or 3)




    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            audioSource.clip = audioClip;
            audioSource.Play();
            rb.velocity = Vector2.up * BirdSpeed;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        audioSource.clip = gameoverSound;
        audioSource.Play();
        gameManger.GameOver();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            score++;
            audioSource.clip = coinSound;
            audioSource.Play();
            ScoreText.text = "Score:" + score;
            Destroy(collision.gameObject);


            if (score == 2 && currentBackground == 1)
            {
                currentBackground = 2;
                ChangeBackground(background2);
            }
            else if (score == 4 && currentBackground == 2)
            {
                currentBackground = 3;
                ChangeBackground(background3);
            }
            else if (score == 60 && currentBackground == 3)
            {
                currentBackground = 4;
                ChangeBackground(background4);
            }
            else if (score == 80 && currentBackground == 4)
            {
                currentBackground = 5;
                ChangeBackground(background5);
            }
            else if (score == 100 && currentBackground == 5)
            {
                currentBackground = 6;
                ChangeBackground(background6);
            }
        }

        void ChangeBackground(Sprite newBackground)
        {
            StartCoroutine(FadeBackground(newBackground));
        }

        IEnumerator FadeBackground(Sprite newBackground)
        {
            float duration = 1f; // Duration of the fade in seconds
            float elapsedTime = 0f;
            Color originalColor = backgroundRenderer.color; // Get the original color of the background
            Color targetColor = new Color(originalColor.r, originalColor.g, originalColor.b, 0); // Target is fully transparent

            // Fade out the old background
            while (elapsedTime < duration)
            {
                elapsedTime += Time.deltaTime;
                backgroundRenderer.color = Color.Lerp(originalColor, targetColor, elapsedTime / duration);
                yield return null;
            }

            // Switch to the new background once the fade-out is complete
            backgroundRenderer.sprite = newBackground;

            // Reset elapsed time for the fade-in
            elapsedTime = 0f;
            targetColor = new Color(originalColor.r, originalColor.g, originalColor.b, 1); // Target is fully opaque

            // Fade in the new background
            while (elapsedTime < duration)
            {
                elapsedTime += Time.deltaTime;
                backgroundRenderer.color = Color.Lerp(new Color(originalColor.r, originalColor.g, originalColor.b, 0), targetColor, elapsedTime / duration);
                yield return null;
            }
        }
    }

}
