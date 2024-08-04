using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Score : MonoBehaviour
{
    [SerializeField]
    private TMP_Text scoreObject;

    [SerializeField]
    private TMP_Text pointObject;

    private GameManager gameManager;

    private int _score;

    void Start()
    {
        gameManager = GetComponent<GameManager>();
    }


    void Update()
    {
        if(GetScore() >= 150)
        {
            ContolPoints.Instante.SavePoints(GetScore());
            gameManager.EndGame();
        }
    }

    public int GetScore()
    {
        return _score;
    }
    
    public void SetScore(int score)
    {
        _score += score;

        scoreObject.text = "Puntos: " + _score.ToString();

        pointObject.text = "+ " + score;

    }

}
