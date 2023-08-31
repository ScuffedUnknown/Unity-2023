using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BallScript : MonoBehaviour
{
    Vector3 ballPos;
    Rigidbody rb;
    int score;
    int highScore;
    [SerializeField]
    TMP_Text scoreHUD;
    public GameObject GameOverUI;
    public TimerScript clock;
    public AudioClip[] sfx;
    public AudioClip endSfx;
    AudioSource soundSource;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ballPos = transform.position;
        score = 0;
        GameOverUI.SetActive(false);
        highScore = PlayerPrefs.GetInt("highscore");
        soundSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -10)
        {
            GameOverUI.SetActive(true);

            if (!clock.isGameOver)
            {
                soundSource.PlayOneShot(endSfx);
            }

            clock.isGameOver = true;


           
            if(score > highScore)
            {
                highScore = score;
                PlayerPrefs.SetInt("highscore", highScore);
            }

            if(clock.seconds > 9)
            {
                GameOverUI.GetComponent<TMP_Text>().text = $"Game Over\n Your high score is {highScore}\n Your time was {clock.minutes}:{clock.seconds}";
            }
            else
            {
                GameOverUI.GetComponent<TMP_Text>().text = $"Game Over\n Your high score is {highScore}\n Your time was {clock.minutes}:0{clock.seconds}";
            }
        }
    }

    public void RestartGame()
    {
        rb.velocity = Vector3.zero;
        transform.position = ballPos;
        score = 0;
        scoreHUD.text = $"Score: {score}";
        GameOverUI.SetActive(false);
        clock.startTime = 0;
        clock.isGameOver = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Paddle")
        {
            //playes sound effect
            soundSource.PlayOneShot(sfx[Random.Range(0, sfx.Length)]);
            score++;
            scoreHUD.text = $"Score: {score}";
        }
    }
}
