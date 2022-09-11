using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameTimeHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI clock;
    [SerializeField] private int maxTime;

    public float CurrentTime { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        clock.text = maxTime.ToString();
        CurrentTime = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void DecreaseTime()
    {
        if(CurrentTime >= 0)
        {
            CurrentTime -= Time.deltaTime;
        }
        ApplyClockTime();
    }
    private void ApplyClockTime()
    {
        clock.text = CurrentTime.ToString("N0");
    }
    public void ResetTime()
    {
        CurrentTime = maxTime;
        clock.text = maxTime.ToString();
    }
}
