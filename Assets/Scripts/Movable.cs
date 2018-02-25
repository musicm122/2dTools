using System.Collections;
using System.Collections.Generic;
using Enums;
using UnityEngine;


public class Movable : MonoBehaviour, IMovable
{
    [SerializeField]
    float MoveSpeed = 2.0f;

    private void FixedUpdate()
    {
        MoveCheck();
    }

    public void MoveCheck()
    {
        Move(this.transform, GetMoveDirection(), MoveSpeed);
    }

    public MoveDirection2d GetMoveDirection()
    {
        var inputVal = Input.GetAxis("Horizontal");

        if (Mathf.Approximately(inputVal, 0))
        {
            return MoveDirection2d.None;
        }
        else
        {
            return (inputVal > 0) ? MoveDirection2d.Right : MoveDirection2d.Left;
        }
    }

    public void Move(Transform body, MoveDirection2d direction, float speed)
    {
        if (direction == MoveDirection2d.Right)
        {
            MoveRight(body, speed);
        }
        if (direction == MoveDirection2d.Left)
        {
            MoveLeft(body, speed);
        }
    }

    public void MoveLeft(Transform body, float speed)
    {
        body.Translate(Vector2.left * speed * Time.fixedDeltaTime);
    }

    public void MoveRight(Transform body, float speed)
    {
        body.Translate(Vector2.right * speed * Time.fixedDeltaTime);
    }

}
