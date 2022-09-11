using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    public Player Player1Points;
    public Player Player2Points;
    [SerializeField] private TextMeshProUGUI player1Score;
    [SerializeField] private TextMeshProUGUI player2Score;
    [SerializeField] private BallMovement ball;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScore();
        if (PointBoundary.IsPointMade)
        {
            ResetBallPosition();
            PointBoundary.IsPointMade = false;
        }
    }
    private void UpdateScore()
    {
        player1Score.text = Player1Points.Points.ToString();
        player2Score.text = Player2Points.Points.ToString();
    }
    private void ResetBallPosition()
    {
        ball._rectTransform.localPosition = ball._initialPosition;
    }
}
