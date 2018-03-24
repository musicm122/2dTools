using UnityEngine;

public interface IJumpable
{
    bool IsOnTheGround();
    void Jump(Transform body, float jumpForce, Jumpable.JumpSize jumpSize);
    void JumpCheck();
}