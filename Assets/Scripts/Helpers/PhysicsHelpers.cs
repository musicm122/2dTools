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
    }
}