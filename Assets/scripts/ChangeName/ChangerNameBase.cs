using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChangerNameBase : MonoBehaviour
{

    [Header("references")]
    public TextMeshProUGUI uiTextName;
    public TMP_InputField uiInputField;
    public GameObject changerNameinput;
    public player player;

    private string playername;


    public void ChangeName()
    {
        playername = uiInputField.text;
        uiTextName.text = playername;
        changerNameinput.SetActive(false);
        player.SetName(playername);
    }
}
