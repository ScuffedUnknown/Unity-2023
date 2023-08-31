using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BallScript : MonoBehaviour
{
    int score;
    int HighScore;
    Vector3 ballPos;
    Rigidbody rb;
    [SerializeField]
    TMP_Text scoreHUD;
    public GameObject GameOverUI;
    public TimerScript clock;
    public AudioClip SFX;
    public AudioClip endSFX;
    AudioSource soundSource;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        rb = GetComponent<Rigidbody>();
        ballPos = transform.position;
        GameOverUI.SetActive(false);
        HighScore = PlayerPrefs.GetInt("highscore");
        soundSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -10)
        {
            //  soundSource.PlayOneShot(endSFX);
            GameOverUI.SetActive(true);
            clock.isGameOver = true;
            if(HighScore < score)
            {
                HighScore = score;
                PlayerPrefs.SetInt("highscore", HighScore);
            }

            if(clock.seconds > 9)
            {
                GameOverUI.GetComponent<TMP_Text>().text = $"Game Over\n You're High Score is {HighScore}\n You're time was {clock.minutes}:{clock.seconds}";
            }
            else
            {
                GameOverUI.GetComponent<TMP_Text>().text = $"Game Over\n You're High Score is {HighScore}\n You're time was {clock.minutes}:0{clock.seconds}";

            }
        }
    }

    public void RestartGame()
    {
        score = 0;
        scoreHUD.text = $"Score: {score}";
        rb.velocity = Vector3.zero;
        transform.position = ballPos;
        clock.startTime = 0;
        clock.isGameOver = false;
        GameOverUI.SetActive(false);

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Paddle")
        {
            soundSource.PlayOneShot(SFX);
            score++;
            scoreHUD.text = $"Score: {score}";
        }
    }
}
