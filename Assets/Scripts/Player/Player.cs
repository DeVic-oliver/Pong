using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Player : MonoBehaviour
{
    public static bool shouldNameSet = false;

    public int Points { get; set; }
    public string Name { get; private set; }
    [SerializeField] private TMP_InputField nameInput;
    [SerializeField] private TextMeshProUGUI playerName;
    private bool isNameSet = false;
    
    private void Update()
    {
        if (shouldNameSet && !isNameSet)
        {
            SetPlayerName();
            isNameSet = true;
        }
    }
    private void SetPlayerName()
    {
        Name = nameInput.text;
        playerName.text = Name;
    }
}
