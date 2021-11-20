using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class player : MonoBehaviour
{
    public int MaxPoints = 5;
    public float speed = 10;
    public Image UiPlayer;
    public string playerName;

    [Header("key setup")]
    public KeyCode KeyCodeMoveUp = KeyCode.UpArrow;
    public KeyCode KeyCodeMoveDown = KeyCode.DownArrow;

    public Rigidbody2D myRigidbody2D;

    [Header("Points")]
    public int currentPoints;
    public TextMeshProUGUI uiTextPoints; 

    private void Awake()
    {
        ResetPlayer();
    }

    public void SetName(string s)
    {
        playerName = s;
    }

    public void ResetPlayer()
    {
        currentPoints = 0;
        UpdateUI();
    }

    void Update()
    {
        if (Input.GetKey(KeyCodeMoveUp))
            myRigidbody2D.MovePosition(transform.position + transform.up * speed * Time.deltaTime * 100);
        //transform.Translate(transform.up * speed);
        else if (Input.GetKey(KeyCodeMoveDown))
            myRigidbody2D.MovePosition(transform.position + transform.up * -speed * Time.deltaTime * 100);
            //transform.Translate(transform.up * speed * -1);
    }

      public void AddPoint()
      {
        currentPoints++;
        UpdateUI();
        CheckMaxPoints();
        Debug.Log(currentPoints);
      }

    public void ChangeColor(Color c)
    {
        UiPlayer.color = c;
    }

    private void UpdateUI()
    {
        uiTextPoints.text = currentPoints.ToString();
    }

    private void CheckMaxPoints()
    {
      if(currentPoints >= MaxPoints)
        {
            GameManager.Instance.EndGame();
            HighscoreManager.Instance.SaveplayerWin(this);
        }
    }
}
