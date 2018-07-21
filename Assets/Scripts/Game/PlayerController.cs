using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public enum PlayerTurn
{
    Forward,
    Top,
    Down
}
public class PlayerController : MonoBehaviour
{
    [SerializeField] private List<GameObject> segments = new List<GameObject>();
    [SerializeField] private GameData gameData;
    [SerializeField] private List<Vector3> turnRotations;
    [SerializeField] private PlayerTurn currentTurn;
    private void Awake()
    {
        for (int i = 0; i < segments.Count; i++)
        {
            WormSegment segment = segments[i].GetComponent<WormSegment>();
            try
            {
                segment.Next = segments[i - 1];
                
            }
            catch (ArgumentOutOfRangeException)
            {
                segment.Next = null;
            }
            try
            {
                segment.Prev = segments[i + 1];
            }
            catch (ArgumentOutOfRangeException)
            {
                segment.Prev = null;
            }
        }
        currentTurn = PlayerTurn.Forward;
        TurnPlayer();
    }


    private void Update()
    {
        Move();
        ChangeTurn();

    }
    private void Move()
    {
        segments[0].transform.localPosition += segments[0].transform.right * gameData.GameSpeed * Time.deltaTime;
    }

    private void ChangeSegmentPosition(GameObject segment,  Vector3 newPos)
    {
        segment.transform.position = newPos;
    }



    private void ChangeTurn()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (CurrentTurn == PlayerTurn.Forward) CurrentTurn = PlayerTurn.Down;
            CurrentTurn = CurrentTurn == PlayerTurn.Down ? PlayerTurn.Top : PlayerTurn.Down;
        }
    }
    private void TurnPlayer()
    {
        switch (currentTurn)
        {
            case PlayerTurn.Forward:
                segments[0].transform.rotation = Quaternion.Euler(turnRotations[0]);
                break;
            case PlayerTurn.Top:
                segments[0].transform.rotation = Quaternion.Euler(turnRotations[1]);
                break;
            case PlayerTurn.Down:
                segments[0].transform.rotation = Quaternion.Euler(turnRotations[2]);
                break;
            default:
                break;
        }

    }
    private PlayerTurn CurrentTurn
    {
        get
        {
            return currentTurn;
        }
        set
        {
            currentTurn = value;
            TurnPlayer();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

    }
}
