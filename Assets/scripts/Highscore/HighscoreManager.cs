using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighscoreManager : MonoBehaviour
{
    public static HighscoreManager Instance;

    private string KeyToSave = "KeyHighscore";

    [Header("References")]
    public TextMeshProUGUI uitextHighscore; 

    private void Awake()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        UpdateText();
    }

    private void UpdateText()
    {
        uitextHighscore.text = PlayerPrefs.GetString(KeyToSave, "Sem Highscore");
    }

    public void SaveplayerWin(player p)
    {
        if (p.playerName == "") return;
        PlayerPrefs.SetString(KeyToSave, p.playerName);
        UpdateText();
    }
}
