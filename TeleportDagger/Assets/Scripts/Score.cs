using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    private float timer;
    public int score;

    private void Start()
    {
        scoreText.text = "Score: " + 0;
        score = 0;
    }

    void Update()
    {
        timer += 1 * Time.deltaTime * Speed.speed;
        if(timer >= 1)
        {
            score += 1;
            scoreText.text = "Score: " + score;
            timer = 0;
        }
    }
}
