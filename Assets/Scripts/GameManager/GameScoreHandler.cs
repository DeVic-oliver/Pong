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
    [SerializeField] private TextMeshProUGUI winnerScoreboard;

    private string scoreBoardInitialText;
    private void Start()
    {
        scoreBoardInitialText = winnerScoreboard.text;
    }

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
    
    public void SetGameWinner()
    {
        if(Player1Points.Points > Player2Points.Points) 
        {
            winnerScoreboard.text += " Player 1 - " + Player1Points.Points + " points";
        }else if (Player1Points.Points < Player2Points.Points)
        {
            winnerScoreboard.text += " Player 2 - " + Player2Points.Points + " points";
        }
        else
        {
            winnerScoreboard.text = "Draw Game!!!";
        }
    }
    public void ResetScoreboard()
    {
        winnerScoreboard.text = scoreBoardInitialText;
        ResetPlayerPoints();
    }
    private void ResetPlayerPoints()
    {
        Player1Points.Points = 0;
        Player2Points.Points = 0;
    }
}
