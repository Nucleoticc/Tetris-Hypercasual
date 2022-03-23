using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] Text MultiplierText;
    Text scoreText;

    int score;
    int multiplier = 1;

    public static Score instance;

    void Awake()
    {
        instance = this;
        scoreText = GetComponent<Text>();
    }

    public void AddScore(int _score)
    {
        Debug.Log("Score: " + _score);
        score += _score;
        scoreText.text = $"${score}";
    }

    public void SubtractScore(int _score)
    {
        score -= _score;
        scoreText.text = $"${score}";
    }

    public int GetScore()
    {
        return score * multiplier;
    }

    public void SetMultipler(int _multiplier)
    {
        multiplier = _multiplier;
        MultiplierText.text = $"Stacked: x{multiplier}";
    }
}
