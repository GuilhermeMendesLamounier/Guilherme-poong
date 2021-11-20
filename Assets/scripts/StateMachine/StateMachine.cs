using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
  public enum states
    {
        MENU,
        PLAYING,
        RESET_POSITION,
        END_GAME,
    }

    public Dictionary<states, StateBase> dictionaryState;

    private StateBase _currentState;
    public player player;
    public float TimeToStartGame = 1f;

    public static StateMachine Instance;

    private void Awake()
    {
        Instance = this;

        dictionaryState = new Dictionary<states, StateBase>();
        dictionaryState.Add(states.MENU, new StateBase());
        dictionaryState.Add(states.PLAYING, new StatePlaying());
        dictionaryState.Add(states.RESET_POSITION, new StateResetPosition());
        dictionaryState.Add(states.END_GAME, new StateEndGame());

        SwitchState(states.MENU);
    }

    public void SwitchState(states state)
    {
        if (_currentState != null) _currentState.OnStateExit();

        _currentState = dictionaryState[state];

        _currentState.OnStateEnter(player);

        if (_currentState != null) _currentState.OnStateEnter();
    }


    private void Update()
    {
        if (_currentState != null) _currentState.OnStateStay();
    }
    public void ResetPosition()
    {
        SwitchState(states.RESET_POSITION);
    }

}
