using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameScoreHandler : MonoBehaviour
{
    public Player Player1;
    public Player Player2;
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
        player1Score.text = Player1.Points.ToString();
        player2Score.text = Player2.Points.ToString();
    }
    
    public void SetGameWinner()
    {
        if(Player1.Points > Player2.Points) 
        {
            WriteWinnerName(Player1);
        }else if (Player1.Points < Player2.Points)
        {
            WriteWinnerName(Player2);
        }
        else
        {
            winnerScoreboard.text = "Draw Game!!!";
        }
    }
    private void WriteWinnerName(Player player)
    {
        winnerScoreboard.text += $" {player.Name} - {player.Points}";
    }

    public void ResetScoreboard()
    {
        winnerScoreboard.text = scoreBoardInitialText;
        ResetPlayerPoints();
    }
    private void ResetPlayerPoints()
    {
        Player1.Points = 0;
        Player2.Points = 0;
    }
}
