using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public BallBase ballBase;

    public static GameManager Instance;

    public float timeToSetBallFree = 1f;

    public StateMachine stateMachine;

    public player[] players;

    [Header("menus")]
    public GameObject uiMainMenu;

    private void Awake()
    {
        Instance = this;

        players = FindObjectsOfType<player>();
    }

    public void ResetBall()
    {
        ballBase.canMove(false);
        ballBase.ResetBall();
        Invoke(nameof(SetBallFree), timeToSetBallFree);
    }

    public void ResetPlayers()
    {
       foreach(var player in players)
        {
            player.ResetPlayer();
        }
    }

    private void SetBallFree()
    {
        ballBase.canMove(true);
    }

    public void StartGame()
    {
        ballBase.canMove(true);
    }

    public void EndGame()
    {
        stateMachine.SwitchState(StateMachine.states.END_GAME);
    }

    public void ShowMainMenu()
    {
        uiMainMenu.SetActive(true);
        ballBase.canMove(false);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}

