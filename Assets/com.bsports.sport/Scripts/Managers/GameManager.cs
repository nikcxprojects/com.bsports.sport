using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static bool IsPause { get; set; }
    public static GameManager Instance { get => FindObjectOfType<GameManager>(); }

    [SerializeField] GameObject menu;
    [SerializeField] GameObject best;
    [SerializeField] GameObject game;
    [SerializeField] GameObject pause;

    private int score;
    [Space(10)]
    [SerializeField] Text scoreText;
    [SerializeField] Text finalScoreText;

    private GameObject LevelRef { get; set; }

    private void Awake()
    {
        OpenGame(false);
    }

    public void OpenBestScore(bool IsOpen)
    {
        menu.SetActive(!IsOpen);
        best.SetActive(IsOpen);
    }

    public void OpenGame(bool IsOpen)
    {
        pause.SetActive(false);

        menu.SetActive(!IsOpen);
        game.SetActive(IsOpen);

        if(IsOpen)
        {
            score = 0;
            UpdateScore(0);

            LevelRef = Instantiate(Resources.Load<GameObject>("level"), GameObject.Find("Environment").transform);
        }
        else
        {
            if(!LevelRef)
            {
                return;
            }

            Destroy(LevelRef);
            IsPause = false;
        }
    }

    public void OpenPause(bool IsOpen)
    {
        IsPause = IsOpen;

        game.SetActive(!IsOpen);
        pause.SetActive(IsOpen);
    }

    public void UpdateScore(int amount)
    {
        score += amount;
        scoreText.text = finalScoreText.text = $"{score}";
    }
}
