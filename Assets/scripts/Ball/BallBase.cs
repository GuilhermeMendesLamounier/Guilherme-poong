using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBase : MonoBehaviour
{
    public Vector3 speed = new Vector3(1, 1);
    private Vector3 startspeed;

    public string KeyToCheck = "Player";

    [Header("Randomization")]
    public Vector2 randSpeedY = new Vector2(1, 3);
    public Vector2 randSpeedX = new Vector2(1, 3);

    private Vector3 _startePosition;
    private bool _canMove = false;

    private RectTransform _rectTrasnform;

    private void Awake()
    {
        _rectTrasnform = gameObject.GetComponent<RectTransform>();
        _startePosition = _rectTrasnform.localPosition;
        startspeed = speed;
    }

    void Update()
    {
        if (!_canMove) return;

        transform.Translate(speed * Time.deltaTime * 100); 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == KeyToCheck)
            OnPlayerCollision();
        else
            speed.y *= -1;
    }

    private void OnPlayerCollision()
    {
        speed.x *= -1;

        float rand = Random.Range(randSpeedX.x, randSpeedX.y);

        if (speed.x < 0)
            rand = -rand;

        speed.x = rand;


        rand = Random.Range(randSpeedY.x, randSpeedY.y);
        speed.y = rand;
    }

    public void ResetBall()
    {
        _rectTrasnform.localPosition = _startePosition;
        speed = startspeed;
    }

    public void canMove(bool state)
    {
        _canMove = state;
    }

    


}
