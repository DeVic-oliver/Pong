using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorPlayerHandler : MonoBehaviour
{
    [SerializeField] private Image player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ApplyColorToPlayer(Image imageComponent)
    {
        player.color = imageComponent.color;
    }
}
