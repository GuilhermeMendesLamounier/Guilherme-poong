using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPoint : MonoBehaviour
{
    public player player;
    public string tagToCheck = "Ball";

    private void OnTriggerEnter2D(Collider2D collision)
    {
      if(collision.transform.tag == tagToCheck)
      {
            Debug.Log("Bati Na bola");
            Coutpoint();
      }  
    }

    private void Coutpoint()
    {
        StateMachine.Instance.ResetPosition();
        player.AddPoint();
    }
}
