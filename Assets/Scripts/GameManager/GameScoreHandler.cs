using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameScoreHandler : MonoBehaviour
{
    public Player Player1Points;
    public Player Player2Points;
    [SerializeField] private TextMeshProUGUI player1Score;
    [SerializeField] private TextMeshProUGUI player2Score;

    // Update is called once per frame
    void Update()
    {
        UpdateScore();
    }
    private void UpdateScore()
    {
        player1Score.text = Player1Points.Points.ToString();
        player2Score.text = Player2Points.Points.ToString();
    }
}
