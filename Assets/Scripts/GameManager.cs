using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Player player;
    public Text scoreText;
    public GameObject playButton;
    public GameObject gameOver;
    
    private int score;

    public void Pause() {

        Time.timeScale = 0f;
        player.enabled = false;
    }
    
    private void Awake() {

        Application.targetFrameRate = 60;

        Pause();
    }
    
    public void Play() {
        
        score = 0;
        scoreText.text = score.ToString();

        playButton.SetActive(false);
        gameOver.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;

        Buildings[] buildingsdown = FindObjectsOfType<Buildings>();

        for (int i = 0; i < buildingsdown.Length; i++) {
            Destroy(buildingsdown[i].gameObject);
        }

    }
    
    public void GameOver() {

        gameOver.SetActive(true);
        playButton.SetActive(true);

        Pause();
    }

    public void IncreaseScore(  ) {

        score++;
        scoreText.text = score.ToString();
    }

}
