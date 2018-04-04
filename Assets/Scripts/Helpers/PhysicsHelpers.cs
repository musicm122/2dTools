using Constants;
using UnityEngine;

namespace Helpers
{
    public static class PhysicsHelpers
    {

        public static bool LayerCollisionCheck(Collider2D collider, string layerName)
        {
            var layer = LayerMask.NameToLayer(layerName);
            return collider.IsTouchingLayers();
        }

        public static bool IsGrounded(Transform transform, Transform groundCheck)
        {
            return Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer(DefaultValues.GroundLayer));
        }
    }
}