using UnityEngine;
using System.Collections;
using Enums;

public interface IMovable
{
    MoveDirection2d GetMoveDirection();
    void Move(Transform body, MoveDirection2d direction, float speed);
    void MoveLeft(Transform body, float speed);
    void MoveRight(Transform body, float speed);
}
