using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ButtonColorBase : MonoBehaviour
{
    public Color color;

    [Header("References")]
    public Image uiimage;

    public player myplayer;

    private void OnValidate()
    {
        uiimage = GetComponent<Image>();
    }

    void Start()
    {
        uiimage.color = color;
    }

    public void onclick()
    {
        myplayer.ChangeColor(color);
    }
}
