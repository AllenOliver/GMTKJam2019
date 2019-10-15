using UnityEngine;

namespace Assets.Scripts.Globals
{
    public static class BoxCollider2DExtensions
    {
        /// <summary>
        /// Enables the specified collider.
        /// </summary>
        /// <param name="box">The box.</param>
        public static void On(this BoxCollider2D box) => box.enabled = true;

        /// <summary>
        /// disables the specified collider.
        /// </summary>
        /// <param name="box">The box.</param>
        public static void Off(this BoxCollider2D box) => box.enabled = false;
    }
}