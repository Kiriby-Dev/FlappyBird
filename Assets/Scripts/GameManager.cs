using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private Player player;

    private int score;
    private static List<Pipes> pipesList = new List<Pipes>();

    private void Awake()
    {
        Pause();
    }

    public void Play() {
        score = 0;
        scoreText.text = score.ToString();

        playButton.SetActive(false);
        gameOver.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;

        for (int i = pipesList.Count - 1; i >= 0; i--)
        {
            Destroy(pipesList[i].gameObject);
        }

        pipesList.Clear(); // Limpia la lista
    }

    public void Pause() {
        Time.timeScale = 0f;
        player.enabled = false;
    }

    public void IncreaseScore() {
        score++;
        scoreText.text = score.ToString();
    }

    public void GameOver() {
        gameOver.SetActive(true);
        playButton.SetActive(true);
        Pause();
    }

    public static void RegisterPipe(Pipes pipe)
    {
        if (!pipesList.Contains(pipe))
        {
            pipesList.Add(pipe);
        }
    }

    public static void UnregisterPipe(Pipes pipe)
    {
        if (pipesList.Contains(pipe))
        {
            pipesList.Remove(pipe);
        }
    }
}
