using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameTimeHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI clock;
    [SerializeField] private int maxTime;

    private float currentTime;
    // Start is called before the first frame update
    void Start()
    {
        clock.text = maxTime.ToString();
        currentTime = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void DecreaseTime()
    {
        if(currentTime >= 0)
        {
            currentTime -= Time.deltaTime;
        }
        ApplyClockTime();
    }
    private void ApplyClockTime()
    {
        clock.text = currentTime.ToString("N0");
    }
    public void ResetTime()
    {
        currentTime = maxTime;
        clock.text = maxTime.ToString();
    }
}
