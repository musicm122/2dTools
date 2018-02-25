using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class Gravity : MonoBehaviour
{
    [SerializeField]
    bool IsOnTheGround;

    [SerializeField]
    float Weight;

    [SerializeField]
    float GravityScale;

    [SerializeField]
    string GroundLayer = "Ground";

    [SerializeField]
    Collider2D GroundCheckCollider;

    void FixedUpdate()
    {
        GroundCheck();
        if (!IsOnTheGround)
        {
            ApplyGravity(this.transform, Weight, GravityScale);
        }
    }

    public void GroundCheck()
    {
        IsOnTheGround = PhysicsHelpers.LayerCollisionCheck(GroundCheckCollider, GroundLayer);
    }

    void ApplyGravity(Transform body, float weight, float gravity)
    {
        body.Translate(Vector2.down * gravity * weight * Time.fixedDeltaTime);
    }
}
