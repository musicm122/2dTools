using System.Collections;
using System.Collections.Generic;
using Enums;
using Scripts.Importer.Parts;
using UnityEngine;


public class Movable : MonoBehaviour, IMovable
{
    const int StillPosition = 0;

    [SerializeField]
    public RunPart RunData;



    private void FixedUpdate()
    {
        Move(this.transform, GetMoveDirection(), RunData.MaxSpeed);
    }

    public MoveDirection2d GetMoveDirection()
    {
        var inputVal = Input.GetAxis("Horizontal");

        if (Mathf.Approximately(inputVal, StillPosition))
        {
            return MoveDirection2d.None;
        }
        else
        {
            return (inputVal > StillPosition) ? MoveDirection2d.Right : MoveDirection2d.Left;
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

    void MoveLeft(Transform body, float speed)
    {
        body.Translate(Vector2.left * speed * Time.fixedDeltaTime);
    }

    void MoveRight(Transform body, float speed)
    {
        body.Translate(Vector2.right * speed * Time.fixedDeltaTime);
    }

}
