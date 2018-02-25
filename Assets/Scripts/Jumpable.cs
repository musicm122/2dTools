using UnityEngine;
using System.Collections;

public class Jumpable : MonoBehaviour
{
    [SerializeField]
    float JumpForce = 10.0f;

    [SerializeField]
    Collider2D JumpCollider;

    [SerializeField]
    string GroundLayer = "Ground";

    [SerializeField]
    string jumpButtonName = "Jump";

    public void JumpCheck()
    {
        if (Input.GetButtonDown(jumpButtonName))
        {
            Jump(this.transform, JumpForce);
        }
    }

    public bool IsOnTheGround()
    {
        return PhysicsHelpers.LayerCollisionCheck(JumpCollider, GroundLayer);
    }

    public void Jump(Transform body, float jumpForce)
    {
        if (IsOnTheGround())
        {
            body.Translate(Vector2.up * jumpForce * Time.fixedDeltaTime);
        }
    }

    void FixedUpdate()
    {
        JumpCheck();
    }
}
