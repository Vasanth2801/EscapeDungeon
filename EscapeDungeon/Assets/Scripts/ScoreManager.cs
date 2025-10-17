using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int score = 0;
    public TextMeshProUGUI scoreText;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        scoreText.text = "Score: " + score;
    }

    public void Update()
    {
        scoreText.text = "Score: " + score;
    }

    public void AddScore(int amount)
    {
        score += amount;
    }
}
